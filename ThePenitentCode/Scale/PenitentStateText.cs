namespace ThePenitent.ThePenitentCode.Scale;

public static class PenitentStateText
{
    private const string InactiveColorOpenTag = "[color=#8f8f8f]";
    private const string InactiveColorCloseTag = "[/color]";

    public static string Prophet(string text, PenitentScale scale, bool inCombat)
    {
        return $"{ProphetPrefix(scale, inCombat)}: {text}{ProphetSuffix(scale, inCombat)}";
    }

    public static string Heretic(string text, PenitentScale scale, bool inCombat)
    {
        return $"{HereticPrefix(scale, inCombat)}: {text}{HereticSuffix(scale, inCombat)}";
    }

    public static string Penitent(string text, PenitentScale scale, bool inCombat)
    {
        return $"{PenitentPrefix(scale, inCombat)}: {text}{PenitentSuffix(scale, inCombat)}";
    }

    public static string ProphetPrefix(PenitentScale scale, bool inCombat)
    {
        return Prefix("[gold]Prophet[/gold]", "Prophet", PenitentScaleTracker.IsProphet(scale), inCombat);
    }

    public static string ProphetSuffix(PenitentScale scale, bool inCombat)
    {
        return Suffix(PenitentScaleTracker.IsProphet(scale), inCombat);
    }

    public static string HereticPrefix(PenitentScale scale, bool inCombat)
    {
        return Prefix("[purple]Heretic[/purple]", "Heretic", PenitentScaleTracker.IsHeretic(scale), inCombat);
    }

    public static string HereticSuffix(PenitentScale scale, bool inCombat)
    {
        return Suffix(PenitentScaleTracker.IsHeretic(scale), inCombat);
    }

    public static string PenitentPrefix(PenitentScale scale, bool inCombat)
    {
        return Prefix("Penitent", "Penitent", PenitentScaleTracker.IsPenitent(scale), inCombat);
    }

    public static string PenitentSuffix(PenitentScale scale, bool inCombat)
    {
        return Suffix(PenitentScaleTracker.IsPenitent(scale), inCombat);
    }

    private static string Prefix(string activeLabel, string inactiveLabel, bool isActive, bool inCombat)
    {
        return inCombat && !isActive
            ? $"{InactiveColorOpenTag}{inactiveLabel}"
            : activeLabel;
    }

    private static string Suffix(bool isActive, bool inCombat)
    {
        return inCombat && !isActive ? InactiveColorCloseTag : "";
    }
}
