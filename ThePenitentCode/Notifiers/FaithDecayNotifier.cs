using MegaCrit.Sts2.Core.Entities.Creatures;
using ThePenitent.ThePenitentCode.Interfaces;
using ThePenitent.ThePenitentCode.Mechanics.Notifiers;

namespace ThePenitent.ThePenitentCode.Notifiers;

public sealed class FaithDecayNotifier : PenitentNotifierBase
{
    private FaithDecayNotifier()
    {
    }

    public static bool ShouldFaithDecay(Creature owner)
    {
        return GetListeners<IShouldFaithDecayListener>(owner)
            .All(listener => listener.ShouldFaithDecay());
    }
}
