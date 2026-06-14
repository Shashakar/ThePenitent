using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Powers;

namespace ThePenitent.ThePenitentCode.Cards;

public class ZealousRetortCard() : ThePenitentMechanicCard(1,
    CardType.Power, CardRarity.Uncommon,
    TargetType.Self, extraHoverTips: [PenitentHoverTipFactory.Faith()])
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new PowerVar<ZealousRetortPower>(3M),
    ];
    
    public PowerVar<ZealousRetortPower> ZealousRetort =>
        (PowerVar<ZealousRetortPower>)DynamicVars["ZealousRetortPower"];

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await CreatureCmd.TriggerAnim(Owner.Creature, "Cast", Owner.Character.CastAnimDelay);
        await PowerCmd.Apply<ZealousRetortPower>(
            Owner.Creature,
            ZealousRetort.BaseValue,
            Owner.Creature,
            this
        );
    }

    protected override void OnUpgrade()
    {
        ZealousRetort.UpgradeValueBy(1M);
    }
}