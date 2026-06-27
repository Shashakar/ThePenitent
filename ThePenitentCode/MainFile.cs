using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Modding;
using ThePenitent.ThePenitentCode.Scale;

namespace ThePenitent.ThePenitentCode;

[ModInitializer(nameof(Initialize))]
public partial class MainFile : Node
{
    public const string ModId = "ThePenitent"; //Used for resource filepath
    public const string ResPath = $"res://{ModId}";

    public static MegaCrit.Sts2.Core.Logging.Logger Logger { get; } =
        new(ModId, MegaCrit.Sts2.Core.Logging.LogType.Generic);

    public static void Initialize()
    {
        PenitentScaleMeterRegistry.EnableSceneUpdates(PenitentScaleMeter.ApplyToActiveMeters);

        Harmony harmony = new(ModId);

        harmony.PatchAll();
    }
}
