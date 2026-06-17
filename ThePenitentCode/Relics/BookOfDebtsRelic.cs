using MegaCrit.Sts2.Core.Entities.Relics;
using ThePenitent.ThePenitentCode.CustomData;
using ThePenitent.ThePenitentCode.Interfaces;

namespace ThePenitent.ThePenitentCode.Relics;

public sealed class BookOfDebtsRelic : ThePenitentRelic, IBeforeAtoneListener, IBeforeAtoneDescendListener
{
    private const decimal AdditionalHealing = 2M;
    private const decimal AdditionalDescend = 2M;

    public override RelicRarity Rarity => RelicRarity.Uncommon;

    public Task BeforeAtone(AtoneData atoneData)
    {
        if (atoneData.Owner != Owner.Creature)
            return Task.CompletedTask;

        Flash();
        atoneData.HealAmount += AdditionalHealing;

        return Task.CompletedTask;
    }

    public Task BeforeAtoneDescend(AtoneData atoneData)
    {
        if (atoneData.Owner != Owner.Creature)
            return Task.CompletedTask;

        if (!atoneData.RestoredHp)
            return Task.CompletedTask;

        Flash();
        atoneData.DescendAmount += AdditionalDescend;

        return Task.CompletedTask;
    }
}
