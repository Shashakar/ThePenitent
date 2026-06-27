using MegaCrit.Sts2.Core.Entities.Creatures;

namespace ThePenitent.ThePenitentCode.Scale;

public static class PenitentScaleMeterRegistry
{
    private static Action<PenitentScale> ApplyScaleToActiveMeters { get; set; } = _ => { };

    public static PenitentScale CurrentScale { get; private set; } = PenitentScale.Neutral;

    public static void EnableSceneUpdates(Action<PenitentScale> applyScaleToActiveMeters)
    {
        ApplyScaleToActiveMeters = applyScaleToActiveMeters;
        ApplyScaleToActiveMeters(CurrentScale);
    }

    public static void Update(Creature owner)
    {
        SetScale(PenitentScaleTracker.Get(owner));
    }

    public static void SetScale(PenitentScale scale)
    {
        CurrentScale = scale;
        ApplyScaleToActiveMeters(scale);
    }
}
