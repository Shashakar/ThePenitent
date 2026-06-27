using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Scale;

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
    protected override bool ShouldGlowRedInternal => !HasFaithPower;
    
    protected override void AddExtraArgsToContextualDescription(LocString description)
    {
        decimal faith = CombatState is not null
            ? FaithAmount
            : 0M;

        description.Add("DescendAmount", faith * 2M);
    }
    
    protected override IEnumerable<DynamicVar> AdditionalCanonicalVars =>
    [
        new CalculationBaseVar(0M),
        new ExtraDamageVar(2M),
        new CalculatedDamageVar(ValueProp.Move)
            .WithMultiplier((card, _) =>
                PenitentScaleTracker.FaithAmount(card.Owner.Creature))
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        decimal faith = FaithAmount;

        if (faith <= 0)
            return;

        var calculatedDamage =
            DynamicVars.CalculationBase.BaseValue +
            faith * DynamicVars.ExtraDamage.BaseValue;
        
        // Convert all current Faith into equal Burden.
        // Descending by faith * 2 removes all Faith, then gains that much Burden.
        await Descend(faith * 2M);

        await AttackTarget(choiceContext, cardPlay, calculatedDamage);
    }

    protected override void OnUpgrade()
    {
        DynamicVars.CalculationBase.UpgradeValueBy(5M);
    }
}
