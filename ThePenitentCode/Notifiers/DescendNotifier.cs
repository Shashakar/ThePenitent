using ThePenitent.ThePenitentCode.CustomData;
using ThePenitent.ThePenitentCode.Interfaces;
using ThePenitent.ThePenitentCode.Mechanics.Notifiers;

namespace ThePenitent.ThePenitentCode.Notifiers;

public sealed class DescendNotifier : PenitentNotifierBase
{
    private DescendNotifier()
    {
    }

    public static Task NotifyBeforeDescend(DescendData descendData)
    {
        return NotifyListeners<IBeforeDescendListener>(
            descendData.Owner,
            listener => listener.BeforeDescend(descendData)
        );
    }
}