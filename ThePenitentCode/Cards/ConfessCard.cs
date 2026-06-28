using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Scale;

namespace ThePenitent.ThePenitentCode.Cards;


public class ConfessCard() :
    ThePenitentMechanicCard
    (
        cost: 1,
        type: CardType.Skill,
        rarity: CardRarity.Uncommon,
        target: TargetType.Self,
        faith: 5M,
        cardsToDraw: 1,
        extraHoverTips: [PenitentHoverTipFactory.Ascend(), PenitentHoverTipFactory.Faith(), PenitentHoverTipFactory.Penitent()]
    )
{

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        bool isPenitent = PenitentScaleTracker.IsPenitent(Owner.Creature);

        await Ascend();
        await DrawCards(choiceContext);

        if (isPenitent)
            await DrawCards(choiceContext, 1);
    }

    protected override void OnUpgrade()
    {
        Faith.UpgradeValueBy(2M);
    }
}
