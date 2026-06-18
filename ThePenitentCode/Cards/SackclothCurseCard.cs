using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;

namespace ThePenitent.ThePenitentCode.Cards;

public sealed class SackclothCurseCard() :
    ThePenitentMechanicCard
    (
        cost: 1,
        type: CardType.Skill,
        rarity: CardRarity.Rare,
        target: TargetType.AnyEnemy,
        keywords: [CardKeyword.Exhaust],
        extraHoverTips:
        [
            HoverTipFactory.FromPower<WeakPower>(),
            HoverTipFactory.FromPower<FrailPower>()
        ]
    )
{
    protected override IEnumerable<DynamicVar> AdditionalCanonicalVars =>
    [
        new PowerVar<WeakPower>(2M),
        new PowerVar<FrailPower>(1M),
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplyWeak(cardPlay, DynamicVars.Weak.BaseValue);
        await ApplyFrail(cardPlay, DynamicVars["FrailPower"].BaseValue);
    }

    protected override void OnUpgrade()
    {
        DynamicVars["FrailPower"].UpgradeValueBy(1M);
    }
}
