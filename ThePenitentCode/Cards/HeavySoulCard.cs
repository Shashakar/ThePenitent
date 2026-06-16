using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Powers;

namespace ThePenitent.ThePenitentCode.Cards;

public class HeavySoulCard() :
    ThePenitentMechanicCard
    (
        cost: 1,
        type: CardType.Attack,
        rarity: CardRarity.Common,
        target: TargetType.AnyEnemy,
        damage: 6M,
        extraHoverTips: [PenitentHoverTipFactory.Burden()]
    )
{
    protected override bool ShouldGlowGoldInternal => HasBurdenPower;

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {

        decimal damage = Owner.Creature.HasPower<BurdenPower>()
            ? (Damage.BaseValue * 2)
            : Damage.BaseValue;

        await AttackTarget(choiceContext, play, damage);
    }

    protected override void OnUpgrade()
    {
        Damage.UpgradeValueBy(2M);
    }
}
