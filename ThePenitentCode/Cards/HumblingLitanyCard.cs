using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;

namespace ThePenitent.ThePenitentCode.Cards;

public sealed class HumblingLitanyCard() :
    ThePenitentMechanicCard
    (
        cost: 1,
        type: CardType.Skill,
        rarity: CardRarity.Uncommon,
        target: TargetType.AnyEnemy,
        keywords: [CardKeyword.Exhaust],
        extraHoverTips: [HoverTipFactory.FromPower<StrengthPower>()]
    )
{
    private const string StrengthLossKey = "StrengthLoss";

    protected override IEnumerable<DynamicVar> AdditionalCanonicalVars =>
    [
        new DynamicVar(StrengthLossKey, 2M),
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplyTemporaryStrengthLoss(cardPlay, DynamicVars[StrengthLossKey].BaseValue);
    }

    protected override void OnUpgrade()
    {
        DynamicVars[StrengthLossKey].UpgradeValueBy(1M);
    }
}
