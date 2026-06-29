using MegaCrit.Sts2.Core.Models;
using PenitentCharacter = ThePenitent.ThePenitentCode.Character.ThePenitent;

namespace ThePenitent.ThePenitentCode.Patches;

public static class PenitentMerchantVisualPath
{
    public const string MerchantScenePath = "res://ThePenitent/images/charui/penitent_merchant.tscn";
    public const float OverlayScale = 0.75f;
    public const int OverlayRootZIndex = 0;
    public const int OverlayMaxZIndex = 0;

    public static string For(CharacterModel character, string fallbackPath)
    {
        return character is PenitentCharacter
            ? MerchantScenePath
            : fallbackPath;
    }
}
