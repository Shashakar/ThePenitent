using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using ThePenitent.ThePenitentCode.Commands;
using ThePenitent.ThePenitentCode.Extensions;
using ThePenitent.ThePenitentCode.Powers;
using ThePenitent.ThePenitentCode.Scale;

namespace ThePenitent.ThePenitentCode.Relics;

public sealed class CrackedCenserRelic : ThePenitentRelic
{
    public override RelicRarity Rarity => RelicRarity.Common;

    public override string PackedIconPath => "cracked_censor_relic.png".RelicImagePath();

    protected override string PackedIconOutlinePath => "relic_outline.png".RelicImagePath();

    protected override string BigIconPath => "cracked_censor_relic.png".BigRelicImagePath();

    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new PowerVar<FaithPower>(4M)
    ];

    public override async Task BeforeSideTurnStart(PlayerChoiceContext choiceContext, CombatSide side, IReadOnlyList<Creature> participants,
        ICombatState combatState)
    {
        if (side != Owner.Creature.Side || combatState.RoundNumber > 1)
            return;

        if (!PenitentScaleTracker.IsPenitent(Owner.Creature))
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
