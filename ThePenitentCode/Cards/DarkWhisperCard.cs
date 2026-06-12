using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace ThePenitent.ThePenitentCode.Cards;


public sealed class DarkWhisperCard : ThePenitentMechanicCard
{
    public DarkWhisperCard()
        : base(
            cost: 1,
            type: CardType.Skill,
            rarity: CardRarity.Common,
            target: TargetType.None,
            burden: 3M,
            cardsToDraw: 1)
    {
    }
    

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplyBurdenToSelf();

        await DrawCards(choiceContext);
    }
    
    protected override void OnUpgrade()
    {
        Burden.UpgradeValueBy(-1M);
    }
}