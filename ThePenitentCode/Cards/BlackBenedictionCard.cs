using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using ThePenitent.ThePenitentCode.Cards;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Scale;

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
        extraHoverTips: [PenitentHoverTipFactory.Descend(), PenitentHoverTipFactory.Burden(), PenitentHoverTipFactory.Heretic()]
    )
{

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await Descend();

        decimal damage = Damage.BaseValue;
        if (PenitentScaleTracker.IsHeretic(Owner.Creature))
            damage += 8M;

        await AttackTarget(choiceContext, play, damage);
    }

    protected override void OnUpgrade()
    {
        Damage.UpgradeValueBy(8M);
    }
}
