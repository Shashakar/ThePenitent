using ThePenitent.ThePenitentCode.Scale;
using Xunit;

namespace ThePenitent.Tests.Scale;

public sealed class PenitentStateTextTests
{
    [Fact]
    public void ProphetLineUsesNormalFormattingOutOfCombatEvenWhenInactive()
    {
        string line = PenitentStateText.Prophet("Deal 8 more damage.", new PenitentScale(0), inCombat: false);

        Assert.Equal("[gold]Prophet[/gold]: Deal 8 more damage.", line);
    }

    [Fact]
    public void ProphetLineUsesNormalFormattingInCombatWhenActive()
    {
        string line = PenitentStateText.Prophet("Deal 8 more damage.", new PenitentScale(6), inCombat: true);

        Assert.Equal("[gold]Prophet[/gold]: Deal 8 more damage.", line);
    }

    [Fact]
    public void ProphetLineGreysInCombatWhenInactive()
    {
        string line = PenitentStateText.Prophet("Deal 8 more damage.", new PenitentScale(0), inCombat: true);

        Assert.Equal("[color=#8f8f8f]Prophet: Deal 8 more damage.[/color]", line);
    }

    [Fact]
    public void HereticLineGreysInCombatWhenInactive()
    {
        string line = PenitentStateText.Heretic("Apply 1 additional [blue]Weak[/blue].", new PenitentScale(0), inCombat: true);

        Assert.Equal("[color=#8f8f8f]Heretic: Apply 1 additional [blue]Weak[/blue].[/color]", line);
    }

    [Fact]
    public void PenitentLineGreysInCombatWhenInactive()
    {
        string line = PenitentStateText.Penitent("Do the quiet middle thing.", new PenitentScale(6), inCombat: true);

        Assert.Equal("[color=#8f8f8f]Penitent: Do the quiet middle thing.[/color]", line);
    }
}
