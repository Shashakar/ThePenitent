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

    public override async Task BeforeSideTurnEnd(PlayerChoiceContext choiceContext, CombatSide side, IEnumerable<Creature> participants)
    {
        if (side != CombatSide.Enemy)
            return;

        if (!PenitentScaleTracker.HasBurden(Owner))
            return;
        
        var burdenAmount = PenitentScaleTracker.BurdenAmount(Owner);

        await CreatureCmd.GainBlock(Owner, burdenAmount, ValueProp.Move, null);
    }
}
