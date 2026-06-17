using ThePenitent.ThePenitentCode.CustomData;
using ThePenitent.ThePenitentCode.Interfaces;
using ThePenitent.ThePenitentCode.Mechanics.Notifiers;

namespace ThePenitent.ThePenitentCode.Notifiers;

public sealed class BurdenCombatEndNotifier : PenitentNotifierBase
{
    private BurdenCombatEndNotifier()
    {
    }

    public static Task NotifyBeforeBurdenCombatEnd(BurdenCombatEndData burdenCombatEndData)
    {
        return NotifyListeners<IBeforeBurdenCombatEndListener>(
            burdenCombatEndData.Owner,
            listener => listener.BeforeBurdenCombatEnd(burdenCombatEndData)
        );
    }
}
