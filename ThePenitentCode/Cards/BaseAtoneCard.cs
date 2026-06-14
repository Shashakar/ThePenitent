using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using ThePenitent.ThePenitentCode.HoverTips;

namespace ThePenitent.ThePenitentCode.Cards;

public abstract class BaseAtoneCard : ThePenitentMechanicCard
{
    private readonly decimal _upgradeHealAmount;

    protected BaseAtoneCard(
        int cost,
        CardType type,
        CardRarity rarity,
        TargetType target,
        decimal healAmount,
        decimal upgradeHealAmount = 0M,
        IEnumerable<CardKeyword>? keywords = null,
        IEnumerable<IHoverTip>? extraHoverTips = null)
        : base(
            cost: cost,
            type: type,
            rarity: rarity,
            target: target,
            healAmount: healAmount,
            keywords: keywords,
            extraHoverTips: BuildHoverTips(extraHoverTips)
        )
    {
        _upgradeHealAmount = upgradeHealAmount;
    }

    private static IEnumerable<IHoverTip> BuildHoverTips(IEnumerable<IHoverTip>? extraHoverTips)
    {
        yield return PenitentHoverTipFactory.Atone();

        if (extraHoverTips is null)
            yield break;

        foreach (IHoverTip hoverTip in extraHoverTips)
            yield return hoverTip;
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await AtoneTarget(cardPlay);
    }

    protected override void OnUpgrade()
    {
        if (_upgradeHealAmount != 0M)
            Heal.UpgradeValueBy(_upgradeHealAmount);
    }
}