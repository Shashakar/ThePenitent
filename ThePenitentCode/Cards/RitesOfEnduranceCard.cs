using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Powers;

namespace ThePenitent.ThePenitentCode.Cards;

public sealed class RitesOfEnduranceCard() :
    ThePenitentMechanicCard
    (
        cost: 1,
        type: CardType.Power,
        rarity: CardRarity.Uncommon,
        target: TargetType.Self,
        extraHoverTips: [PenitentHoverTipFactory.Faith()]
    )
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new PowerVar<RitesOfEndurancePower>(1M),
    ];

    public PowerVar<RitesOfEndurancePower> RitesOfEndurance =>
        (PowerVar<RitesOfEndurancePower>)DynamicVars["RitesOfEndurancePower"];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CreatureCmd.TriggerAnim(Owner.Creature, "Cast", Owner.Character.CastAnimDelay);
        await PowerCmd.Apply<RitesOfEndurancePower>(
            Owner.Creature,
            RitesOfEndurance.BaseValue,
            Owner.Creature,
            this
        );
    }

    protected override void OnUpgrade()
    {
        RitesOfEndurance.UpgradeValueBy(1M);
    }
}
