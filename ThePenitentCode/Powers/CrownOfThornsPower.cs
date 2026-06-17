using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.Interfaces;

namespace ThePenitent.ThePenitentCode.Powers;

public class CrownOfThornsPower : ThePenitentPower, ICreatedBurdenListener
{
    private bool _hasTriggered;

    protected virtual bool DealsDamage => false;

    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Single;

    public async Task OnCreatedBurden(
        Creature owner,
        decimal descendAmount,
        decimal burdenCreated,
        Creature? source,
        CardModel? cardSource,
        MegaCrit.Sts2.Core.Combat.CombatState? combatState)
    {
        if (owner != Owner)
            return;

        if (_hasTriggered || burdenCreated <= 0)
            return;

        _hasTriggered = true;
        Flash();

        await CreatureCmd.GainBlock(Owner, burdenCreated, default, null);

        if (!DealsDamage || combatState is null || Owner.Player is null)
            return;

        IReadOnlyList<Creature> enemies = combatState.HittableEnemies;
        if (enemies.Count == 0)
            return;

        Creature? target = Owner.Player.RunState.Rng.CombatTargets.NextItem(enemies);
        if (target is null)
            return;

        await CreatureCmd.Damage(
            new ThrowingPlayerChoiceContext(),
            target,
            burdenCreated,
            ValueProp.Unpowered,
            Owner,
            null
        );
    }
}
