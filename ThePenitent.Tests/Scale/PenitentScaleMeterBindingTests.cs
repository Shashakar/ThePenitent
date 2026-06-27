using Godot;
using ThePenitent.ThePenitentCode.Scale;
using Xunit;

namespace ThePenitent.Tests.Scale;

public sealed class PenitentScaleMeterBindingTests
{
    [Fact]
    public void MeterHelperIsNotAGodotObject()
    {
        Assert.False(typeof(GodotObject).IsAssignableFrom(typeof(PenitentScaleMeter)));
    }
}
