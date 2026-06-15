using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using ThePenitent.ThePenitentCode.Interfaces;

namespace ThePenitent.ThePenitentCode.Relics;

public class ThornedRosaryRelic() : ThePenitentRelic, ICreatedBurdenListener
{
    public override RelicRarity Rarity =>
        RelicRarity.Uncommon;

    private decimal damageAmount = 1;
    
    public async Task OnCreatedBurden(Creature owner, decimal descendAmount, decimal burdenCreated, Creature? source,
        CardModel? cardSource, CombatState? combatState)
    {
        if (owner != Owner.Creature)
            return;

        if (burdenCreated <= 0)
            return;

        if (combatState == null)
            return;

        Flash();
        
        // hit all enemies
        await DamageCmd.Attack(damageAmount)
            .FromCard(null)
            .TargetingAllOpponents(combatState)
            .Execute(new ThrowingPlayerChoiceContext());
    }
    
}