using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace ThePenitent.ThePenitentCode.Cards;

public sealed class MartyrsResolveCard() :
    ThePenitentMechanicCard
    (
        cost: 0,
        type: CardType.Skill,
        rarity: CardRarity.Uncommon,
        target: TargetType.Self,
        block: 8M,
        cardsToDraw: 1
    )
{
    private const string HpLossKey = "HpLoss";

    protected override IEnumerable<DynamicVar> AdditionalCanonicalVars =>
    [
        new DynamicVar(HpLossKey, 2M),
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await LoseHp(DynamicVars[HpLossKey].IntValue);
        await GainSelfBlock(cardPlay);
        await DrawCards(choiceContext);
    }

    protected override void OnUpgrade()
    {
        DynamicVars[HpLossKey].UpgradeValueBy(-1M);
    }
}
