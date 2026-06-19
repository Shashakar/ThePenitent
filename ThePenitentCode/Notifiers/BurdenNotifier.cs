using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Models;
using ThePenitent.ThePenitentCode.Interfaces;
using ThePenitent.ThePenitentCode.Mechanics.Notifiers;

namespace ThePenitent.ThePenitentCode.Notifiers;

public sealed class BurdenNotifier : PenitentNotifierBase
{
    private BurdenNotifier()
    {
    }

    public static Task NotifyCreatedBurden(
        Creature owner,
        decimal descendAmount,
        decimal burdenCreated,
        Creature? source,
        CardModel? cardSource,
        ICombatState? combatState)
    {
        return NotifyListeners<ICreatedBurdenListener>(
            owner,
            listener => listener.OnCreatedBurden(
                owner,
                descendAmount,
                burdenCreated,
                source,
                cardSource,
                combatState
            )
        );
    }
}