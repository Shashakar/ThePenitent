using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Models;

namespace ThePenitent.ThePenitentCode.Mechanics.Notifiers;

public abstract class PenitentNotifierBase
{
    protected static async Task NotifyListeners<TListener>(
        Creature owner,
        Func<TListener, Task> notify)
    {
        TListener[] listeners = GetListeners<TListener>(owner).ToArray();

        foreach (TListener listener in listeners)
            await notify(listener);
    }

    protected static IEnumerable<TListener> GetListeners<TListener>(Creature owner)
    {
        foreach (TListener listener in GetPowerListeners<TListener>(owner))
            yield return listener;

        foreach (TListener listener in GetRelicListeners<TListener>(owner))
            yield return listener;
    }

    private static IEnumerable<TListener> GetPowerListeners<TListener>(Creature owner)
    {
        foreach (PowerModel power in owner.Powers)
        {
            if (power is TListener listener)
                yield return listener;
        }
    }

    private static IEnumerable<TListener> GetRelicListeners<TListener>(Creature owner)
    {
        if (owner.Player is null)
            yield break;

        foreach (object relic in owner.Player.Relics)
        {
            if (relic is TListener listener)
                yield return listener;
        }
    }
}
