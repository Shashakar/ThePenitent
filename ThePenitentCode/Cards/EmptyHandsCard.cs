using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using ThePenitent.ThePenitentCode.HoverTips;

namespace ThePenitent.ThePenitentCode.Cards;


public class EmptyHandsCard() :
    ThePenitentMechanicCard
    (
        cost: 2,
        type: CardType.Skill,
        rarity: CardRarity.Uncommon,
        target: TargetType.Self,
        faith: 10M,
        extraHoverTips: [PenitentHoverTipFactory.Ascend(), PenitentHoverTipFactory.Faith()]
    )
{
    protected override bool ShouldGlowRedInternal => Owner.Creature.Block != 0;
    protected override bool ShouldGlowGoldInternal => Owner.Creature.Block == 0;

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        //If you have no block
        if (Owner.Creature.Block > 0)
            return;
        
        // Gain 10 faith.
        await Ascend();
        
    }

    protected override void OnUpgrade()
    {
        Faith.UpgradeValueBy(2M);
        EnergyCost.UpgradeBy(-1);
    }


}
