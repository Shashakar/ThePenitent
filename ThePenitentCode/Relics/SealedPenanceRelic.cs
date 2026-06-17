using MegaCrit.Sts2.Core.Entities.Relics;
using ThePenitent.ThePenitentCode.CustomData;
using ThePenitent.ThePenitentCode.Interfaces;

namespace ThePenitent.ThePenitentCode.Relics;

public sealed class SealedPenanceRelic : ThePenitentRelic, IBeforeBurdenCombatEndListener
{
    public override RelicRarity Rarity => RelicRarity.Uncommon;

    public Task BeforeBurdenCombatEnd(BurdenCombatEndData burdenCombatEndData)
    {
        if (burdenCombatEndData.Owner != Owner.Creature)
            return Task.CompletedTask;

        if (burdenCombatEndData.MaxHpLoss <= 3)
            return Task.CompletedTask;

        Flash();
        burdenCombatEndData.MaxHpLoss = 3;

        return Task.CompletedTask;
    }
}
