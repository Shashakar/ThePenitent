using BaseLib.Extensions;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Powers;

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
    public override bool GainsBlock => true;
    
    protected override IEnumerable<DynamicVar> AdditionalCanonicalVars =>
    [
        new DynamicVar("BlockMultiplier", 2M),
        new DynamicVar("AdditionalBlock", 0M)
    ];

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        if (!Owner.HasPower<FaithPower>())
            return;
        
        var faith = Owner.Creature.GetPower<FaithPower>()!.Amount;
        var blockMultiplier = DynamicVars["BlockMultiplier"].BaseValue;
        var additionalBlock = DynamicVars["AdditionalBlock"].BaseValue;
        var amountOfBlockToGain = new BlockVar((faith * blockMultiplier) + additionalBlock, ValueProp.Move);
        await Descend(faith);
        await GainSelfBlock(play, amountOfBlockToGain);
    }

    protected override void OnUpgrade()
    {
        DynamicVars["AdditionalBlock"].UpgradeValueBy(5M);
    }
}
