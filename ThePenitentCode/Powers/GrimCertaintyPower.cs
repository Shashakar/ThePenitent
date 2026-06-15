using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.Interfaces;

namespace ThePenitent.ThePenitentCode.Powers;

public sealed class GrimCertaintyPower : ThePenitentPower, ICreatedBurdenListener
{
    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Counter;

    public async Task OnCreatedBurden(Creature owner, decimal descendAmount, decimal burdenCreated, Creature? source,
        CardModel? cardSource, CombatState? combatState)
    {
        if (owner != Owner)
            return;

        if (burdenCreated <= 0)
            return;
        
        IReadOnlyList<Creature> hittableEnemies = CombatState.HittableEnemies;
        if (hittableEnemies.Count == 0)
            return;

        Flash();

        Creature target = Owner.Player.RunState.Rng.CombatTargets.NextItem(hittableEnemies);

        await CreatureCmd.Damage(
            new ThrowingPlayerChoiceContext(),
            target,
            Amount,
            ValueProp.Unpowered,
            Owner,
            null
        );
    }
}