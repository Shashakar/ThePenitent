using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;

namespace ThePenitent.ThePenitentCode.Powers;

public sealed class GrimCertaintyPower : ThePenitentPower
{
    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Counter;

    public override async Task AfterPowerAmountChanged(
        PowerModel power,
        decimal amount,
        Creature? applier,
        CardModel? cardSource)
    {
        if (power is not BurdenPower)
            return;

        if (power.Owner != Owner)
            return;

        if (amount <= 0)
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