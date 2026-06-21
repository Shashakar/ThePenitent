using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.Powers;

namespace ThePenitent.ThePenitentCode.Cards;

public class ShelteringPrayerCard() : 
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

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {

        var block = new BlockVar(Owner.Creature.GetPowerAmount<FaithPower>(), ValueProp.Move);
            
        await GainSelfBlock(play, block);
    }

    protected override void OnUpgrade()
    {
        RemoveKeyword(CardKeyword.Exhaust);
    }
}