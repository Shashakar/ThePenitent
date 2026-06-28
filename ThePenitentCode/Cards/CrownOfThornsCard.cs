using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
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
        extraHoverTips: [PenitentHoverTipFactory.Burden(), PenitentHoverTipFactory.Heretic()]
    )
{

    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new PowerVar<CrownOfThornsPower>(1M),
        new PowerVar<ThornsPower>(2M),
    ];

    public PowerVar<CrownOfThornsPower> CrownOfThorns =>
        (PowerVar<CrownOfThornsPower>)DynamicVars["CrownOfThornsPower"];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CreatureCmd.TriggerAnim(Owner.Creature, "Cast", Owner.Character.CastAnimDelay);

        await PowerCmd.Apply<CrownOfThornsPower>(
            choiceContext,
            Owner.Creature,
            CrownOfThorns.BaseValue,
            Owner.Creature,
            this
        );
        
        await PowerCmd.Apply<ThornsPower>(
            choiceContext,
            Owner.Creature,
            DynamicVars["ThornsPower"].BaseValue,
            Owner.Creature,
            this
        );
        
    }

    protected override void OnUpgrade()
    {
        DynamicVars["ThornsPower"].UpgradeValueBy(1M);
    }
}
