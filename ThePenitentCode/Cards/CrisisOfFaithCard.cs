using BaseLib.Extensions;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Scale;

namespace ThePenitent.ThePenitentCode.Cards;

public class CrisisOfFaithCard() :
    ThePenitentMechanicCard
    (
        cost: 2,
        type: CardType.Skill,
        rarity: CardRarity.Uncommon,
        target: TargetType.Self,
        extraHoverTips: [PenitentHoverTipFactory.Descend(), PenitentHoverTipFactory.Faith(), PenitentHoverTipFactory.Burden()]
    )
{
    protected override bool ShouldGlowRedInternal => HasFaithPower;
        
    public override bool GainsBlock => true;
    
    protected override IEnumerable<DynamicVar> AdditionalCanonicalVars =>
    [
        new CalculationBaseVar(0M),
        new CalculationExtraVar(2M),
        new CalculatedBlockVar(ValueProp.Move)
            .WithMultiplier((card, _) =>
                PenitentScaleTracker.FaithAmount(card.Owner.Creature))
    ];

    protected override void AddExtraArgsToContextualDescription(LocString description)
    {
        decimal faith = CombatState is not null
            ? FaithAmount
            : 0M;

        description.Add("DescendAmount", faith);
    }

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        if (!HasFaithPower)
            return;
        
        var faith = FaithAmount;
        var amountOfBlockToGain = new BlockVar(
            DynamicVars.CalculationBase.BaseValue + faith * DynamicVars.CalculationExtra.BaseValue,
            ValueProp.Move
        );
        await Descend(faith);
        await GainSelfBlock(play, amountOfBlockToGain);
    }

    protected override void OnUpgrade()
    {
        DynamicVars.CalculationBase.UpgradeValueBy(5M);
    }
}
