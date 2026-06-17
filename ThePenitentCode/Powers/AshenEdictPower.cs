using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Models.Powers;
using ThePenitent.ThePenitentCode.CustomData;
using ThePenitent.ThePenitentCode.Interfaces;

namespace ThePenitent.ThePenitentCode.Powers;

public class AshenEdictPower : ThePenitentPower, IAscendListener
{
    protected virtual bool AppliesToAllEnemies => false;

    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Single;

    public async Task AfterAscend(AscendData ascendData)
    {
        if (ascendData.Owner != Owner)
            return;

        if (ascendData.CombatState is null)
            return;

        IReadOnlyList<Creature> enemies = ascendData.CombatState.HittableEnemies;
        if (enemies.Count == 0)
            return;

        Flash();

        if (AppliesToAllEnemies)
        {
            foreach (Creature enemy in enemies)
                await PowerCmd.Apply<WeakPower>(enemy, 1M, Owner, null);

            return;
        }

        if (Owner.Player is null)
            return;

        Creature? target = Owner.Player.RunState.Rng.CombatTargets.NextItem(enemies);
        if (target is null)
            return;

        await PowerCmd.Apply<WeakPower>(target, 1M, Owner, null);
    }
}
