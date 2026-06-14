using MegaCrit.Sts2.Core.Entities.Cards;
using ThePenitent.ThePenitentCode.HoverTips;

namespace ThePenitent.ThePenitentCode.Cards;

public class IntercessionCard() :
    BaseAtoneCard
    (
        cost: 1,
        type: CardType.Skill,
        rarity: CardRarity.Uncommon,
        target: TargetType.AnyAlly,
        healAmount: 7M,
        upgradeHealAmount: 2M,
        keywords: [CardKeyword.Exhaust]
    )
{
    
    public override CardMultiplayerConstraint MultiplayerConstraint => CardMultiplayerConstraint.MultiplayerOnly;
    
}
