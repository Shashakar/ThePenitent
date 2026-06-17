using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Powers;

namespace ThePenitent.ThePenitentCode.Cards;

public sealed class CrownOfThornsCard() :
    ThePenitentMechanicCard
    (
        cost: 2,
        type: CardType.Power,
        rarity: CardRarity.Rare,
        target: TargetType.Self,
        extraHoverTips: [PenitentHoverTipFactory.Burden()]
    )
{
    private const string DealsDamageKey = "DealsDamage";

    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new PowerVar<CrownOfThornsPower>(1M),
        new DynamicVar(DealsDamageKey, 0M),
    ];

    public PowerVar<CrownOfThornsPower> CrownOfThorns =>
        (PowerVar<CrownOfThornsPower>)DynamicVars["CrownOfThornsPower"];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CreatureCmd.TriggerAnim(Owner.Creature, "Cast", Owner.Character.CastAnimDelay);
        if (IsUpgraded)
        {
            await PowerCmd.Apply<CrownOfThornsVengefulPower>(
                Owner.Creature,
                1M,
                Owner.Creature,
                this
            );
        }
        else
        {
            await PowerCmd.Apply<CrownOfThornsPower>(
                Owner.Creature,
                CrownOfThorns.BaseValue,
                Owner.Creature,
                this
            );
        }
    }

    protected override void OnUpgrade()
    {
        DynamicVars[DealsDamageKey].UpgradeValueBy(1M);
    }
}
