using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Scale;

namespace ThePenitent.ThePenitentCode.Cards;


public class EmptyHandsCard() :
    ThePenitentMechanicCard
    (
        cost: 2,
        type: CardType.Skill,
        rarity: CardRarity.Uncommon,
        target: TargetType.Self,
        faith: 10M,
        extraHoverTips: [PenitentHoverTipFactory.Ascend(), PenitentHoverTipFactory.Faith(), PenitentHoverTipFactory.Penitent()]
    )
{
    protected override bool ShouldGlowRedInternal => Owner.Creature.Block != 0;
    protected override bool ShouldGlowGoldInternal => Owner.Creature.Block == 0;

    protected override void AddExtraArgsToContextualDescription(LocString description)
    {
        base.AddExtraArgsToContextualDescription(description);

        int block = CombatState is not null
            ? Owner.Creature.Block
            : 0;

        description.Add("CurrentBlock", block);
    }

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        //If you have no block
        if (Owner.Creature.Block > 0)
            return;

        bool isPenitent = PenitentScaleTracker.IsPenitent(Owner.Creature);

        // Gain 10 faith.
        await Ascend();

        if (isPenitent)
            await GainSelfBlock(play, new BlockVar(4M, ValueProp.Move));
        
    }

    protected override void OnUpgrade()
    {
        Faith.UpgradeValueBy(2M);
        EnergyCost.UpgradeBy(-1);
    }


}
