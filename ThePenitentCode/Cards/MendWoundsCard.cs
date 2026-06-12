using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace ThePenitent.ThePenitentCode.Cards;

public sealed class MendWoundsCard : ThePenitentMechanicCard
{
    public MendWoundsCard()
        : base(
            cost: 1,
            type: CardType.Skill,
            rarity: CardRarity.Common,
            target: TargetType.AnyPlayer,
            healAmount: 5M)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await AtoneTarget(cardPlay);
    }

    protected override void OnUpgrade()
    {
        Heal.UpgradeValueBy(2M);
    }
}