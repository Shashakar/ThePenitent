using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;

namespace ThePenitent.ThePenitentCode.CustomData;

public sealed class AtoneData
{
    public Creature Owner { get; }
    public Creature Target { get; }
    public CardModel? CardSource { get; }
    public ICombatState? CombatState { get; }

    /// <summary>
    /// The original Atone amount before relics/powers modify anything.
    /// </summary>
    public decimal BaseAmount { get; }

    /// <summary>
    /// The amount that will be passed into CreatureCmd.Heal.
    /// Relics/powers may modify this before healing.
    /// </summary>
    public decimal HealAmount { get; set; }

    /// <summary>
    /// The actual HP restored after overheal is accounted for.
    /// Set by the Atone process after healing resolves.
    /// </summary>
    public decimal ActualHealAmount { get; internal set; }

    /// <summary>
    /// The amount of Descend to apply after healing.
    /// Usually starts as ActualHealAmount, then relics/powers can modify it.
    /// </summary>
    public decimal DescendAmount { get; set; }

    /// <summary>
    /// Used by effects like Ash-Stained Veil.
    /// </summary>
    public bool PreventDescend { get; set; }

    public bool RestoredHp => ActualHealAmount > 0;
    public bool WillDescend => !PreventDescend && DescendAmount > 0;

    public AtoneData(
        Creature owner,
        Creature target,
        decimal baseAmount,
        CardModel? cardSource,
        ICombatState? combatState)
    {
        Owner = owner;
        Target = target;
        CardSource = cardSource;
        CombatState = combatState;

        BaseAmount = baseAmount;
        HealAmount = baseAmount;

        ActualHealAmount = 0;
        DescendAmount = 0;
        PreventDescend = false;
    }
}