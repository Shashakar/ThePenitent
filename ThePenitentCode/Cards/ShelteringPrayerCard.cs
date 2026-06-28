using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Scale;

namespace ThePenitent.ThePenitentCode.Cards;

public class ShelteringPrayerCard() : 
    ThePenitentMechanicCard
    (
        cost: 2,
        type: CardType.Skill, 
        rarity: CardRarity.Uncommon,
        target: TargetType.Self,
        keywords: [CardKeyword.Exhaust],
        extraHoverTips: [PenitentHoverTipFactory.Faith(), PenitentHoverTipFactory.Prophet()]
    )
{
    public override bool GainsBlock => true;

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {

        decimal blockAmount = FaithAmount;
        if (PenitentScaleTracker.IsProphet(Owner.Creature))
            blockAmount += 4M;

        var block = new BlockVar(blockAmount, ValueProp.Move);
            
        await GainSelfBlock(play, block);
    }

    protected override void OnUpgrade()
    {
        RemoveKeyword(CardKeyword.Exhaust);
    }
}
