using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using ThePenitent.ThePenitentCode.Powers;

namespace ThePenitent.ThePenitentCode.Relics;


public class FracturedHaloRelic() : ThePenitentRelic
{
    public override RelicRarity Rarity =>
        RelicRarity.Starter;

    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new PowerVar<FaithPower>(6M)
    ];
    
    public PowerVar<FaithPower> Faith =>
        (PowerVar<FaithPower>)DynamicVars["FaithPower"];

    
    public override async Task BeforeSideTurnStart(
        PlayerChoiceContext choiceContext,
        CombatSide side,
        CombatState combatState)
    {
        if (side != Owner.Creature.Side || combatState.RoundNumber > 1)
            return;
        Flash();
        await PowerCmd.Apply<FaithPower>(
            Owner.Creature,
            Faith.BaseValue,
            Owner.Creature,
            null
        );
    }
    
    
}