using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;

namespace ThePenitent.ThePenitentCode.CustomData;

public sealed class DescendData
{
    public Creature Owner { get; }
    public Creature? Source { get; }
    public CardModel? CardSource { get; }
    public CombatState? CombatState { get; }

    public decimal BaseAmount { get; }
    public decimal Amount { get; set; }

    public bool PreventDescend { get; set; }

    public bool WillDescend => !PreventDescend && Amount > 0;

    public DescendData(
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
        PreventDescend = false;
    }
}