using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Scale;

namespace ThePenitent.ThePenitentCode.Cards;

public class HeavySoulCard() :
    ThePenitentMechanicCard
    (
        cost: 1,
        type: CardType.Attack,
        rarity: CardRarity.Common,
        target: TargetType.AnyEnemy,
        damage: 6M,
        extraHoverTips: [PenitentHoverTipFactory.Heretic()]
    )
{
    protected override bool ShouldGlowGoldInternal => PenitentScaleTracker.IsHeretic(Owner.Creature);

    protected override void AddExtraArgsToContextualDescription(LocString description)
    {
        base.AddExtraArgsToContextualDescription(description);

        decimal damage = CombatState is not null && PenitentScaleTracker.IsHeretic(Owner.Creature)
            ? Damage.BaseValue * 2M
            : Damage.BaseValue;

        description.Add("DamageAmount", damage);
    }

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {

        decimal damage = PenitentScaleTracker.IsHeretic(Owner.Creature)
            ? (Damage.BaseValue * 2)
            : Damage.BaseValue;

        await AttackTarget(choiceContext, play, damage);
    }

    protected override void OnUpgrade()
    {
        Damage.UpgradeValueBy(2M);
    }
}
