using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.Interfaces;

namespace ThePenitent.ThePenitentCode.Powers;

public sealed class FaithPower : ThePenitentPower
{
    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Counter;

    public override async Task BeforeSideTurnStart(PlayerChoiceContext choiceContext, CombatSide side, CombatState combatState)
    {
        if (side == CombatSide.Enemy || side == CombatSide.None)
            return;

        if (Amount <= 0)
            return;
        
        // Lose half of Faith, rounded up.
        var newFaithAmount = (int)Math.Floor(Amount / 2.0);
        if (newFaithAmount <= 0)
            await PowerCmd.Remove(this);
        else SetAmount(newFaithAmount);
    }

    private int _pendingFaithLoss;

    public override decimal ModifyHpLostBeforeOsty(
        Creature target,
        decimal amount,
        ValueProp props,
        Creature? dealer,
        CardModel? cardSource)
    {
        if (amount <= 0M)
            return amount;

        if (target != Owner)
            return amount;

        if (props.HasFlag(ValueProp.Unblockable))
            return amount;

        int faithAvailable = Amount;
        int hpLossIncoming = (int)amount;

        int faithUsed = Math.Min(faithAvailable, hpLossIncoming);

        if (faithUsed <= 0)
            return amount;

        _pendingFaithLoss += faithUsed;

        return amount - faithUsed;
    }

    public override async Task AfterDamageReceived(
        PlayerChoiceContext choiceContext,
        Creature target,
        DamageResult result,
        ValueProp props,
        Creature? dealer,
        CardModel? cardSource)
    {
        if (target != Owner)
            return;

        if (_pendingFaithLoss <= 0)
            return;

        int faithLoss = _pendingFaithLoss;
        _pendingFaithLoss = 0;

        Flash();

        await PowerCmd.ModifyAmount(this, -faithLoss, dealer, null);

        if (dealer == null)
            return;

        foreach (var listener in Owner.Powers.OfType<IFaithPreventedDamageListener>())
        {
            await listener.OnFaithPreventedDamage(choiceContext, dealer, faithLoss);
        }
    }
}