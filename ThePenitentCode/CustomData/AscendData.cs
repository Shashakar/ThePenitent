using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Models;

namespace ThePenitent.ThePenitentCode.CustomData;

public sealed class AscendData
{
    public Creature Owner { get; }
    public Creature? Source { get; }
    public CardModel? CardSource { get; }
    public CombatState? CombatState { get; }

    public decimal BaseAmount { get; }
    public decimal Amount { get; }

    public AscendData(
        Creature owner,
        decimal amount,
        Creature? source,
        CardModel? cardSource,
        CombatState? combatState)
    {
        Owner = owner;
        Source = source;
        CardSource = cardSource;
        CombatState = combatState;

        BaseAmount = amount;
        Amount = amount;
    }
}
