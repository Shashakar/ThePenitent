using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.Scale;

namespace ThePenitent.ThePenitentCode.Relics;

public sealed class HereticsCandleRelic : ThePenitentRelic
{
    public override RelicRarity Rarity => RelicRarity.Uncommon;

    public override decimal ModifyDamageAdditive(
        Creature? target,
        decimal amount,
        ValueProp props,
        Creature? dealer,
        CardModel? cardSource)
    {
        if (dealer != Owner.Creature)
            return 0M;

        if (cardSource?.Type != CardType.Attack)
            return 0M;

        if (!PenitentScaleTracker.HasBurden(Owner.Creature))
            return 0M;

        return 2M;
    }
}
