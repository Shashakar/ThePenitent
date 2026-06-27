using ThePenitent.ThePenitentCode.Scale;
using Xunit;

namespace ThePenitent.Tests.Scale;

public sealed class PenitentScaleTests
{
    [Fact]
    public void NeutralScaleHasNoFaithOrBurden()
    {
        PenitentScale scale = PenitentScale.Neutral;

        Assert.Equal(0M, scale.Value);
        Assert.Equal(0M, scale.Faith);
        Assert.Equal(0M, scale.Burden);
        Assert.False(scale.HasFaith);
        Assert.False(scale.HasBurden);
    }

    [Fact]
    public void AscendClearsBurdenBeforeCreatingFaith()
    {
        PenitentScale scale = PenitentScale.FromBurden(7M);

        PenitentScale result = scale.Ascend(10M);

        Assert.Equal(3M, result.Value);
        Assert.Equal(3M, result.Faith);
        Assert.Equal(0M, result.Burden);
        Assert.True(result.HasFaith);
        Assert.False(result.HasBurden);
    }

    [Fact]
    public void DescendClearsFaithBeforeCreatingBurden()
    {
        PenitentScale scale = PenitentScale.FromFaith(4M);

        PenitentScale result = scale.Descend(9M);

        Assert.Equal(-5M, result.Value);
        Assert.Equal(0M, result.Faith);
        Assert.Equal(5M, result.Burden);
        Assert.False(result.HasFaith);
        Assert.True(result.HasBurden);
    }

    [Fact]
    public void NonPositiveAscendAndDescendDoNotChangeScale()
    {
        PenitentScale scale = PenitentScale.FromFaith(5M);

        Assert.Equal(scale, scale.Ascend(0M));
        Assert.Equal(scale, scale.Ascend(-2M));
        Assert.Equal(scale, scale.Descend(0M));
        Assert.Equal(scale, scale.Descend(-2M));
    }
}
