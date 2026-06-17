using ThePenitent.ThePenitentCode.CustomData;

namespace ThePenitent.ThePenitentCode.Interfaces;

public interface IBeforeAtoneListener
{
    Task BeforeAtone(AtoneData atoneData);
}

public interface IBeforeAtoneDescendListener
{
    Task BeforeAtoneDescend(AtoneData atoneData);
}

public interface IAfterAtoneListener
{
    Task AfterAtone(AtoneData atoneData);
}