using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Scale;

namespace ThePenitent.ThePenitentCode.Cards;

public sealed class BurdenedRebukeCard() :
    ThePenitentMechanicCard
    (
        cost: 1,
        type: CardType.Skill,
        rarity: CardRarity.Common,
        target: TargetType.AnyEnemy,
        burden: 2M,
        extraHoverTips:
        [
            HoverTipFactory.FromPower<WeakPower>(),
            PenitentHoverTipFactory.Descend(),
            PenitentHoverTipFactory.Burden(),
            PenitentHoverTipFactory.Heretic()
        ]
    )
{
    protected override IEnumerable<DynamicVar> AdditionalCanonicalVars =>
    [
        new PowerVar<WeakPower>(2M),
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await Descend();

        decimal weakAmount = DynamicVars.Weak.BaseValue;
        if (PenitentScaleTracker.IsHeretic(Owner.Creature))
            weakAmount += 1M;

        await ApplyWeak(
            choiceContext, 
            cardPlay, 
            weakAmount);
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Weak.UpgradeValueBy(1M);
    }
}
