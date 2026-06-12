using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace ThePenitent.ThePenitentCode.Cards;

public sealed class PrayerCard : ThePenitentMechanicCard
{
    public PrayerCard()
        : base(
            cost: 1,
            type: CardType.Skill,
            rarity: CardRarity.Common,
            target: TargetType.Self,
            faith: 4M)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        ApplyFaithToSelf();
    }
    
    protected override void OnUpgrade()
    {
        Faith.UpgradeValueBy(2M);
    }


}