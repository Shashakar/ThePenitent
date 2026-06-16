using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Powers;

namespace ThePenitent.ThePenitentCode.Cards;

public class FinalPenanceCard() :
    ThePenitentMechanicCard
    (
        cost: 3,
        type: CardType.Attack,
        rarity: CardRarity.Rare,
        target: TargetType.AllEnemies,
        keywords: [CardKeyword.Exhaust],
        extraHoverTips: [PenitentHoverTipFactory.Burden(), PenitentHoverTipFactory.Ascend(), PenitentHoverTipFactory.Faith()]
    )
{
    protected override bool ShouldGlowRedInternal => !HasBurdenPower;

    protected override IEnumerable<DynamicVar> AdditionalCanonicalVars =>
    [
        new ExtraDamageVar(3M)
    ];

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        if (!Owner.Creature.HasPower<BurdenPower>())
            return;

        // get Burden amount
        int burdenAmount = Owner.Creature.GetPower<BurdenPower>()!.Amount;
        
        // get half of Burden rounded down
        int halfOfBurden =  burdenAmount / 2;
        
        // deal damage to self equal to half of burden rounded down
        var lostHp = await LoseHpAndGetHpLost(halfOfBurden);

        if (Owner.Creature.IsDead) return;
        
        var damageToDeal = lostHp * DynamicVars.ExtraDamage.BaseValue;
        
        // clear Burden
        await Ascend(burdenAmount);

        // deal damage to all enemies equal to 3 times the damage dealt to self
        await AttackAllEnemies(choiceContext, damageToDeal);
    }

    protected override void OnUpgrade()
    {
        DynamicVars.ExtraDamage.UpgradeValueBy(1M);
    }
}
