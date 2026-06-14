using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using ThePenitent.ThePenitentCode.HoverTips;

namespace ThePenitent.ThePenitentCode.Cards;

public sealed class PrayerCard() :
    ThePenitentMechanicCard
    (
        cost: 1,
        type: CardType.Skill,
        rarity: CardRarity.Common,
        target: TargetType.Self,
        faith: 4M,
        extraHoverTips: [PenitentHoverTipFactory.Ascend(), PenitentHoverTipFactory.Faith()]
    )
{

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await Ascend();
    }
    
    protected override void OnUpgrade()
    {
        Faith.UpgradeValueBy(2M);
    }


}
