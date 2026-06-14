using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using ThePenitent.ThePenitentCode.HoverTips;

namespace ThePenitent.ThePenitentCode.Cards;

public class GentleMercyCard() :
    ThePenitentMechanicCard
    (
        cost: 1,
        type: CardType.Skill,
        rarity: CardRarity.Rare,
        target: TargetType.AnyPlayer,
        healAmount: 6M,
        keywords: [CardKeyword.Exhaust],
        extraHoverTips: [PenitentHoverTipFactory.Burden()]
    )
{
    
    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await HealTarget(play);
    }

    protected override void OnUpgrade()
    {
        Heal.UpgradeValueBy(3M);
    }
}
