using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.ValueProps;

namespace ThePenitent.ThePenitentCode.Powers;

public sealed class ZealousRetortPower : ThePenitentPower, IFaithPreventedDamageListener
{
    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Counter;

    public async Task OnFaithPreventedDamage(
        PlayerChoiceContext choiceContext,
        Creature attacker,
        int preventedAmount)
    {
        if (Amount <= 0)
            return;

        Flash();

        await CreatureCmd.Damage(
            choiceContext,
            attacker,
            Amount,
            ValueProp.Unpowered,
            Owner,
            null
        );
    }
}