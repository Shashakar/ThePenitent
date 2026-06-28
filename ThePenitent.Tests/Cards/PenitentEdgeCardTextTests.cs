using System.Text.Json;
using Xunit;

namespace ThePenitent.Tests.Cards;

public sealed class PenitentEdgeCardTextTests
{
    private static readonly string WorkspaceRoot =
        Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../"));

    [Theory]
    [InlineData("THEPENITENT-CONFESS_CARD.description", "[gold]Ascend[/gold] {FaithPower:diff()}.\nDraw {Cards:diff()} card.\n{PenitentPrefix}: Draw 1 additional card.{PenitentSuffix}")]
    [InlineData("THEPENITENT-EMPTY_HANDS_CARD.outOfCombatDescription", "If you have no [gold]Block[/gold], [gold]Ascend[/gold] {FaithPower:diff()}.\n{PenitentPrefix}: Gain 4 [gold]Block[/gold].{PenitentSuffix}")]
    [InlineData("THEPENITENT-EMPTY_HANDS_CARD.combatDescription", "If you have 0 [gold]Block[/gold] (currently {CurrentBlock}), [gold]Ascend[/gold] {FaithPower:diff()}.\n{PenitentPrefix}: Gain 4 [gold]Block[/gold].{PenitentSuffix}")]
    [InlineData("THEPENITENT-LONE_VIGIL_CARD.description", "Gain {Block:diff()} [gold]Block[/gold].\nIf this is the first card you've played this turn, [gold]Ascend[/gold] {FaithPower:diff()}.\n{PenitentPrefix}: Draw 1 card.{PenitentSuffix}")]
    [InlineData("THEPENITENT-MARTYRS_RESOLVE_CARD.description", "Lose {HpLoss} HP.\nGain {Block:diff()} [gold]Block[/gold].\nDraw {Cards:diff()}.\n{PenitentPrefix}: Lose 1 less HP.{PenitentSuffix}")]
    [InlineData("THEPENITENT-STEADY_CONVICTION_CARD.description", "Gain {Block:diff()} [gold]Block[/gold].\n[gold]Ascend[/gold] {FaithPower:diff()}.\n{PenitentPrefix}: Gain 2 more [gold]Block[/gold].{PenitentSuffix}")]
    public void PenitentEdgeCardTextMatchesRequestedCopy(string key, string expectedText)
    {
        using JsonDocument cards = JsonDocument.Parse(ReadCardsJson());

        string actualText = cards.RootElement.GetProperty(key).GetString() ?? "";

        Assert.Equal(expectedText, actualText);
    }

    private static string ReadCardsJson()
    {
        return File.ReadAllText(Path.Combine(WorkspaceRoot, "ThePenitent/localization/eng/cards.json"));
    }
}
