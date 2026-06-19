using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.Interfaces;

namespace ThePenitent.ThePenitentCode.Relics;

public class ThornedRosaryRelic() : ThePenitentRelic, ICreatedBurdenListener
{
    public override RelicRarity Rarity =>
        RelicRarity.Uncommon;

    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new DamageVar(1M, ValueProp.Unpowered)
    ];
    
    public async Task OnCreatedBurden(Creature owner, decimal descendAmount, decimal burdenCreated, Creature? source,
        CardModel? cardSource, ICombatState? combatState)
    {
        if (owner != Owner.Creature)
            return;

        if (burdenCreated <= 0)
            return;

        if (combatState == null)
            return;

        Flash();
        
        await CreatureCmd.Damage(
            new ThrowingPlayerChoiceContext(),
            combatState.GetOpponentsOf(Owner.Creature),
            DynamicVars.Damage.BaseValue,
            ValueProp.Unpowered,
            Owner.Creature,
            null
        );
    }
    
}
