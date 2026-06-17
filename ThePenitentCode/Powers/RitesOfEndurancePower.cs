using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.Interfaces;

namespace ThePenitent.ThePenitentCode.Powers;

public sealed class RitesOfEndurancePower : ThePenitentPower, IFaithPreventedDamageListener
{
    private int _pendingBlock;

    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Counter;

    public Task OnFaithPreventedDamage(
        PlayerChoiceContext choiceContext,
        MegaCrit.Sts2.Core.Entities.Creatures.Creature attacker,
        int preventedAmount)
    {
        if (preventedAmount <= 0)
            return Task.CompletedTask;

        _pendingBlock += Amount;
        Flash();

        return Task.CompletedTask;
    }

    public async Task AfterTurnStart(int roundNumber, CombatSide side)
    {
        if (side != CombatSide.Player)
            return;

        if (_pendingBlock <= 0)
            return;

        int block = _pendingBlock;
        _pendingBlock = 0;

        Flash();
        await CreatureCmd.GainBlock(Owner, block, default, null);
    }
}
