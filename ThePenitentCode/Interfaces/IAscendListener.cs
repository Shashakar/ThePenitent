using ThePenitent.ThePenitentCode.CustomData;

namespace ThePenitent.ThePenitentCode.Interfaces;

public interface IAscendListener
{
    Task AfterAscend(AscendData ascendData);
}
