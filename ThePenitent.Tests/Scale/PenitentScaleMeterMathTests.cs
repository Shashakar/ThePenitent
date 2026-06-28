using ThePenitent.ThePenitentCode.Scale;
using Xunit;

namespace ThePenitent.Tests.Scale;

public sealed class PenitentScaleMeterMathTests
{
    [Theory]
    [InlineData(-10, -100)]
    [InlineData(-5, -50)]
    [InlineData(0, 0)]
    [InlineData(5, 50)]
    [InlineData(10, 100)]
    [InlineData(15, 100)]
    [InlineData(-15, -100)]
    public void ValueToMarkerXMapsSignedScaleToClampedTrackPosition(decimal value, float expectedX)
    {
        float markerX = PenitentScaleMeterMath.ValueToMarkerX(new PenitentScale(value));

        Assert.Equal(expectedX, markerX);
    }

    [Theory]
    [InlineData(-12, "-12")]
    [InlineData(-1, "-1")]
    [InlineData(0, "0")]
    [InlineData(1, "+1")]
    [InlineData(12, "+12")]
    public void ValueToLabelTextFormatsSignedScale(decimal value, string expectedText)
    {
        string labelText = PenitentScaleMeterMath.ValueToLabelText(new PenitentScale(value));

        Assert.Equal(expectedText, labelText);
    }

    [Theory]
    [InlineData(-1, PenitentScaleMeterTone.Burden)]
    [InlineData(0, PenitentScaleMeterTone.Neutral)]
    [InlineData(1, PenitentScaleMeterTone.Faith)]
    public void ValueToToneMapsScaleSign(decimal value, PenitentScaleMeterTone expectedTone)
    {
        PenitentScaleMeterTone tone = PenitentScaleMeterMath.ValueToTone(new PenitentScale(value));

        Assert.Equal(expectedTone, tone);
    }

    [Theory]
    [InlineData(-6, "Heretic")]
    [InlineData(-5, "Penitent")]
    [InlineData(0, "Penitent")]
    [InlineData(5, "Penitent")]
    [InlineData(6, "Prophet")]
    public void ValueToStanceTextMapsThresholdState(decimal value, string expectedText)
    {
        string stanceText = PenitentScaleMeterMath.ValueToStanceText(new PenitentScale(value));

        Assert.Equal(expectedText, stanceText);
    }

    [Theory]
    [InlineData(-6, PenitentScaleMeterTone.Burden)]
    [InlineData(0, PenitentScaleMeterTone.Neutral)]
    [InlineData(6, PenitentScaleMeterTone.Faith)]
    public void ValueToStanceToneMapsThresholdState(decimal value, PenitentScaleMeterTone expectedTone)
    {
        PenitentScaleMeterTone tone = PenitentScaleMeterMath.ValueToStanceTone(new PenitentScale(value));

        Assert.Equal(expectedTone, tone);
    }
}
