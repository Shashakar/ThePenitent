using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.Commands;

namespace ThePenitent.ThePenitentCode.Powers;

public sealed class RitesOfEndurancePower : ThePenitentPower
{
    private bool _usedThisTurn;
    private decimal _pendingDescend;

    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Single;

    public override decimal ModifyHpLostBeforeOsty(
        Creature target,
        decimal amount,
        ValueProp props,
        Creature? dealer,
        CardModel? cardSource)
    {
        if (_usedThisTurn)
            return amount;

        if (amount <= 0M)
            return amount;

        if (target != Owner)
            return amount;

        if (props.HasFlag(ValueProp.Unblockable))
            return amount;

        _usedThisTurn = true;
        _pendingDescend += amount;
        Flash();

        return 0M;
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

        if (_pendingDescend <= 0M)
            return;

        decimal descendAmount = _pendingDescend;
        _pendingDescend = 0M;

        await PenitentPowerCmd.ApplyBurden(
            Owner,
            descendAmount,
            dealer,
            cardSource,
            null
        );
    }

    public Task AfterTurnStart(int roundNumber, CombatSide side)
    {
        _usedThisTurn = false;
        _pendingDescend = 0M;

        return Task.CompletedTask;
    }
}
