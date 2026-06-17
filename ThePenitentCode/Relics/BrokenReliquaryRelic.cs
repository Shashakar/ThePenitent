using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using ThePenitent.ThePenitentCode.Commands;
using ThePenitent.ThePenitentCode.Powers;

namespace ThePenitent.ThePenitentCode.Relics;

public sealed class BrokenReliquaryRelic : ThePenitentRelic
{
    public override RelicRarity Rarity => RelicRarity.Rare;

    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new EnergyVar(1),
        new PowerVar<BurdenPower>(6M)
    ];

    public override async Task BeforeSideTurnStart(
        PlayerChoiceContext choiceContext,
        CombatSide side,
        CombatState combatState)
    {
        if (side != Owner.Creature.Side || combatState.RoundNumber > 1)
            return;

        Flash();

        await PenitentPowerCmd.ApplyBurden(
            Owner.Creature,
            Burden.BaseValue,
            Owner.Creature,
            null,
            combatState
        );
    }

    public override async Task AfterEnergyReset(Player player)
    {
        if (player != Owner)
            return;

        Flash();
        await PlayerCmd.GainEnergy(DynamicVars.Energy.BaseValue, Owner);
    }
}
