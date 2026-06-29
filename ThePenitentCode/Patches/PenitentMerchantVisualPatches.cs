using HarmonyLib;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Nodes.Screens.Shops;
using ThePenitent.ThePenitentCode.Nodes;

namespace ThePenitent.ThePenitentCode.Patches;

[HarmonyPatch(typeof(CharacterModel), "get_MerchantAnimPath")]
internal static class PenitentMerchantAnimPathPatch
{
    public static void Postfix(CharacterModel __instance, ref string __result)
    {
        __result = PenitentMerchantVisualPath.For(__instance, __result);
    }
}

[HarmonyPatch(typeof(NMerchantCharacter), nameof(NMerchantCharacter.PlayAnimation))]
internal static class PenitentMerchantPlayAnimationPatch
{
    public static bool Prefix(NMerchantCharacter __instance)
        => __instance is not PenitentMerchantCharacter;
}
