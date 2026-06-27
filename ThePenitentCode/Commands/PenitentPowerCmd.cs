using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using ThePenitent.ThePenitentCode.CustomData;
using ThePenitent.ThePenitentCode.Notifiers;
using ThePenitent.ThePenitentCode.Powers;
using ThePenitent.ThePenitentCode.Scale;

namespace ThePenitent.ThePenitentCode.Commands;

public static class PenitentPowerCmd
{
    public static async Task ApplyFaith(
        Creature owner,
        decimal amount,
        Creature? source,
        CardModel? cardSource,
        ICombatState? combatState)
    {
        if (amount <= 0)
            return;

        var ascendData = new AscendData(
            owner,
            amount,
            source,
            cardSource,
            combatState
        );

        decimal remaining = amount;

        BurdenPower? burden = GetPower<BurdenPower>(owner);

        if (burden is not null && burden.Amount > 0)
        {
            decimal burdenRemoved = Math.Min(burden.Amount, remaining);

            await PowerCmd.ModifyAmount(
                new ThrowingPlayerChoiceContext(),
                burden,
                -burdenRemoved,
                source,
                cardSource
            );

            remaining -= burdenRemoved;
        }

        if (remaining <= 0)
        {
            await AscendNotifier.NotifyAfterAscend(ascendData);
            PenitentScaleMeterRegistry.Update(owner);
            return;
        }

        await PowerCmd.Apply<FaithPower>(
            new ThrowingPlayerChoiceContext(),
            owner,
            remaining,
            source ?? owner,
            cardSource
        );

        await AscendNotifier.NotifyAfterAscend(ascendData);
        PenitentScaleMeterRegistry.Update(owner);
    }

    public static async Task ApplyBurden(
        Creature owner,
        decimal amount,
        Creature? source,
        CardModel? cardSource,
        ICombatState? combatState)
    {
        if (amount <= 0)
            return;

        var descendData = new DescendData(
            owner,
            amount,
            source,
            cardSource,
            combatState
        );

        await DescendNotifier.NotifyBeforeDescend(descendData);

        if (!descendData.WillDescend)
            return;

        decimal finalDescendAmount = descendData.Amount;
        decimal remainingCharges = descendData.Amount;

        FaithPower? faith = GetPower<FaithPower>(owner);

        if (faith is not null && faith.Amount > 0)
        {
            decimal faithRemoved = Math.Min(faith.Amount, remainingCharges);

            await PowerCmd.ModifyAmount(
                new ThrowingPlayerChoiceContext(),
                faith,
                -faithRemoved,
                source,
                cardSource
            );

            remainingCharges -= faithRemoved;
        }

        if (remainingCharges <= 0)
        {
            PenitentScaleMeterRegistry.Update(owner);
            return;
        }

        await PowerCmd.Apply<BurdenPower>(
            new ThrowingPlayerChoiceContext(),
            owner,
            remainingCharges,
            source ?? owner,
            cardSource
        );

        await BurdenNotifier.NotifyCreatedBurden(
            owner,
            finalDescendAmount,
            remainingCharges,
            source,
            cardSource,
            combatState
        );

        PenitentScaleMeterRegistry.Update(owner);
    }

    private static TPower? GetPower<TPower>(Creature owner)
        where TPower : PowerModel
    {
        return owner.Powers.OfType<TPower>().FirstOrDefault();
    }
}
