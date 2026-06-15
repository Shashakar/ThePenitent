using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using ThePenitent.ThePenitentCode.Interfaces;
using ThePenitent.ThePenitentCode.Powers;

namespace ThePenitent.ThePenitentCode.Commands;

public static class PenitentPowerCmd
{
    public static async Task ApplyFaith(
        Creature owner,
        decimal amount,
        Creature? source,
        CardModel? cardSource, 
        CombatState? combatState)
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
        CardModel? cardSource, 
        CombatState? combatState)
    {
        if (amount <= 0)
            return;

        decimal remainingCharges = amount;
        decimal faithRemoved = 0;

        FaithPower? faith = GetPower<FaithPower>(owner);

        if (faith is not null && faith.Amount > 0)
        {
            faithRemoved = Math.Min(faith.Amount, remainingCharges);

            // Private method, can't be accessed here
            // faith.Flash();
            await PowerCmd.ModifyAmount(faith, -faithRemoved, source, cardSource);

            remainingCharges -= faithRemoved;
        }

        if (remainingCharges <= 0)
            return;

        await PowerCmd.Apply<BurdenPower>(
            owner,
            remainingCharges,
            source ?? owner,
            cardSource
        );

        await NotifyCreatedBurdenListeners(owner, amount, remainingCharges, source, cardSource, combatState);
    }
    
    private static async Task NotifyCreatedBurdenListeners
    (
        Creature owner,
        decimal descendAmount,
        decimal burdenCreated,
        Creature? source,
        CardModel? cardSource,
        CombatState? combatState
    )
    {
        List<Task> tasks = [];

        foreach (ICreatedBurdenListener listener in owner.Powers.OfType<ICreatedBurdenListener>())
        {
            tasks.Add(listener.OnCreatedBurden(
                owner,
                descendAmount,
                burdenCreated,
                source,
                cardSource, 
                combatState));
        }

        foreach (ICreatedBurdenListener listener in owner.Player.Relics.OfType<ICreatedBurdenListener>())
        {
            tasks.Add(listener.OnCreatedBurden(
                owner,
                descendAmount,
                burdenCreated,
                source,
                cardSource, 
                combatState));
        }

        await Task.WhenAll(tasks);
    }

    private static TPower? GetPower<TPower>(Creature owner)
        where TPower : PowerModel
    {
        return owner.Powers.OfType<TPower>().FirstOrDefault();
    }
}