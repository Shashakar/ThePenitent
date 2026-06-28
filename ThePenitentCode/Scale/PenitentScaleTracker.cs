using MegaCrit.Sts2.Core.Entities.Creatures;
using ThePenitent.ThePenitentCode.Powers;

namespace ThePenitent.ThePenitentCode.Scale;

public enum PenitentScaleState
{
    Heretic,
    Penitent,
    Prophet
}

public static class PenitentScaleTracker
{
    public const int StateThreshold = 6;

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

    public static PenitentScaleState State(PenitentScale scale)
    {
        if (IsProphet(scale))
            return PenitentScaleState.Prophet;

        return IsHeretic(scale)
            ? PenitentScaleState.Heretic
            : PenitentScaleState.Penitent;
    }

    public static bool IsProphet(PenitentScale scale)
    {
        return scale.Faith >= StateThreshold;
    }

    public static bool IsProphet(Creature creature)
    {
        return IsProphet(Get(creature));
    }

    public static bool IsHeretic(PenitentScale scale)
    {
        return scale.Burden >= StateThreshold;
    }

    public static bool IsHeretic(Creature creature)
    {
        return IsHeretic(Get(creature));
    }

    public static bool IsPenitent(PenitentScale scale)
    {
        return State(scale) == PenitentScaleState.Penitent;
    }

    public static bool IsPenitent(Creature creature)
    {
        return IsPenitent(Get(creature));
    }
}
