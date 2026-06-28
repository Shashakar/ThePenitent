using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization;

namespace ThePenitent.ThePenitentCode.HoverTips;

public static class PenitentHoverTipFactory
{
    public static IHoverTip Ascend() => Static("ASCEND");
    public static IHoverTip Descend() => Static("DESCEND");
    public static IHoverTip Atone() => Static("ATONE");
    public static IHoverTip Faith() => Static("FAITH");
    public static IHoverTip Burden() => Static("BURDEN");
    public static IHoverTip Prophet() => Static("PROPHET");
    public static IHoverTip Penitent() => Static("PENITENT");
    public static IHoverTip Heretic() => Static("HERETIC");

    public static IHoverTip Static(string key)
    {
        return new HoverTip(
            new LocString("static_hover_tips", $"{key}.title"),
            new LocString("static_hover_tips", $"{key}.description")
        );
    }
}
