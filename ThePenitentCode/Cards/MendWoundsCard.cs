using MegaCrit.Sts2.Core.Entities.Cards;

namespace ThePenitent.ThePenitentCode.Cards;

public sealed class MendWoundsCard() :
    BaseAtoneCard
    (
        cost: 1,
        type: CardType.Skill,
        rarity: CardRarity.Common,
        target: TargetType.AnyPlayer,
        healAmount: 5M,
        upgradeHealAmount: 2M
    )
{
}
