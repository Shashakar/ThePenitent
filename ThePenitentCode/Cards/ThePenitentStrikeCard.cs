using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.Powers;

namespace ThePenitent.ThePenitentCode.Cards;


public sealed class ThePenitentStrikeCard() : 
    ThePenitentCard
    (
        cost: 1,
        type: CardType.Attack,
        rarity: CardRarity.Basic,
        target: TargetType.AnyEnemy
    )
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new DamageVar(6M, ValueProp.Move),
    ];

    protected override HashSet<CardTag> CanonicalTags =>
        [CardTag.Strike];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        ArgumentNullException.ThrowIfNull(cardPlay.Target, "cardPlay.Target");
        await DamageCmd.Attack(DynamicVars.Damage.BaseValue).FromCard(this).Targeting(cardPlay.Target).WithHitFx("vfx/vfx_attack_slash").Execute(choiceContext);
    }
    
    protected override void OnUpgrade()
    { 
        DynamicVars.Damage.UpgradeValueBy(3M);
    }
}