using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using ThePenitent.ThePenitentCode.Interfaces;
using ThePenitent.ThePenitentCode.CustomData;
using ThePenitent.ThePenitentCode.Scale;

namespace ThePenitent.ThePenitentCode.Relics;

public sealed class SealedPenanceRelic : ThePenitentRelic, IBeforeDescendListener
{
    public override RelicRarity Rarity => RelicRarity.Uncommon;

    private const decimal DescendReduction = 3M;

    private bool _usedThisCombat;

    public override Task BeforeSideTurnStart(PlayerChoiceContext choiceContext, CombatSide side, IReadOnlyList<Creature> participants,
        ICombatState combatState)
    {
        if (side == Owner.Creature.Side && combatState.RoundNumber == 1)
            _usedThisCombat = false;

        return Task.CompletedTask;
    }

    public override bool ShowCounter => !_usedThisCombat;

    public Task BeforeDescend(DescendData descendData)
    {
        if (_usedThisCombat)
            return Task.CompletedTask;

        if (descendData.Owner != Owner.Creature)
            return Task.CompletedTask;

        decimal burdenCreated = descendData.Amount - PenitentScaleTracker.FaithAmount(Owner.Creature);
        if (burdenCreated <= 0M)
            return Task.CompletedTask;

        Flash();
        _usedThisCombat = true;
        descendData.Amount = Math.Max(0M, descendData.Amount - DescendReduction);

        return Task.CompletedTask;
    }
}
