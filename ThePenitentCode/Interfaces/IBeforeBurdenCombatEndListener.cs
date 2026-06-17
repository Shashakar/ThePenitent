using ThePenitent.ThePenitentCode.CustomData;

namespace ThePenitent.ThePenitentCode.Interfaces;

public interface IBeforeBurdenCombatEndListener
{
    Task BeforeBurdenCombatEnd(BurdenCombatEndData burdenCombatEndData);
}
