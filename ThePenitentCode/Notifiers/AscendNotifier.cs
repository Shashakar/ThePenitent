using ThePenitent.ThePenitentCode.CustomData;
using ThePenitent.ThePenitentCode.Interfaces;
using ThePenitent.ThePenitentCode.Mechanics.Notifiers;

namespace ThePenitent.ThePenitentCode.Notifiers;

public sealed class AscendNotifier : PenitentNotifierBase
{
    private AscendNotifier()
    {
    }

    public static Task NotifyAfterAscend(AscendData ascendData)
    {
        return NotifyListeners<IAscendListener>(
            ascendData.Owner,
            listener => listener.AfterAscend(ascendData)
        );
    }
}
