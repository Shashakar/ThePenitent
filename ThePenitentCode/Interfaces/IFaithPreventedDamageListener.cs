using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace ThePenitent.ThePenitentCode;

public interface IFaithPreventedDamageListener
{
    Task OnFaithPreventedDamage(
        PlayerChoiceContext choiceContext,
        Creature attacker,
        int preventedAmount);
}