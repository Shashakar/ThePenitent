using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.Interfaces;

namespace ThePenitent.ThePenitentCode.Relics;

public sealed class HallowCrownRelic : ThePenitentRelic, IShouldFaithDecayListener
{
    public override RelicRarity Rarity => RelicRarity.Rare;

    public bool ShouldFaithDecay()
    {
        Flash();
        return false;
    }

    public override decimal ModifyBlockAdditive(
        Creature target,
        decimal block,
        ValueProp props,
        CardModel? cardSource,
        CardPlay? cardPlay)
    {
        if (target != Owner.Creature)
            return 0M;

        if (cardSource?.Owner != Owner)
            return 0M;

        return -block;
    }
}
