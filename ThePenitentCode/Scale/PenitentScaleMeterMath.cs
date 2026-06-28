namespace ThePenitent.ThePenitentCode.Scale;

public enum PenitentScaleMeterTone
{
    Burden,
    Neutral,
    Faith
}

public static class PenitentScaleMeterMath
{
    public const decimal MaxDisplayedMagnitude = 10M;
    public const float TrackHalfWidth = 100F;

    public static float ValueToMarkerX(PenitentScale scale)
    {
        decimal clamped = Math.Clamp(scale.Value, -MaxDisplayedMagnitude, MaxDisplayedMagnitude);
        decimal normalized = clamped / MaxDisplayedMagnitude;

        return (float)(normalized * (decimal)TrackHalfWidth);
    }

    public static string ValueToLabelText(PenitentScale scale)
    {
        if (scale.Value > 0M)
            return $"+{scale.Value:0}";

        return $"{scale.Value:0}";
    }

    public static PenitentScaleMeterTone ValueToTone(PenitentScale scale)
    {
        if (scale.Value < 0M)
            return PenitentScaleMeterTone.Burden;

        return scale.Value > 0M
            ? PenitentScaleMeterTone.Faith
            : PenitentScaleMeterTone.Neutral;
    }

    public static string ValueToStanceText(PenitentScale scale)
    {
        return PenitentScaleTracker.State(scale) switch
        {
            PenitentScaleState.Heretic => "Heretic",
            PenitentScaleState.Prophet => "Prophet",
            _ => "Penitent"
        };
    }

    public static PenitentScaleMeterTone ValueToStanceTone(PenitentScale scale)
    {
        return PenitentScaleTracker.State(scale) switch
        {
            PenitentScaleState.Heretic => PenitentScaleMeterTone.Burden,
            PenitentScaleState.Prophet => PenitentScaleMeterTone.Faith,
            _ => PenitentScaleMeterTone.Neutral
        };
    }
}
