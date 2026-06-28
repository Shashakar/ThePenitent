using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Scale;

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
        extraHoverTips: [PenitentHoverTipFactory.Descend(), PenitentHoverTipFactory.Prophet()]
    )
{
    
    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        Creature target = play.Target ?? Owner.Creature;
        decimal healAmount = Heal.BaseValue;
        if (PenitentScaleTracker.IsProphet(Owner.Creature))
            healAmount += 3M;

        await CreatureCmd.Heal(target, healAmount);
    }

    protected override void OnUpgrade()
    {
        Heal.UpgradeValueBy(3M);
    }
}
