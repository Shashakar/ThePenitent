using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.Scale;

namespace ThePenitent.ThePenitentCode.Powers;

public sealed class ZealousRetortPower : ThePenitentPower
{
    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Counter;

    public override async Task AfterDamageReceived(
        PlayerChoiceContext choiceContext,
        Creature target,
        DamageResult result,
        ValueProp props,
        Creature? dealer,
        CardModel? cardSource)
    {
        if (Amount <= 0)
            return;

        if (target != Owner)
            return;

        if (dealer is null || dealer == Owner)
            return;

        if (!PenitentScaleTracker.HasFaith(Owner))
            return;

        Flash();

        await CreatureCmd.Damage(
            choiceContext,
            dealer,
            Amount,
            ValueProp.Unpowered,
            Owner,
            null
        );
    }
}
