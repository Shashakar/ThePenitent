using ThePenitent.ThePenitentCode.CustomData;
using ThePenitent.ThePenitentCode.Interfaces;
using ThePenitent.ThePenitentCode.Mechanics.Notifiers;

namespace ThePenitent.ThePenitentCode.Notifiers;

public sealed class AtoneNotifier : PenitentNotifierBase
{
    private AtoneNotifier()
    {
    }

    public static Task NotifyBeforeAtone(AtoneData atoneData)
    {
        return NotifyListeners<IBeforeAtoneListener>(
            atoneData.Owner,
            listener => listener.BeforeAtone(atoneData)
        );
    }

    public static Task NotifyBeforeAtoneDescend(AtoneData atoneData)
    {
        return NotifyListeners<IBeforeAtoneDescendListener>(
            atoneData.Owner,
            listener => listener.BeforeAtoneDescend(atoneData)
        );
    }

    public static Task NotifyAfterAtone(AtoneData atoneData)
    {
        return NotifyListeners<IAfterAtoneListener>(
            atoneData.Owner,
            listener => listener.AfterAtone(atoneData)
        );
    }
}