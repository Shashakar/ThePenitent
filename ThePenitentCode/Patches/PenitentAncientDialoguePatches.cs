using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Ancients;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Events;
using PenitentCharacter = ThePenitent.ThePenitentCode.Character.ThePenitent;

namespace ThePenitent.ThePenitentCode.Patches;

internal static class PenitentAncientDialogue
{
    public static string CharacterEntry => ModelDb.Character<PenitentCharacter>().Id.Entry;

    public static void Register(AncientDialogueSet dialogueSet, IReadOnlyList<AncientDialogue> dialogues)
    {
        dialogueSet.CharacterDialogues[CharacterEntry] = dialogues;
    }
}

[HarmonyPatch(typeof(Darv), "DefineDialogues")]
internal static class DarvDialoguePatch
{
    public static void Postfix(AncientDialogueSet __result)
    {
        PenitentAncientDialogue.Register(__result,
        [
            new AncientDialogue("event:/sfx/npcs/darv/darv_introduction", "")
            {
                VisitIndex = 0
            },
            new AncientDialogue("event:/sfx/npcs/darv/darv_endeared")
            {
                VisitIndex = 1
            },
            new AncientDialogue("event:/sfx/npcs/darv/darv_excited", "", "event:/sfx/npcs/darv/darv_endeared")
            {
                VisitIndex = 4
            }
        ]);
    }
}

[HarmonyPatch(typeof(Neow), "DefineDialogues")]
internal static class NeowDialoguePatch
{
    public static void Postfix(AncientDialogueSet __result)
    {
        PenitentAncientDialogue.Register(__result,
        [
            new AncientDialogue("event:/sfx/npcs/neow/neow_welcome", "", "event:/sfx/npcs/neow/neow_sleepy")
            {
                VisitIndex = 0
            },
            new AncientDialogue("event:/sfx/npcs/neow/neow_curious")
            {
                VisitIndex = 1
            },
            new AncientDialogue("event:/sfx/npcs/neow/neow_sleepy", "", "event:/sfx/npcs/neow/neow_sleepy")
            {
                VisitIndex = 4
            }
        ]);
    }
}

[HarmonyPatch(typeof(Nonupeipe), "DefineDialogues")]
internal static class NonupeipeDialoguePatch
{
    public static void Postfix(AncientDialogueSet __result)
    {
        PenitentAncientDialogue.Register(__result,
        [
            new AncientDialogue("event:/sfx/npcs/nonupeipe/nonupeipe_welcome", "", "event:/sfx/npcs/nonupeipe/nonupeipe_eeked")
            {
                VisitIndex = 0
            },
            new AncientDialogue("event:/sfx/npcs/nonupeipe/nonupeipe_giggle")
            {
                VisitIndex = 1
            },
            new AncientDialogue("event:/sfx/npcs/nonupeipe/nonupeipe_eeked", "", "event:/sfx/npcs/nonupeipe/nonupeipe_grossed_out")
            {
                VisitIndex = 4
            }
        ]);
    }
}

[HarmonyPatch(typeof(Orobas), "DefineDialogues")]
internal static class OrobasDialoguePatch
{
    public static void Postfix(AncientDialogueSet __result)
    {
        PenitentAncientDialogue.Register(__result,
        [
            new AncientDialogue("", "")
            {
                VisitIndex = 0
            },
            new AncientDialogue("")
            {
                VisitIndex = 1
            },
            new AncientDialogue("", "", "")
            {
                VisitIndex = 4
            }
        ]);
    }
}

[HarmonyPatch(typeof(Pael), "DefineDialogues")]
internal static class PaelDialoguePatch
{
    public static void Postfix(AncientDialogueSet __result)
    {
        PenitentAncientDialogue.Register(__result,
        [
            new AncientDialogue("", "")
            {
                VisitIndex = 0
            },
            new AncientDialogue("")
            {
                VisitIndex = 1
            },
            new AncientDialogue("", "", "")
            {
                VisitIndex = 4
            }
        ]);
    }
}

[HarmonyPatch(typeof(Tanx), "DefineDialogues")]
internal static class TanxDialoguePatch
{
    public static void Postfix(AncientDialogueSet __result)
    {
        PenitentAncientDialogue.Register(__result,
        [
            new AncientDialogue("event:/sfx/npcs/tanx/tanx_roar", "", "event:/sfx/npcs/tanx/tanx_curiosity")
            {
                VisitIndex = 0
            },
            new AncientDialogue("event:/sfx/npcs/tanx/tanx_laugh")
            {
                VisitIndex = 1
            },
            new AncientDialogue("event:/sfx/npcs/tanx/tanx_roar", "", "event:/sfx/npcs/tanx/tanx_roar")
            {
                VisitIndex = 4
            }
        ]);
    }
}

[HarmonyPatch(typeof(Tezcatara), "DefineDialogues")]
internal static class TezcataraDialoguePatch
{
    public static void Postfix(AncientDialogueSet __result)
    {
        PenitentAncientDialogue.Register(__result,
        [
            new AncientDialogue("", "", "")
            {
                VisitIndex = 0
            },
            new AncientDialogue("")
            {
                VisitIndex = 1
            },
            new AncientDialogue("", "", "")
            {
                VisitIndex = 4
            }
        ]);
    }
}

[HarmonyPatch(typeof(Vakuu), "DefineDialogues")]
internal static class VakuuDialoguePatch
{
    public static void Postfix(AncientDialogueSet __result)
    {
        PenitentAncientDialogue.Register(__result,
        [
            new AncientDialogue("", "", "")
            {
                VisitIndex = 0
            },
            new AncientDialogue("")
            {
                VisitIndex = 1
            },
            new AncientDialogue("", "", "")
            {
                VisitIndex = 4
            }
        ]);
    }
}

[HarmonyPatch(typeof(TheArchitect), "DefineDialogues")]
internal static class TheArchitectDialoguePatch
{
    public static void Postfix(AncientDialogueSet __result)
    {
        PenitentAncientDialogue.Register(__result,
        [
            new AncientDialogue("", "")
            {
                VisitIndex = 0,
                EndAttackers = ArchitectAttackers.Both
            },
            new AncientDialogue("", "", "")
            {
                VisitIndex = 1,
                EndAttackers = ArchitectAttackers.Both
            },
            new AncientDialogue("", "", "")
            {
                VisitIndex = 2,
                EndAttackers = ArchitectAttackers.Both
            },
            new AncientDialogue("", "", "")
            {
                VisitIndex = 3,
                StartAttackers = ArchitectAttackers.Player,
                EndAttackers = ArchitectAttackers.Architect
            }
        ]);
    }
}
