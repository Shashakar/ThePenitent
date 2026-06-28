using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Scale;

namespace ThePenitent.ThePenitentCode.Cards;

public sealed class SteadyConvictionCard() :
    ThePenitentMechanicCard
    (
        cost: 1,
        type: CardType.Skill,
        rarity: CardRarity.Common,
        target: TargetType.Self,
        block: 4M,
        faith: 3M,
        extraHoverTips: [PenitentHoverTipFactory.Ascend(), PenitentHoverTipFactory.Faith(), PenitentHoverTipFactory.Penitent()]
    )
{

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        decimal blockAmount = Block.BaseValue;
        if (PenitentScaleTracker.IsPenitent(Owner.Creature))
            blockAmount += 2M;

        await GainSelfBlock(cardPlay, new BlockVar(blockAmount, ValueProp.Move));
        await Ascend();
    }
    
    protected override void OnUpgrade()
    {
        Block.UpgradeValueBy(2M);
        Faith.UpgradeValueBy(1M);
    }
}
