using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.Powers;

namespace ThePenitent.ThePenitentCode.Cards;


public sealed class ThePenitentDefendCard() : 
    ThePenitentCard
    (
        cost: 1,
        type: CardType.Skill,
        rarity: CardRarity.Basic,
        target: TargetType.Self
    )
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new BlockVar(5M, ValueProp.Move),
    ];
    
    public override bool GainsBlock => true;

    protected override HashSet<CardTag> CanonicalTags =>
        new() { CardTag.Defend };

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CreatureCmd.GainBlock(Owner.Creature, DynamicVars.Block, cardPlay);
    }
    
    protected override void OnUpgrade()
    { 
        DynamicVars.Block.UpgradeValueBy(3M);
    }
}