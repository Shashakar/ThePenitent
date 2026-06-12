using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace ThePenitent.ThePenitentCode.Cards;

public sealed class BlasphemousBoltCard : ThePenitentMechanicCard
{
    public BlasphemousBoltCard()
        : base(
            cost: 1,
            type: CardType.Attack,
            rarity: CardRarity.Common,
            target: TargetType.AnyEnemy,
            damage: 13M,
            burden: 4M)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        // Apply Burden first so the cost is paid even if the attack kills the last enemy.
        await ApplyBurdenToSelf();

        await AttackTarget(choiceContext, cardPlay);
    }

    protected override void OnUpgrade()
    {
        Damage.UpgradeValueBy(3M);
        Burden.UpgradeValueBy(1M);
    }
}