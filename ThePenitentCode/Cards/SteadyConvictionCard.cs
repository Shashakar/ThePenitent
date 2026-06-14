using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using ThePenitent.ThePenitentCode.HoverTips;

namespace ThePenitent.ThePenitentCode.Cards;

public sealed class SteadyConvictionCard() :
    ThePenitentMechanicCard
    (
        cost: 1,
        type: CardType.Skill,
        rarity: CardRarity.Common,
        target: TargetType.Self,
        block: 4M,
        faith: 3M,
        extraHoverTips: [PenitentHoverTipFactory.Ascend(), PenitentHoverTipFactory.Faith()]
    )
{

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await GainSelfBlock(cardPlay);
        await Ascend();
    }
    
    protected override void OnUpgrade()
    {
        Block.UpgradeValueBy(2M);
        Faith.UpgradeValueBy(1M);
    }


}
