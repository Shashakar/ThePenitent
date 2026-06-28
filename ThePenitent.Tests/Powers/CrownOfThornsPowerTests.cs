using ThePenitent.ThePenitentCode.Powers;
using Xunit;

namespace ThePenitent.Tests.Powers;

public sealed class CrownOfThornsPowerTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0)]
    [InlineData(2, 1)]
    [InlineData(7, 3)]
    [InlineData(8, 4)]
    public void BurdenToConsumeForBlockIsHalfRoundedDown(decimal burden, decimal expectedConsumed)
    {
        decimal consumed = CrownOfThornsPower.BurdenToConsumeForBlock(burden);

        Assert.Equal(expectedConsumed, consumed);
    }
}
