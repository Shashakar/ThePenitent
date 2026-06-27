using ThePenitent.ThePenitentCode.Powers;
using Xunit;

namespace ThePenitent.Tests.Scale;

public sealed class PenitentScalePowerVisibilityTests
{
    [Fact]
    public void FaithPowerIsHiddenFromPowerDisplay()
    {
        Assert.False(new FaithPower().IsVisible);
    }

    [Fact]
    public void BurdenPowerIsHiddenFromPowerDisplay()
    {
        Assert.False(new BurdenPower().IsVisible);
    }
}
