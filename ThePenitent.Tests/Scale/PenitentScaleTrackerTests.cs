using ThePenitent.ThePenitentCode.Scale;
using Xunit;

namespace ThePenitent.Tests.Scale;

public sealed class PenitentScaleTrackerTests
{
    [Theory]
    [InlineData(0, 0, 0, 0, 0)]
    [InlineData(5, 0, 5, 5, 0)]
    [InlineData(0, 3, -3, 0, 3)]
    [InlineData(5, 3, 2, 2, 0)]
    [InlineData(2, 7, -5, 0, 5)]
    public void FromAmountsCollapsesFaithAndBurdenIntoOneSignedScale(
        decimal faith,
        decimal burden,
        decimal expectedValue,
        decimal expectedFaith,
        decimal expectedBurden)
    {
        PenitentScale scale = PenitentScaleTracker.FromAmounts(faith, burden);

        Assert.Equal(expectedValue, scale.Value);
        Assert.Equal(expectedFaith, scale.Faith);
        Assert.Equal(expectedBurden, scale.Burden);
    }

    [Fact]
    public void FromAmountsIgnoresNegativeInputs()
    {
        PenitentScale scale = PenitentScaleTracker.FromAmounts(-4M, -8M);

        Assert.Equal(PenitentScale.Neutral, scale);
    }
}
