using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace ThePenitent.ThePenitentCode.Cards;


public class EmptyHandsCard : ThePenitentMechanicCard
{
    public EmptyHandsCard()
        : base(
            cost: 2,
            type: CardType.Skill,
            rarity: CardRarity.Uncommon,
            target: TargetType.Self,
            faith: 10M)
    {
    }
    
    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        //If you have no block
        if (Owner.Creature.Block > 0)
            return;
        
        // Gain 10 faith.
        await ApplyFaithToSelf();
        
    }

    protected override void OnUpgrade()
    {
        Faith.UpgradeValueBy(2M);
        EnergyCost.UpgradeBy(-1);
    }


}