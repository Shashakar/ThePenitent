using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Powers;

namespace ThePenitent.ThePenitentCode.Cards;

public sealed class FallFromGraceCard() :
    ThePenitentMechanicCard
    (
        cost: 1,
        type: CardType.Attack,
        rarity: CardRarity.Uncommon,
        target: TargetType.AnyEnemy,
        extraHoverTips: [PenitentHoverTipFactory.Descend(), PenitentHoverTipFactory.Faith(), PenitentHoverTipFactory.Burden()]
    )
{

    protected override IEnumerable<DynamicVar> AdditionalCanonicalVars =>
    [
        new CalculationBaseVar(0M),
        new ExtraDamageVar(2M),
        new CalculatedDamageVar(ValueProp.Move)
            .WithMultiplier((card, _) =>
                card.Owner.Creature.GetPowerAmount<FaithPower>())
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        decimal faith = Owner.Creature.GetPowerAmount<FaithPower>();

        if (faith <= 0)
            return;

        // Convert all current Faith into equal Burden.
        // Descending by faith * 2 removes all Faith, then gains that much Burden.
        await Descend(faith * 2M);

        await AttackTarget(choiceContext, cardPlay, DynamicVars.CalculatedDamage.BaseValue);
    }

    protected override void OnUpgrade()
    {
        DynamicVars.CalculationBase.UpgradeValueBy(5M);
    }
}
