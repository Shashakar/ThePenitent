using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using ThePenitent.ThePenitentCode.HoverTips;
using ThePenitent.ThePenitentCode.Scale;

namespace ThePenitent.ThePenitentCode.Cards;

public sealed class MartyrsResolveCard() :
    ThePenitentMechanicCard
    (
        cost: 0,
        type: CardType.Skill,
        rarity: CardRarity.Uncommon,
        target: TargetType.Self,
        block: 8M,
        cardsToDraw: 1,
        extraHoverTips: [PenitentHoverTipFactory.Penitent()]
    )
{
    private const string HpLossKey = "HpLoss";

    protected override IEnumerable<DynamicVar> AdditionalCanonicalVars =>
    [
        new DynamicVar(HpLossKey, 2M),
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        int hpLoss = DynamicVars[HpLossKey].IntValue;
        if (PenitentScaleTracker.IsPenitent(Owner.Creature))
            hpLoss = Math.Max(0, hpLoss - 1);

        await LoseHp(hpLoss);
        await GainSelfBlock(cardPlay);
        await DrawCards(choiceContext);
    }

    protected override void OnUpgrade()
    {
        DynamicVars[HpLossKey].UpgradeValueBy(-1M);
    }
}
