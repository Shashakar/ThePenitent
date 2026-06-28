using MegaCrit.Sts2.Core.Entities.Powers;

namespace ThePenitent.ThePenitentCode.Powers;

public sealed class BurdenPower : ThePenitentPower
{
    protected override bool IsVisibleInternal => false;

    public override PowerType Type => PowerType.Debuff;

    public override PowerStackType StackType => PowerStackType.Counter;
}
