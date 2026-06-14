using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using ThePenitent.ThePenitentCode.Cards;
using ThePenitent.ThePenitentCode.HoverTips;

namespace ThePenitent.ThePenitentCode.Cards;

public class BlackBenedictionCard() :
    ThePenitentMechanicCard
    (
        cost: 2,
        type: CardType.Attack,
        rarity: CardRarity.Uncommon,
        target: TargetType.AnyEnemy,
        damage: 24M,
        burden: 8M,
        extraHoverTips: [PenitentHoverTipFactory.Descend(), PenitentHoverTipFactory.Burden()]
    )
{

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await Descend();
        await AttackTarget(choiceContext, play);
    }

    protected override void OnUpgrade()
    {
        Damage.UpgradeValueBy(8M);
    }
}
