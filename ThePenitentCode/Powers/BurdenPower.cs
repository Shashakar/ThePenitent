using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Rooms;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.Interfaces;

namespace ThePenitent.ThePenitentCode.Powers;

public sealed class BurdenPower : ThePenitentPower
{
    public override PowerType Type => PowerType.Debuff;

    public override PowerStackType StackType => PowerStackType.Counter;

    public override async Task AfterCombatEnd(CombatRoom _)
    {
        if (Owner.IsDead)
            return;

        int burdenAmount = (int)Amount;
        int hpAfterBurden = Owner.CurrentHp - burdenAmount;

        int damageToDeal;
        int maxHpLoss;

        if (hpAfterBurden > 0)
        {
            damageToDeal = burdenAmount;
            maxHpLoss = 0;
        }
        else
        {
            damageToDeal = Math.Max(0, Owner.CurrentHp - 1);
            maxHpLoss = Math.Abs(hpAfterBurden) + 1;
        }

        Flash();

        if (damageToDeal > 0)
        {
            await CreatureCmd.Damage(
                new ThrowingPlayerChoiceContext(),
                Owner,
                damageToDeal,
                ValueProp.Unpowered | ValueProp.Unblockable,
                Owner,
                null
            );
        }

        if (maxHpLoss > 0 && !Owner.IsDead)
        {
            int newMaxHp = Math.Max(1, Owner.MaxHp - maxHpLoss);

            if (newMaxHp != Owner.MaxHp)
                await CreatureCmd.SetMaxHp(Owner, newMaxHp);
        }
    }
}