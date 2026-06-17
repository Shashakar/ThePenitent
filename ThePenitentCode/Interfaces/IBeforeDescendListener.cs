using ThePenitent.ThePenitentCode.CustomData;

namespace ThePenitent.ThePenitentCode.Interfaces;

public interface IBeforeDescendListener
{
    Task BeforeDescend(DescendData descendData);
}