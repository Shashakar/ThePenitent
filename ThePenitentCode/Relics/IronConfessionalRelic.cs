using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using ThePenitent.ThePenitentCode.CustomData;
using ThePenitent.ThePenitentCode.Interfaces;

namespace ThePenitent.ThePenitentCode.Relics;

public sealed class IronConfessionalRelic : ThePenitentRelic, IBeforeDescendListener
{
    public override RelicRarity Rarity => RelicRarity.Common;

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

        if (descendData.Amount <= 0)
            return Task.CompletedTask;

        Flash();
        descendData.Amount = Math.Max(0M, descendData.Amount - 2M);
        _usedThisCombat = true;

        return Task.CompletedTask;
    }
}
