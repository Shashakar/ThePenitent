using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Models;
using ThePenitent.ThePenitentCode.Powers;

namespace ThePenitent.ThePenitentCode.Commands;

public static class PenitentPowerCmd
{
    public static async Task ApplyFaith(
        Creature owner,
        decimal amount,
        Creature? source,
        CardModel? cardSource)
    {
        if (amount <= 0)
            return;

        decimal remaining = amount;

        BurdenPower? burden = GetPower<BurdenPower>(owner);

        if (burden is not null && burden.Amount > 0)
        {
            decimal burdenRemoved = Math.Min(burden.Amount, remaining);

            // Private method, can't be accessed here
            // burden.Flash();
            await PowerCmd.ModifyAmount(burden, -burdenRemoved, source, cardSource);

            remaining -= burdenRemoved;
        }

        if (remaining <= 0)
            return;

        await PowerCmd.Apply<FaithPower>(
            owner,
            remaining,
            source ?? owner,
            cardSource
        );
    }

    public static async Task ApplyBurden(
        Creature owner,
        decimal amount,
        Creature? source,
        CardModel? cardSource)
    {
        if (amount <= 0)
            return;

        decimal remaining = amount;

        FaithPower? faith = GetPower<FaithPower>(owner);

        if (faith is not null && faith.Amount > 0)
        {
            decimal faithRemoved = Math.Min(faith.Amount, remaining);

            // Private method, can't be accessed here
            // faith.Flash();
            await PowerCmd.ModifyAmount(faith, -faithRemoved, source, cardSource);

            remaining -= faithRemoved;
        }

        if (remaining <= 0)
            return;

        await PowerCmd.Apply<BurdenPower>(
            owner,
            remaining,
            source ?? owner,
            cardSource
        );
    }

    private static TPower? GetPower<TPower>(Creature owner)
        where TPower : PowerModel
    {
        return owner.Powers.OfType<TPower>().FirstOrDefault();
    }
}