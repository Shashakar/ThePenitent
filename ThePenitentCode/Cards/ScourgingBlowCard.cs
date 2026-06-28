using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Scale;

namespace ThePenitent.ThePenitentCode.Cards;

public sealed class ScourgingBlowCard() :
    ThePenitentMechanicCard
    (
        cost: 1,
        type: CardType.Attack,
        rarity: CardRarity.Common,
        target: TargetType.AnyEnemy,
        damage: 7M,
        extraHoverTips:
        [
            HoverTipFactory.FromPower<WeakPower>(),
            PenitentHoverTipFactory.Heretic()
        ]
    )
{
    protected override bool ShouldGlowGoldInternal => PenitentScaleTracker.IsHeretic(Owner.Creature);

    protected override IEnumerable<DynamicVar> AdditionalCanonicalVars =>
    [
        new PowerVar<WeakPower>(1M),
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await AttackTarget(choiceContext, cardPlay);

        if (PenitentScaleTracker.IsHeretic(Owner.Creature))
            await ApplyWeak(
                choiceContext,
                cardPlay, 
                DynamicVars.Weak.BaseValue);
    }

    protected override void OnUpgrade()
    {
        Damage.UpgradeValueBy(3M);
    }
}
