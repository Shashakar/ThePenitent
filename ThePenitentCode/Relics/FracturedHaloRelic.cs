using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using ThePenitent.ThePenitentCode.Commands;
using ThePenitent.ThePenitentCode.Powers;

namespace ThePenitent.ThePenitentCode.Relics;

public class FracturedHaloRelic() : ThePenitentRelic
{
    public override RelicRarity Rarity =>
        RelicRarity.Starter;

    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new PowerVar<FaithPower>(6M)
    ];

    public override RelicModel GetUpgradeReplacement() =>
        ModelDb.Relic<CompletedHaloRelic>();

    public override async Task BeforeSideTurnStart(PlayerChoiceContext choiceContext, CombatSide side, IReadOnlyList<Creature> participants,
        ICombatState combatState)
    {
        if (side != Owner.Creature.Side || combatState.RoundNumber > 1)
            return;

        Flash();

        await PenitentPowerCmd.ApplyFaith(
            Owner.Creature,
            Faith.BaseValue,
            Owner.Creature,
            null,
            combatState
        );
    }
}
