using PenitentCharacter = ThePenitent.ThePenitentCode.Character.ThePenitent;
using ThePenitent.ThePenitentCode.Patches;

namespace ThePenitent.Tests.Character;

using Xunit;

public sealed class PenitentVisualSceneTests
{
    private static readonly string WorkspaceRoot =
        Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../"));

    [Fact]
    public void CharacterUsesPenitentRestSiteVisual()
    {
        var character = new PenitentCharacter();

        Assert.Equal(
            "res://ThePenitent/images/charui/penitent_rest_site.tscn",
            character.CustomRestSiteAnimPath);
    }

    [Fact]
    public void CharacterUsesPenitentMerchantVisual()
    {
        var character = new PenitentCharacter();

        Assert.Equal(
            "res://ThePenitent/images/charui/penitent_merchant.tscn",
            PenitentMerchantVisualPath.For(character, "res://vanilla/merchant.tscn"));
    }

    [Fact]
    public void PenitentMerchantSceneUsesMerchantRoot()
    {
        string scene = ReadScene("ThePenitent/images/charui/penitent_merchant.tscn");

        Assert.Contains("PenitentMerchantCharacter.cs", scene);
        Assert.Contains("[node name=\"PenitentMerchant\" type=\"Node2D\"]", scene);
    }

    [Fact]
    public void PenitentMerchantOverlayUsesMerchantScale()
    {
        Assert.Equal(0.75f, PenitentMerchantVisualPath.OverlayScale);

        string scene = ReadScene("ThePenitent/images/charui/penitent_merchant.tscn");

        Assert.Contains("scale = Vector2(0.75, 0.75)", scene);
    }

    [Fact]
    public void PenitentMerchantOverlayUsesBackgroundZOrder()
    {
        Assert.Equal(0, PenitentMerchantVisualPath.OverlayRootZIndex);
        Assert.Equal(0, PenitentMerchantVisualPath.OverlayMaxZIndex);
    }

    [Fact]
    public void PenitentMerchantSceneUsesHeldBookWithoutCombatAnimation()
    {
        string scene = ReadScene("ThePenitent/images/charui/penitent_merchant.tscn");

        Assert.Contains("[node name=\"BookPivot\" type=\"Node2D\" parent=\"Visuals/Body/RightArmPivot\"]", scene);
        Assert.Contains("[node name=\"Book\" type=\"Sprite2D\" parent=\"Visuals/Body/RightArmPivot/BookPivot\"]", scene);
        Assert.DoesNotContain("SeparateBook", scene);
        Assert.DoesNotContain("AnimationPlayer", scene);
        Assert.DoesNotContain("AnimationTree", scene);
    }

    [Fact]
    public void CharacterIsEligibleForVanillaRandomSelect()
    {
        var character = new PenitentCharacter();

        Assert.True(character.AllowInVanillaRandomCharacterSelect);
    }

    [Fact]
    public void RestSiteSceneReusesPenitentVisual()
    {
        string scene = ReadScene("ThePenitent/images/charui/penitent_rest_site.tscn");

        Assert.Contains("PenitentRestSite", scene);
        Assert.Contains("PenitentVisual.tscn", scene);
        Assert.Contains("[node name=\"Visuals\" parent=\".\" instance=ExtResource", scene);
    }

    private static string ReadScene(string relativePath)
    {
        return File.ReadAllText(Path.Combine(WorkspaceRoot, relativePath));
    }
}
