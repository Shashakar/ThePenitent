using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using ThePenitent.ThePenitentCode.HoverTips;

namespace ThePenitent.ThePenitentCode.Cards;

public sealed class RuinousConfessionCard() :
    ThePenitentMechanicCard
    (
        cost: 3,
        type: CardType.Attack,
        rarity: CardRarity.Rare,
        target: TargetType.AllEnemies,
        keywords: [CardKeyword.Exhaust],
        extraHoverTips: [PenitentHoverTipFactory.Ascend(), PenitentHoverTipFactory.Burden()]
    )
{
    protected override bool ShouldGlowRedInternal => !HasBurdenPower;

    protected override IEnumerable<DynamicVar> AdditionalCanonicalVars =>
    [
        new ExtraDamageVar(2M)
    ];

    protected override void AddExtraArgsToContextualDescription(LocString description)
    {
        decimal burden = CombatState is not null
            ? BurdenAmount
            : 0M;

        description.Add("BurdenAmount", burden);
        description.Add("DamageAmount", burden * DynamicVars.ExtraDamage.BaseValue);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        int ascendedAmount = (int)BurdenAmount;

        if (ascendedAmount <= 0)
            return;

        decimal damageAmount = ascendedAmount * DynamicVars.ExtraDamage.BaseValue;

        // Ascend first. Since the amount equals current Burden,
        // this should normally clear Burden and generate no Faith.
        await Ascend(ascendedAmount);

        await AttackAllEnemies(choiceContext, damageAmount);
    }

    protected override void OnUpgrade()
    {
        EnergyCost.UpgradeBy(-1);
    }
}
