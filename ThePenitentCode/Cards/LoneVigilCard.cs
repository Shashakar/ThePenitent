using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Scale;

namespace ThePenitent.ThePenitentCode.Cards;

public sealed class LoneVigilCard() :
    ThePenitentMechanicCard
    (
        cost: 1,
        type: CardType.Skill,
        rarity: CardRarity.Common,
        target: TargetType.Self,
        block: 7M,
        faith: 3M,
        extraHoverTips: [PenitentHoverTipFactory.Ascend(), PenitentHoverTipFactory.Faith(), PenitentHoverTipFactory.Penitent()]
    )
{
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        bool isPenitent = PenitentScaleTracker.IsPenitent(Owner.Creature);

        await GainSelfBlock(cardPlay);

        if (IsFirstCardPlayedThisTurn(cardPlay))
            await Ascend();

        if (isPenitent)
            await DrawCards(choiceContext, 1);
    }

    protected override void OnUpgrade()
    {
        Block.UpgradeValueBy(3M);
        Faith.UpgradeValueBy(1M);
    }
}
