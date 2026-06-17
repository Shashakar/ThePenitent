using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using ThePenitent.ThePenitentCode.Interfaces;
using ThePenitent.ThePenitentCode.Mechanics.Notifiers;

namespace ThePenitent.ThePenitentCode.Notifiers;

public sealed class FaithPreventedDamageNotifier : PenitentNotifierBase
{
    private FaithPreventedDamageNotifier()
    {
    }

    public static Task NotifyFaithPreventedDamage(
        Creature owner,
        PlayerChoiceContext choiceContext,
        Creature attacker,
        int preventedAmount)
    {
        return NotifyListeners<IFaithPreventedDamageListener>(
            owner,
            listener => listener.OnFaithPreventedDamage(
                choiceContext,
                attacker,
                preventedAmount
            )
        );
    }
}
