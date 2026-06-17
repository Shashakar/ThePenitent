using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.Interfaces;

namespace ThePenitent.ThePenitentCode.Relics;

public sealed class MartyrsBellRelic : ThePenitentRelic, IFaithPreventedDamageListener
{
    public override RelicRarity Rarity => RelicRarity.Uncommon;

    private bool _usedThisTurn;

    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new BlockVar(4M, ValueProp.Unpowered)
    ];

    public override Task BeforeSideTurnStart(
        PlayerChoiceContext choiceContext,
        CombatSide side,
        CombatState combatState)
    {
        if (side == Owner.Creature.Side)
            _usedThisTurn = false;

        return Task.CompletedTask;
    }

    public override bool ShowCounter => !_usedThisTurn;

    public async Task OnFaithPreventedDamage(
        PlayerChoiceContext choiceContext,
        Creature attacker,
        int preventedAmount)
    {
        if (_usedThisTurn)
            return;

        if (preventedAmount <= 0)
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
