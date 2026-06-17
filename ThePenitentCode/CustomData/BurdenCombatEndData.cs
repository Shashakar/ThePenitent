using MegaCrit.Sts2.Core.Entities.Creatures;

namespace ThePenitent.ThePenitentCode.CustomData;

public sealed class BurdenCombatEndData
{
    public Creature Owner { get; }
    public int BurdenAmount { get; }
    public int DamageToDeal { get; set; }
    public int MaxHpLoss { get; set; }

    public BurdenCombatEndData(
        Creature owner,
        int burdenAmount,
        int damageToDeal,
        int maxHpLoss)
    {
        Owner = owner;
        BurdenAmount = burdenAmount;
        DamageToDeal = damageToDeal;
        MaxHpLoss = maxHpLoss;
    }
}
