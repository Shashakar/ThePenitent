using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using ThePenitent.ThePenitentCode.CustomData;
using ThePenitent.ThePenitentCode.Interfaces;

namespace ThePenitent.ThePenitentCode.Relics;

// "Once per combat, when you Atone, do not Descend."
public class AshStainedVeilRelic : ThePenitentRelic, IBeforeAtoneDescendListener
{
    public override RelicRarity Rarity => RelicRarity.Uncommon;

    private bool _usedThisCombat;

    public override Task BeforeSideTurnStart(PlayerChoiceContext choiceContext, CombatSide side, IReadOnlyList<Creature> participants,
                                         ICombatState combatState)
    {
        if (side == Owner.Creature.Side && combatState.RoundNumber == 1)
            _usedThisCombat = false;

        return Task.CompletedTask;
    }

    public override bool ShowCounter => !_usedThisCombat;

    public Task BeforeAtoneDescend(AtoneData atoneData)
    {
        if (_usedThisCombat)
            return Task.CompletedTask;

        if (atoneData.Owner != Owner.Creature)
            return Task.CompletedTask;

        if (!atoneData.RestoredHp)
            return Task.CompletedTask;

        if (atoneData.DescendAmount <= 0)
            return Task.CompletedTask;

        Flash();

        atoneData.PreventDescend = true;
        atoneData.DescendAmount = 0;

        _usedThisCombat = true;

        return Task.CompletedTask;
    }
}