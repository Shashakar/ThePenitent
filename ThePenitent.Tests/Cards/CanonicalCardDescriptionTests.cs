using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Exceptions;
using ThePenitent.ThePenitentCode.Scale;
using Xunit;
using CardPlay = MegaCrit.Sts2.Core.Entities.Cards.CardPlay;

namespace ThePenitent.Tests.Cards;

public sealed class CanonicalCardDescriptionTests
{
    [Fact]
    public void CanonicalMechanicCardsUseNeutralScale()
    {
        var card = new CanonicalScaleProbeCard();

        Exception? exception = Record.Exception(() => Assert.Equal(PenitentScale.Neutral, card.ExposedCurrentScale));

        Assert.IsNotType<CanonicalModelException>(exception);
    }

#pragma warning disable STS001
    private sealed class CanonicalScaleProbeCard() :
        ThePenitentCode.Cards.ThePenitentMechanicCard(
            cost: 0,
            type: CardType.Skill,
            rarity: CardRarity.Common,
            target: TargetType.Self)
    {
        public PenitentScale ExposedCurrentScale => CurrentScale;

        protected override Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
        {
            return Task.CompletedTask;
        }
    }
#pragma warning restore STS001
}
