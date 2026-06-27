using MegaCrit.Sts2.Core.Entities.Powers;

namespace ThePenitent.ThePenitentCode.Powers;

public sealed class FaithPower : ThePenitentPower
{
    protected override bool IsVisibleInternal => false;

    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Counter;
}
