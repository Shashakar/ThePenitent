using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Powers;

namespace ThePenitent.ThePenitentCode.Cards;

public sealed class AshenEdictCard() :
    ThePenitentMechanicCard
    (
        cost: 1,
        type: CardType.Power,
        rarity: CardRarity.Uncommon,
        target: TargetType.Self,
        extraHoverTips: [PenitentHoverTipFactory.Ascend(), PenitentHoverTipFactory.Prophet()]
    )
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new PowerVar<AshenEdictPower>(1M)
    ];

    public PowerVar<AshenEdictPower> AshenEdict =>
        (PowerVar<AshenEdictPower>)DynamicVars["AshenEdictPower"];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CreatureCmd.TriggerAnim(Owner.Creature, "Cast", Owner.Character.CastAnimDelay);
        await PowerCmd.Apply<AshenEdictPower>(
            choiceContext,
            Owner.Creature,
            AshenEdict.BaseValue,
            Owner.Creature,
            this
        );
    }

    protected override void OnUpgrade()
    {
        EnergyCost.UpgradeBy(-1);
    }
}
