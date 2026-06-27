using ThePenitent.ThePenitentCode.Scale;
using Xunit;

namespace ThePenitent.Tests.Scale;

public sealed class PenitentScaleMeterRegistryTests
{
    [Fact]
    public void SetScaleStoresCurrentScaleForMetersThatRegisterLater()
    {
        var scale = new PenitentScale(10M);

        PenitentScaleMeterRegistry.SetScale(scale);

        Assert.Equal(scale, PenitentScaleMeterRegistry.CurrentScale);
    }
}
