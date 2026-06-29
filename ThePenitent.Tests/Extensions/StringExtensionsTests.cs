using ThePenitent.ThePenitentCode.Extensions;
using Xunit;

namespace ThePenitent.Tests.Extensions;

public sealed class StringExtensionsTests
{
    [Theory]
    [InlineData("charui/big_energy.png", "res://ThePenitent/images/charui/big_energy.png")]
    [InlineData("cards/frame.png", "res://ThePenitent/images/cards/frame.png")]
    public void ImagePathUsesGodotSeparators(string input, string expected)
    {
        Assert.Equal(expected, input.ImagePath());
    }

    [Fact]
    public void CharacterUiPathUsesGodotSeparators()
    {
        Assert.Equal(
            "res://ThePenitent/images/charui/penitent_rest_site.tscn",
            "penitent_rest_site.tscn".CharacterUiPath());
    }
}
