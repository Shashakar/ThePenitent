using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Powers;

namespace ThePenitent.ThePenitentCode.Cards;


public class GrimUncertaintyCard() : 
    ThePenitentMechanicCard
    (
        cost: 1,
        type: CardType.Power, 
        rarity: CardRarity.Uncommon,
        target: TargetType.Self, 
        extraHoverTips: [PenitentHoverTipFactory.Descend(), PenitentHoverTipFactory.Burden()]
    )
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new PowerVar<GrimCertaintyPower>(2M),
    ];
    
    public PowerVar<GrimCertaintyPower> GrimCertainty =>
        (PowerVar<GrimCertaintyPower>)DynamicVars["GrimCertaintyPower"];

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await CreatureCmd.TriggerAnim(Owner.Creature, "Cast", Owner.Character.CastAnimDelay);
        await PowerCmd.Apply<GrimCertaintyPower>(
            choiceContext,
            Owner.Creature,
            GrimCertainty.BaseValue,
            Owner.Creature,
            this
        );
    }

    protected override void OnUpgrade()
    {
        GrimCertainty.UpgradeValueBy(1M);
    }
}