using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using ThePenitent.ThePenitentCode.Commands;
using ThePenitent.ThePenitentCode.Powers;

namespace ThePenitent.ThePenitentCode.Cards;

public abstract class ThePenitentMechanicCard : ThePenitentCard
{
    private readonly decimal? _damage;
    private readonly decimal? _healAmount;
    private readonly decimal? _burden;
    private readonly decimal? _faith;
    private readonly int? _cardsToDraw;
    private readonly IReadOnlyList<CardKeyword> _keywords;

    protected ThePenitentMechanicCard(
        int cost,
        CardType type,
        CardRarity rarity,
        TargetType target,
        decimal? damage = null,
        decimal? healAmount = null,
        decimal? burden = null,
        decimal? faith = null,
        int? cardsToDraw = null,
        IEnumerable<CardKeyword>? keywords = null)
        : base(cost, type, rarity, target)
    {
        _damage = damage;
        _healAmount = healAmount;
        _burden = burden;
        _faith = faith;
        _cardsToDraw = cardsToDraw;
        _keywords = keywords?.ToArray() ?? [];
    }

    protected override IEnumerable<DynamicVar> CanonicalVars
    {
        get
        {
            if (_damage is not null)
                yield return new DamageVar(_damage.Value, ValueProp.Move);

            if (_healAmount is not null)
                yield return new HealVar(_healAmount.Value);

            if (_burden is not null)
                yield return new PowerVar<BurdenPower>(_burden.Value);

            if (_faith is not null)
                yield return new PowerVar<FaithPower>(_faith.Value);

            if (_cardsToDraw is not null)
                yield return new CardsVar(_cardsToDraw.Value);

            foreach (DynamicVar dynamicVar in AdditionalCanonicalVars)
                yield return dynamicVar;
        }
    }

    public override IEnumerable<CardKeyword> CanonicalKeywords
    {
        get
        {
            foreach (CardKeyword keyword in _keywords)
                yield return keyword;

            foreach (CardKeyword keyword in AdditionalCanonicalKeywords)
                yield return keyword;
        }
    }

    protected virtual IEnumerable<DynamicVar> AdditionalCanonicalVars => [];

    protected virtual IEnumerable<CardKeyword> AdditionalCanonicalKeywords => [];

    protected DamageVar Damage => DynamicVars.Damage;
    protected HealVar Heal => DynamicVars.Heal;
    protected CardsVar Cards => DynamicVars.Cards;

    protected PowerVar<BurdenPower> Burden => GetPowerVar<BurdenPower>();
    protected PowerVar<FaithPower> Faith => GetPowerVar<FaithPower>();

    protected PowerVar<TPower> GetPowerVar<TPower>()
        where TPower : PowerModel
    {
        string key = typeof(TPower).Name;
        return (PowerVar<TPower>)DynamicVars[key];
    }

    protected Task ApplyBurdenToSelf()
    {
        return Descend(Burden.BaseValue);
    }

    protected Task ApplyFaithToSelf()
    {
        return Ascend(Faith.BaseValue);
    }

    protected Task Descend(decimal amount)
    {
        return PenitentPowerCmd.ApplyBurden(
            Owner.Creature,
            amount,
            Owner.Creature,
            this
        );
    }

    protected Task Ascend(decimal amount)
    {
        return PenitentPowerCmd.ApplyFaith(
            Owner.Creature,
            amount,
            Owner.Creature,
            this
        );
    }

    protected Task DrawCards(PlayerChoiceContext choiceContext)
    {
        return CardPileCmd.Draw(choiceContext, Cards.BaseValue, Owner);
    }

    protected Task AttackTarget(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        ArgumentNullException.ThrowIfNull(cardPlay.Target);

        return DamageCmd.Attack(Damage.BaseValue)
            .FromCard(this)
            .Targeting(cardPlay.Target)
            .Execute(choiceContext);
    }

    protected Task AttackTarget(PlayerChoiceContext choiceContext, CardPlay cardPlay, decimal damageAmount)
    {
        ArgumentNullException.ThrowIfNull(cardPlay.Target);

        return DamageCmd.Attack(damageAmount)
            .FromCard(this)
            .Targeting(cardPlay.Target)
            .Execute(choiceContext);
    }

    protected Task AttackAllEnemies(PlayerChoiceContext choiceContext)
    {
        return DamageCmd.Attack(Damage.BaseValue)
            .FromCard(this)
            .TargetingAllOpponents(CombatState)
            .Execute(choiceContext);
    }

    protected Task AttackAllEnemies(PlayerChoiceContext choiceContext, decimal damageAmount)
    {
        return DamageCmd.Attack(damageAmount)
            .FromCard(this)
            .TargetingAllOpponents(CombatState)
            .Execute(choiceContext);
    }

    /// <summary>
    /// Heals the target. The Penitent gains Burden equal to the actual HP restored.
    /// Under the Faith/Burden scale, Faith absorbs this Burden first.
    /// </summary>
    protected async Task AtoneTarget(CardPlay cardPlay)
    {
        Creature target = cardPlay.Target ?? Owner.Creature;

        int hpBefore = target.CurrentHp;

        await CreatureCmd.Heal(target, Heal.BaseValue);

        int hpAfter = target.CurrentHp;
        int hpRestored = Math.Max(0, hpAfter - hpBefore);

        if (hpRestored <= 0)
            return;

        await PenitentPowerCmd.ApplyBurden(
            Owner.Creature,
            hpRestored,
            Owner.Creature,
            this
        );
    }

    protected Task HealTarget(CardPlay cardPlay)
    {
        Creature target = cardPlay.Target ?? Owner.Creature;
        return HealTarget(target);
    }

    protected Task HealTarget(Creature target)
    {
        return CreatureCmd.Heal(target, Heal.BaseValue);
    }
}