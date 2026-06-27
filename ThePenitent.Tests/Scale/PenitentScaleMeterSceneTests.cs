namespace ThePenitent.Tests.Scale;

using Xunit;

public sealed class PenitentScaleMeterSceneTests
{
    private static readonly string WorkspaceRoot =
        Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../"));

    [Fact]
    public void EnergyCounterUsesLabeledScaleMeter()
    {
        string scene = ReadScene("ThePenitent/images/charui/penitent_energy_counter.tscn");

        Assert.Contains("penitent_scale_meter.tscn", scene);
        Assert.Contains("[node name=\"PenitentScaleMeter\" parent=\".\" instance=ExtResource", scene);
    }

    [Fact]
    public void PenitentCharacterUsesOverheadScaleMeter()
    {
        string scene = ReadScene("ThePenitent/images/charui/penitent.tscn");

        Assert.Contains("penitent_scale_meter_overhead.tscn", scene);
    }

    [Fact]
    public void OverheadScaleMeterDoesNotHaveValueLabel()
    {
        string scene = ReadScene("ThePenitent/images/charui/penitent_scale_meter_overhead.tscn");

        Assert.DoesNotContain("ValueLabel", scene);
    }

    [Fact]
    public void MainScaleMeterKeepsValueLabel()
    {
        string scene = ReadScene("ThePenitent/images/charui/penitent_scale_meter.tscn");

        Assert.Contains("ValueLabel", scene);
    }

    private static string ReadScene(string relativePath)
    {
        return File.ReadAllText(Path.Combine(WorkspaceRoot, relativePath));
    }
}
