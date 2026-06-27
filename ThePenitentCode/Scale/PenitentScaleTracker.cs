using MegaCrit.Sts2.Core.Entities.Creatures;
using ThePenitent.ThePenitentCode.Powers;

namespace ThePenitent.ThePenitentCode.Scale;

public static class PenitentScaleTracker
{
    public static PenitentScale FromAmounts(decimal faith, decimal burden)
    {
        decimal normalizedFaith = Math.Max(0M, faith);
        decimal normalizedBurden = Math.Max(0M, burden);

        return new PenitentScale(normalizedFaith - normalizedBurden);
    }

    public static PenitentScale Get(Creature creature)
    {
        return FromAmounts(
            creature.GetPowerAmount<FaithPower>(),
            creature.GetPowerAmount<BurdenPower>()
        );
    }

    public static decimal FaithAmount(Creature creature)
    {
        return Get(creature).Faith;
    }

    public static decimal BurdenAmount(Creature creature)
    {
        return Get(creature).Burden;
    }

    public static bool HasFaith(Creature creature)
    {
        return Get(creature).HasFaith;
    }

    public static bool HasBurden(Creature creature)
    {
        return Get(creature).HasBurden;
    }
}
