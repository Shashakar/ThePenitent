using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.Scale;

namespace ThePenitent.ThePenitentCode.Relics;

public sealed class MartyrsBellRelic : ThePenitentRelic
{
    public override RelicRarity Rarity => RelicRarity.Uncommon;

    private bool _usedThisTurn;

    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new BlockVar(4M, ValueProp.Unpowered)
    ];

    public override Task BeforeSideTurnStart(PlayerChoiceContext choiceContext, CombatSide side, IReadOnlyList<Creature> participants,
        ICombatState combatState)
    {
        if (side == Owner.Creature.Side)
            _usedThisTurn = false;

        return Task.CompletedTask;
    }

    public override bool ShowCounter => !_usedThisTurn;

    public override async Task AfterDamageReceived(
        PlayerChoiceContext choiceContext,
        Creature target,
        DamageResult result,
        ValueProp props,
        Creature? attacker,
        CardModel? cardSource)
    {
        if (_usedThisTurn)
            return;

        if (target != Owner.Creature)
            return;

        if (attacker is null || attacker == Owner.Creature)
            return;

        if (!PenitentScaleTracker.HasFaith(Owner.Creature))
            return;

        Flash();
        _usedThisTurn = true;

        await CreatureCmd.GainBlock(
            Owner.Creature,
            DynamicVars.Block.BaseValue,
            ValueProp.Unpowered,
            null
        );
    }
}
