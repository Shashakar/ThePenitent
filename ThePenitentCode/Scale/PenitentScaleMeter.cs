using Godot;

namespace ThePenitent.ThePenitentCode.Scale;

public static class PenitentScaleMeter
{
    private const string MeterNodeName = "PenitentScaleMeter";
    private const string MarkerNodePath = "MarkerPivot";
    private const string ValueLabelNodePath = "MarkerPivot/ValueLabel";
    private const string StanceLabelNodePath = "CurrentStance";

    private static readonly Color BurdenColor = new(0.56F, 0.40F, 0.78F, 1F);
    private static readonly Color NeutralColor = new(0.78F, 0.78F, 0.72F, 1F);
    private static readonly Color FaithColor = new(0.96F, 0.92F, 0.62F, 1F);

    public static void ApplyToActiveMeters(PenitentScale scale)
    {
        if (Engine.GetMainLoop() is not SceneTree sceneTree)
            return;

        ApplyRecursive(sceneTree.Root, scale);
    }

    private static void ApplyRecursive(Node node, PenitentScale scale)
    {
        if (node.Name == MeterNodeName)
            ApplyToMeter(node, scale);

        foreach (Node child in node.GetChildren())
            ApplyRecursive(child, scale);
    }

    private static void ApplyToMeter(Node meter, PenitentScale scale)
    {
        Node2D? marker = meter.GetNodeOrNull<Node2D>(MarkerNodePath);
        if (marker is null)
            return;

        marker.Position = new Vector2(
            PenitentScaleMeterMath.ValueToMarkerX(scale),
            marker.Position.Y
        );

        Label? valueLabel = meter.GetNodeOrNull<Label>(ValueLabelNodePath);
        if (valueLabel is null)
            return;

        valueLabel.Text = PenitentScaleMeterMath.ValueToLabelText(scale);
        valueLabel.AddThemeColorOverride("font_color", ToneToColor(PenitentScaleMeterMath.ValueToTone(scale)));

        Label? stanceLabel = meter.GetNodeOrNull<Label>(StanceLabelNodePath);
        if (stanceLabel is null)
            return;

        stanceLabel.Text = PenitentScaleMeterMath.ValueToStanceText(scale);
        stanceLabel.AddThemeColorOverride("font_color", ToneToColor(PenitentScaleMeterMath.ValueToStanceTone(scale)));
    }

    private static Color ToneToColor(PenitentScaleMeterTone tone)
    {
        return tone switch
        {
            PenitentScaleMeterTone.Burden => BurdenColor,
            PenitentScaleMeterTone.Faith => FaithColor,
            _ => NeutralColor
        };
    }
}
