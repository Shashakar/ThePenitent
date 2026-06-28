using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.Scale;

namespace ThePenitent.ThePenitentCode.Powers;

public class CrownOfThornsPower : ThePenitentPower
{

    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Single;

    public static decimal BurdenToConsumeForBlock(decimal burden)
    {
        return Math.Floor(Math.Max(0M, burden) / 2M);
    }

    public override async Task BeforeSideTurnEnd(PlayerChoiceContext choiceContext, CombatSide side, IEnumerable<Creature> participants)
    {
        if (side != CombatSide.Enemy)
            return;

        if (!PenitentScaleTracker.IsHeretic(Owner))
            return;
        
        decimal burdenToConsume = BurdenToConsumeForBlock(PenitentScaleTracker.BurdenAmount(Owner));
        if (burdenToConsume <= 0M)
            return;

        BurdenPower? burden = Owner.Powers.OfType<BurdenPower>().FirstOrDefault();
        if (burden is not null)
            await PowerCmd.ModifyAmount(choiceContext, burden, -burdenToConsume, Owner, null);

        PenitentScaleMeterRegistry.Update(Owner);
        Owner.Player?.PlayerCombatState?.RecalculateCardValues();

        await CreatureCmd.GainBlock(Owner, burdenToConsume, ValueProp.Move, null);
    }
}
