using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.Powers;

namespace ThePenitent.ThePenitentCode.Cards;

public class ShelteringPrayer() : 
    ThePenitentMechanicCard
    (
        cost: 2,
        type: CardType.Skill, 
        rarity: CardRarity.Uncommon,
        target: TargetType.Self,
        keywords: [CardKeyword.Exhaust]
    )
{
    public override bool GainsBlock => true;

    protected override IEnumerable<DynamicVar> AdditionalCanonicalVars =>
    [
        new BlockVar(Owner.Creature.GetPowerAmount<FaithPower>(), ValueProp.Move)
    ];

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await GainSelfBlock(play);
    }

    protected override void OnUpgrade()
    {
        RemoveKeyword(CardKeyword.Exhaust);
    }
}