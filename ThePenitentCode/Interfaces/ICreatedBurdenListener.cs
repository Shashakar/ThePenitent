using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Models;

namespace ThePenitent.ThePenitentCode.Interfaces;

public interface ICreatedBurdenListener
{
    Task OnCreatedBurden(
        Creature owner,
        decimal descendAmount,
        decimal burdenCreated,
        Creature? source,
        CardModel? cardSource,
        ICombatState? combatState);
}