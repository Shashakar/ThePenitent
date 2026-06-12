# The Penitent — Character Game Design Document

## 1. Character Summary

**The Penitent** is a priest-like character built around spiritual polarity, faith, healing, burden, and dangerous self-corruption.

The character’s central design fantasy is:

> The Penitent is pulled between devotion and heresy. Faith protects and purifies. Burden empowers and corrupts. Each one consumes the other.

The Penitent has three major mechanical paths:

1. **Devotion** — leans into Faith, prevention, protection, and purification.
2. **Contrition** — uses healing and repentance to move between Faith and Burden.
3. **Heresy** — intentionally gains Burden and weaponizes spiritual danger for offensive power.

The character should feel defensive at first glance, but the best decks should not simply turtle. The strongest Penitent decks should constantly evaluate whether to remain faithful, fall into Burden, heal through damage, protect allies, or turn spiritual debt into violence.

The core gameplay question is:

> Which side of myself am I feeding this turn?

---

# 2. Design Goals

## Primary Goals

* Create a character with a distinct spiritual scale mechanic.
* Make Faith and Burden feel like opposing forces, not disconnected resources.
* Make healing powerful but not run-breaking.
* Let The Penitent heal allies in multiplayer without spreading custom resource complexity across other characters.
* Let the player weaponize downside mechanics without making those downsides trivial.
* Support multiple viable archetypes without splitting the character into disconnected mini-characters.

## Player Fantasy

The Penitent should feel like someone who can endure impossible punishment, but never for free.

They do not simply heal because they are safe.
They heal because someone must pay.
They do not simply pray because they are protected.
They pray because Faith is the only thing holding the Burden back.
They do not simply use darkness because it is evil.
They use it because the debt was already there.

## Design Warning

The Penitent must not become:

* A generic healer.
* A character with “better Block.”
* A poison/shadow damage clone.
* A character whose unique mechanic is mostly punishment.
* A multiplayer support character who forces every ally to understand Faith and Burden.
* A character with too many disconnected resources.

The character should revolve around **Faith**, **Burden**, and **Atone**.

Heresy should use Burden. It should not introduce a fourth major resource unless future testing proves the character needs it.

---

# 3. Core Mechanical Identity

The Penitent is defined by the **Faith/Burden Scale**.

Faith and Burden are two opposing sides of the same spiritual axis.

```text
Faith ← Neutral → Burden
```

Faith represents conviction, protection, and purification.

Burden represents guilt, debt, corruption, and dangerous power.

The Penitent should usually have Faith, Burden, or neither. The character should not normally hold both at the same time. When one is gained, it consumes the other first.

---

# 4. Core Mechanics

## 4.1 Faith

**Faith** is The Penitent’s positive spiritual state.

### Working Rule

> Faith prevents HP damage 1-for-1 after Block is applied.
> When The Penitent gains Faith, remove that much Burden first. Any excess becomes Faith.
> Faith persists between turns.
> At the start of The Penitent’s turn, lose half of current Faith, rounded up.

### Example: Faith Prevents Damage

The Penitent has:

* 6 Faith
* 0 Block

An enemy attacks for 4.

Result:

* Faith prevents 4 HP damage.
* Faith is reduced to 2.
* The Penitent takes 0 damage.

### Example: Faith Cleanses Burden

The Penitent has:

* 7 Burden
* 0 Faith

The Penitent gains 5 Faith.

Result:

* Burden is reduced from 7 to 2.
* No Faith is gained.

The Penitent gains another 5 Faith.

Result:

* The remaining 2 Burden is removed.
* The excess 3 becomes Faith.

### Design Intent

Faith is not normal Block. It is persistent protection and spiritual purification.

Faith should support decisions like:

* Stay Faith-positive to prevent damage.
* Use Faith to cleanse Burden.
* Spend Faith for healing or damage.
* Let Faith absorb small Heresy costs.
* Decide whether to remain safe or fall into Burden for stronger effects.

### Design Warning

Faith becomes too strong if it is too easy to stack.

Faith is powerful because it does three things:

1. Prevents HP damage.
2. Cleanses Burden.
3. Buffers against future Burden gain.

Because of that, Faith values should be modest, and Faith decay is required.

---

## 4.2 Burden

**Burden** is The Penitent’s negative spiritual state.

### Working Rule

> When The Penitent gains Burden, remove that much Faith first. Any excess becomes Burden.
> At the end of combat, The Penitent loses HP equal to Burden.
> If this would kill The Penitent, he survives at 1 HP and loses Max HP for each unpaid HP.

### Example: Burden Consumes Faith

The Penitent has:

* 6 Faith
* 0 Burden

The Penitent gains 4 Burden.

Result:

* Faith is reduced from 6 to 2.
* No Burden is gained.

The Penitent gains another 5 Burden.

Result:

* The remaining 2 Faith is removed.
* The excess 3 becomes Burden.

### Example: Burden Resolves After Combat

The Penitent ends combat with:

* 20 HP
* 8 Burden

Result:

* The Penitent loses 8 HP.
* The Penitent continues with 12 HP.

The Penitent ends combat with:

* 5 HP
* 8 Burden

Result:

* The Penitent loses 4 HP and survives at 1 HP.
* The remaining 4 unpaid HP becomes 4 Max HP loss.

### Design Intent

Burden is not merely a punishment. Burden is dangerous power.

Burden should represent:

* The cost of healing.
* The cost of heretical power.
* A source of offensive scaling.
* A threat that must eventually be answered.

Good Penitent gameplay should feel like:

> I can fall into Burden for power, but I need to win, repent, or survive the payment.

### Key Principle

Burden cannot be only a drawback. It must also be a resource.

Cards should allow the player to:

* Intentionally gain Burden for immediate power.
* Use Burden as offensive scaling.
* Spend or partially remove Burden.
* Convert Burden into damage or Block.
* Use Burden without always clearing it.
* Occasionally force a dramatic full Burden payoff.

Full Burden clearing should not be too common. If Burden is too easy to erase, Heresy becomes pure upside.

---

## 4.3 The Faith/Burden Scale

Faith and Burden should cancel each other whenever either is gained.

### Core Rule

When gaining Faith:

```text
Remove Burden first. Gain excess as Faith.
```

When gaining Burden:

```text
Remove Faith first. Gain excess as Burden.
```

### Why This Is the Core Mechanic

This transforms The Penitent from “a priest with healing and debuffs” into a character defined by spiritual polarity.

The player is not merely asking:

> How much Block do I need?

They are asking:

> Do I remain faithful, return to neutral, or fall into Burden for power?

This is the defining mechanic and should be protected.

---

# 5. Atone

**Atone** is The Penitent’s healing action.

### Working Rule

> Atone X: Heal the target for X HP. The Penitent gains Burden equal to the HP restored.

This applies whether the target is The Penitent or an ally.

Because Burden uses the Faith/Burden Scale, Faith can absorb the Burden generated by Atone.

### Example: Self Atone With Faith

The Penitent has:

* 5 Faith
* 0 Burden

The Penitent uses:

```text
Atone 7.
```

The Penitent heals 7 HP.

The Penitent gains 7 Burden.

Burden consumes 5 Faith first.

Result:

* The Penitent has 0 Faith.
* The Penitent gains 2 Burden.

### Example: Ally Atone

An ally is missing 8 HP.

The Penitent has:

* 3 Faith
* 0 Burden

The Penitent uses:

```text
Atone an ally 8.
```

The ally heals 8 HP.

The Penitent gains 8 Burden.

Burden consumes 3 Faith first.

Result:

* The ally heals 8.
* The Penitent has 0 Faith.
* The Penitent gains 5 Burden.

### Design Intent

Atone means:

> Heal someone. The Penitent carries the cost.

This is especially important for multiplayer.

The Penitent should be able to heal allies, but allies should not normally gain Faith or Burden themselves. The Penitent owns the scale. The Penitent pays the cost.

### Design Warning

Atone should usually apply Burden based on **actual HP restored**, not intended healing amount.

If a target is missing only 2 HP and The Penitent uses Atone 8, The Penitent should usually gain only 2 Burden.

This prevents overhealing from feeling needlessly punishing.

---

# 6. Multiplayer Design

## 6.1 Multiplayer Role

In multiplayer, The Penitent should function as a **martyr-support** character.

The Penitent can heal allies, protect allies indirectly, and absorb spiritual cost on behalf of others.

The multiplayer fantasy is:

> I can save you, but I carry the Burden.

## 6.2 Allies Should Not Normally Gain Faith or Burden

Originally, allies gaining Faith and Burden was considered. With the Faith/Burden Scale, that is no longer the preferred direction.

### Reason

Giving allies Faith and Burden creates too many rules questions:

* Does Faith decay on allies?
* Does Burden trigger after combat for allies?
* Can allies cleanse Burden?
* Can allies use Burden as a resource?
* Does the scale apply to all characters or only The Penitent?
* What happens when other custom characters have their own resource systems?

This spreads The Penitent’s mechanic across the whole team and makes multiplayer harder to understand.

### Decision

Faith and Burden should be **Penitent-owned mechanics** by default.

Allies may receive ordinary effects such as:

* Healing
* Block
* Strength
* Weak/Vulnerable application to enemies
* Damage prevention through normal game systems

But allies should not normally receive Faith or Burden.

## 6.3 Ally Healing Rule

When The Penitent heals an ally using a Penitent card:

> The ally receives healing.
> The Penitent gains Burden equal to the HP restored.

This keeps multiplayer simple:

* Allies only need to understand that The Penitent can heal them.
* The Penitent player manages the spiritual cost.
* The character’s identity remains self-contained.

## 6.4 Multiplayer Balance Risk

Ally healing can be extremely powerful because it smooths out the entire team’s HP pool.

If The Penitent can repeatedly heal allies and then convert that Burden into damage, the character may become both:

* The best support character.
* The best Burden-scaling damage character.

That would be a problem.

### Countermeasures

Large ally heals should usually have one or more constraints:

* Exhaust.
* Limited per combat.
* High energy cost.
* Modest healing numbers.
* Burden payoffs that do not always clear Burden.
* Full Burden clearing kept mostly to uncommon/rare cards.

### Recommended Starting Rule

Use equal Burden:

```text
Heal ally X. The Penitent gains X Burden.
```

Do not increase ally-healing Burden above the heal amount unless testing proves ally healing is too strong.

The clean rule is better.

---

# 7. Character Archetypes

The Penitent has three major archetypes.

---

## 7.1 Devotion — Faith / Prevention / Purification

### Theme

Devotion is the protective priest fantasy. It is about belief, shielding, endurance, and purification.

### Mechanical Focus

* Gain Faith.
* Stay Faith-positive.
* Use Faith to prevent damage.
* Use Faith to cleanse Burden.
* Trigger effects when Faith prevents damage.
* Spend Faith for damage or healing.

### Strengths

* Smooths out incoming damage.
* Cleanses Burden naturally.
* Creates strong defensive planning.
* Supports ally-healing by letting Faith absorb the resulting Burden.

### Weaknesses

* Can become passive if not given payoff cards.
* Risks becoming too safe if Faith numbers are too high.
* Can make Burden too easy to erase if Faith is too common.

### Example Cards

## Prayer

**Skill — Common**
Cost: 1
Gain 5 Faith.

Upgrade: Gain 7 Faith.

Design note: Faith values are lower than the old version because Faith now also cleanses Burden.

---

## Steady Conviction

**Skill — Common**
Cost: 1
Gain 5 Block and 3 Faith.

Upgrade: Gain 7 Block and 4 Faith.

---

## Zealous Retort

**Power — Uncommon**
Cost: 1
Whenever Faith prevents damage, deal 3 damage to the attacker.

Upgrade: Deal 4 damage.

---

## Crisis of Faith

**Attack — Uncommon**
Cost: 1
Remove all Faith. Deal damage equal to the Faith removed.

Upgrade: Deal damage equal to the Faith removed + 5.

---

## Leap of Faith

**Skill — Uncommon**
Cost: 1
Remove all Faith. Heal HP equal to half the Faith removed. Exhaust.

Upgrade: Heal HP equal to half the Faith removed, rounded up. Exhaust.

Design note: Under the scale model, this does not need to generate Burden. Spending all Faith is already the cost.

---

## 7.2 Contrition — Atone / Healing / Repentance

### Theme

Contrition is the healing priest fantasy, but with a cost. The Penitent can mend wounds, including allies’ wounds, but he personally carries the spiritual debt.

### Mechanical Focus

* Atone self.
* Atone allies.
* Gain Burden through healing.
* Use Faith to absorb Atone-generated Burden.
* Move back from Burden toward Faith.
* Use controlled Burden as a temporary cost.

### Strengths

* Can recover after failed defensive turns.
* Can save allies in multiplayer.
* Creates strong comeback potential.
* Naturally moves the scale from Faith toward Burden.

### Weaknesses

* Can break attrition if healing is too efficient.
* Can become too strong in multiplayer if ally healing is repeatable.
* Needs careful interaction with Burden payoffs.

### Example Cards

## Mend Wounds

**Skill — Common**
Cost: 1
Atone 5.

Upgrade: Atone 7.

---

## Intercession

**Skill — Uncommon**
Cost: 1
Atone an ally 6. Exhaust.

Upgrade: Atone an ally 9. Exhaust.

---

## Shared Prayer

**Skill — Common**
Cost: 1
Gain 4 Faith. Target ally gains 5 Block.

Upgrade: Gain 5 Faith. Target ally gains 7 Block.

Design note: Allies receive normal Block, not Faith.

---

## Confess

**Skill — Common**
Cost: 1
Gain 5 Faith. Draw 1 card.

Upgrade: Gain 7 Faith. Draw 1 card.

Design note: Under the scale model, this replaces direct “Remove Burden” at common rarity. It cleanses Burden by gaining Faith.

---

## Absolution

**Skill — Uncommon**
Cost: 2
Gain Faith equal to your Burden. Gain 6 Block.

Upgrade: Gain Faith equal to your Burden. Gain 10 Block.

Design note: This returns the Penitent to neutral, not Faith-positive. If stronger repentance is wanted, use “Gain Faith equal to twice your Burden” on a rare.

---

## Gentle Mercy

**Skill — Rare**
Cost: 1
Heal 6. This healing does not generate Burden. Exhaust.

Upgrade: Heal 9. This healing does not generate Burden. Exhaust.

Design note: True healing should be rare.

---

## 7.3 Heresy — Burden Offense / Corruption

### Theme

Heresy is the offensive priest fantasy. This path is not about healing or protection. It is about using spiritual danger, guilt, and debt as a weapon.

The Penitent stops asking for forgiveness and starts making enemies carry the consequences.

### Mechanical Focus

* Gain Burden intentionally.
* Burn through Faith for stronger effects.
* Fall into Burden for above-rate attacks.
* Scale damage based on current Burden.
* Trigger effects when Burden is gained.
* Spend or partially clear Burden for damage.

### Strengths

* Strong burst damage.
* Strong scaling potential.
* Turns the character’s downside into offense.
* Creates high-risk, high-reward gameplay.

### Weaknesses

* Can make Burden too easy to exploit if overtuned.
* Can erase the character’s downside if Burden clearing is too common.
* Faith can absorb small Burden costs, making some Heresy cards too safe.
* Needs careful damage ratios.

### Design Rule

Heresy should not introduce a separate “Shadow” resource in the first version.

Use Burden.

The offensive identity should be:

> Gain Burden now. Kill enemies before the debt comes due.

### Example Cards

## Blasphemous Bolt

**Attack — Common**
Cost: 1
Deal 13 damage. Gain 4 Burden.

Upgrade: Deal 17 damage. Gain 4 Burden.

Design note: If the player has Faith, the Burden cost consumes Faith first. If not, it pushes the player into Burden.

---

## Heavy Soul

**Attack — Common**
Cost: 1
Deal 6 damage. If you have Burden, deal 6 additional damage.

Upgrade: Deal 8 damage. If you have Burden, deal 8 additional damage.

---

## Dark Whisper

**Skill — Common**
Cost: 0
Gain 3 Burden. Draw 1 card.

Upgrade: Gain 2 Burden. Draw 1 card.

---

## Fall From Grace

**Attack — Uncommon**
Cost: 1
Lose all Faith. Gain that much Burden. Deal damage equal to twice the Burden gained.

Upgrade: Deal damage equal to twice the Burden gained + 5.

Design note: This is a true Heresy card because it forces the player across the scale.

---

## Grim Certainty

**Power — Uncommon**
Cost: 1
Whenever you gain Burden, deal 2 damage to a random enemy.

Upgrade: Deal 3 damage.

Design note: This should trigger only when Burden is actually gained after Faith is consumed, not when Burden is fully absorbed by Faith.

---

## Black Benediction

**Attack — Uncommon**
Cost: 2
Deal 24 damage. Gain 8 Burden.

Upgrade: Deal 32 damage. Gain 8 Burden.

---

## Ruinous Confession

**Attack — Uncommon**
Cost: 1
Remove up to 6 Burden. Deal damage equal to twice the Burden removed.

Upgrade: Remove up to 8 Burden.

Design note: This is capped to prevent ally healing from becoming an easy setup for huge full-clear damage.

---

## Final Penance

**Attack — Rare**
Cost: 2
Lose HP equal to half your Burden, rounded down. Deal damage to all enemies equal to three times the HP lost. Clear your Burden. Exhaust.

Upgrade: Deal damage equal to four times the HP lost.

---

# 8. How the Three Archetypes Interlock

The Penitent should not feel like three unrelated characters. The three trees should overlap through the Faith/Burden Scale.

## Devotion + Contrition

Faith absorbs the Burden created by Atone.

Example:

* Gain Faith with Prayer.
* Use Atone to heal yourself or an ally.
* The Burden generated by Atone consumes Faith first.

## Contrition + Heresy

Atone generates Burden. Heresy cards use Burden for power.

Example:

* Use Atone to survive or save an ally.
* Fall into Burden.
* Use Heavy Soul or Final Penance to turn that Burden into offense.

## Devotion + Heresy

Faith can absorb small Heresy costs or be sacrificed for stronger effects.

Example:

* Blasphemous Bolt gains Burden, but Faith absorbs it.
* Fall From Grace converts Faith into Burden for a large attack.

## Full Triangle

The ideal Penitent decision loop:

1. Gain Faith to prevent damage and cleanse Burden.
2. Use Atone to heal yourself or an ally when needed.
3. Atone generates Burden, consuming Faith first.
4. If Faith runs out, Burden accumulates.
5. Use Burden for offensive Heresy payoffs, or repent back toward Faith.
6. Decide whether to remain safe, return to neutral, or fall deeper into Burden for power.

---

# 9. Starting Deck Proposal

The starting deck should teach the character slowly.

Do not include too many unique mechanics immediately. The player should understand the scale before being asked to optimize it.

## Proposed Starter Deck

* 4x Strike
* 4x Defend
* 1x Prayer
* 1x Mend Wounds

## Starter Card: Prayer

**Skill**
Cost: 1
Gain 5 Faith.

Upgrade: Gain 7 Faith.

## Starter Card: Mend Wounds

**Skill**
Cost: 1
Atone 5.

Upgrade: Atone 7.

### Why This Works

Prayer introduces Faith.

Mend Wounds introduces Atone and Burden.

The player naturally sees:

* Faith protects.
* Healing creates Burden.
* Burden consumes Faith first.
* If Faith is gone, Burden remains.

## Safer Starter Deck Alternative

* 4x Strike
* 3x Defend
* 1x Prayer
* 1x Mend Wounds
* 1x Confess

This version makes the scale clearer but may overload the starter deck slightly.

---

# 10. Starter Relic Proposal

## Current Recommended Starter Relic

## Fractured Halo

### Effect

At the start of each combat, gain 4 Faith.

### Design Intent

The starter relic nudges The Penitent toward Devotion at the start of combat, giving the player a small Faith buffer before healing or Heresy pushes them toward Burden.

The previous value of 6 Faith may be too high under the scale model because Faith now:

* Prevents damage.
* Cleanses Burden.
* Absorbs Atone-generated Burden.
* Absorbs Heresy-generated Burden.

Start with 4 Faith and increase only if early testing feels too punishing.

---

# 11. Keyword and Status Definitions

## Faith

Faith prevents HP damage after Block.

When The Penitent gains Faith, remove that much Burden first. Any excess becomes Faith.

At the start of The Penitent’s turn, lose half of current Faith, rounded up.

## Burden

When The Penitent gains Burden, remove that much Faith first. Any excess becomes Burden.

At combat’s end, The Penitent loses HP equal to Burden.

If this would kill The Penitent, he survives at 1 HP and loses Max HP for each unpaid HP.

## Atone

Atone X: Heal the target for X HP. The Penitent gains Burden equal to the HP restored.

For ally-targeted Atone, the ally heals, but The Penitent still gains the Burden.

## Heresy

Unofficial design term.

Cards that intentionally gain Burden, consume Faith, or reward being Burden-positive.

This does not need to be a formal in-game keyword for the first prototype.

---

# 12. Card Design Guidelines

## Faith Guidelines

Faith is strong because it has multiple jobs.

Faith:

* Prevents HP damage.
* Cleanses Burden.
* Absorbs Atone-generated Burden.
* Absorbs Heresy-generated Burden.
* Can be spent by certain cards.

Because of this, Faith values should be lower than they were in the separate-resource model.

Good common Faith values:

* 3–6 Faith.
* 5–7 Faith on clean single-purpose cards.
* Higher values only with cost, Exhaust, or rarity.

Avoid common cards that generate large amounts of Faith with no drawback.

## Burden Guidelines

Burden is dangerous but valuable.

Burden:

* Threatens HP and Max HP after combat.
* Represents falling toward Heresy.
* Fuels damage and payoff cards.
* Is softened by Faith.

Burden-generating cards can be above-rate, but not so efficient that the player always wants to be Burden-positive.

Good common Burden values:

* 2–5 Burden on cheap Heresy cards.
* 6–8 Burden on stronger uncommon attacks.
* 10+ Burden mostly on rare or dangerous effects.

## Atone Guidelines

Atone should usually generate Burden equal to actual HP restored.

Common Atone values:

* Atone 4–6.
* Atone 7+ should usually be upgraded, uncommon, or constrained.

Ally Atone should often Exhaust if the number is large.

Avoid repeatable, cheap, high-value ally healing unless testing proves it is safe.

## Burden Payoff Guidelines

Burden payoffs are dangerous because they can turn the cost of healing into damage.

Suggested starting ratios:

* Common: Burden enables conditional damage but usually does not clear itself.
* Uncommon: remove up to a capped amount of Burden for damage.
* Rare: large full Burden payoff, usually Exhaust or with HP cost.

Avoid making full Burden clearing too common.

## Multiplayer Guidelines

In multiplayer:

* The Penitent owns Faith and Burden.
* Allies should normally receive normal game effects, not Penitent-specific scale resources.
* The Penitent may heal allies through Atone.
* The Penitent takes the Burden for ally healing.
* Large ally heals should be limited.

---

# 13. Example Card Pool Skeleton

This is not a full final card list. It is a prototype skeleton to validate the mechanic.

## Common Cards

### Prayer

Gain 5 Faith.

### Mend Wounds

Atone 5.

### Confess

Gain 5 Faith. Draw 1 card.

### Blasphemous Bolt

Deal 13 damage. Gain 4 Burden.

### Heavy Soul

Deal 6 damage. If you have Burden, deal 6 additional damage.

### Steady Conviction

Gain 5 Block and 3 Faith.

### Dark Whisper

Gain 3 Burden. Draw 1 card.

### Shared Prayer

Gain 4 Faith. Target ally gains 5 Block.

---

## Uncommon Cards

### Leap of Faith

Remove all Faith. Heal HP equal to half the Faith removed. Exhaust.

### Intercession

Atone an ally 6. Exhaust.

### Absolution

Gain Faith equal to your Burden. Gain 6 Block.

### Penance

Remove up to 6 Burden. Deal damage equal to twice the Burden removed.

### Zealous Retort

Whenever Faith prevents damage, deal 3 damage to the attacker.

### Crisis of Faith

Remove all Faith. Deal damage equal to the Faith removed.

### Fall From Grace

Lose all Faith. Gain that much Burden. Deal damage equal to twice the Burden gained.

### Grim Certainty

Whenever you gain Burden, deal 2 damage to a random enemy.

### Black Benediction

Deal 24 damage. Gain 8 Burden.

---

## Rare Cards

### Gentle Mercy

Heal 6. This healing does not generate Burden. Exhaust.

### Dark Communion

At the start of your turn, gain 2 Burden and draw 1 additional card.

### Final Penance

Lose HP equal to half your Burden. Deal damage to all enemies equal to three times HP lost. Clear your Burden. Exhaust.

### Martyrdom

The first time each turn you would gain Burden, gain that much Block.

### Revelation Through Pain

Deal damage equal to your Burden to all enemies. Atone 6. Exhaust.

---

# 14. Upgrade Philosophy

Upgrades should usually improve one of the following:

* More Faith.
* More Atone.
* Less Burden for the same effect.
* More controlled Burden generation.
* Better Burden conversion.
* Lower cost.
* Better ally support.
* Remove Exhaust only very carefully.

Good upgrade examples:

* Gain 5 Faith → Gain 7 Faith.
* Atone 5 → Atone 7.
* Deal 13 / Gain 4 Burden → Deal 17 / Gain 4 Burden.
* Gain 3 Burden / Draw 1 → Gain 2 Burden / Draw 1.
* Remove up to 6 Burden → Remove up to 8 Burden.
* Cost 2 → Cost 1 on rare powers.

Risky upgrade examples:

* Atone 5 → Heal 5 with no Burden.
* Faith no longer decays.
* Burden no longer triggers this combat.
* Full Burden clearing on common cards.
* Repeatable large ally healing without Exhaust.

Those may be acceptable on rares, relics, or events, but not as normal low-rarity upgrades.

---

# 15. Relic Ideas

## Fractured Halo

Starter Relic.

At the start of each combat, gain 4 Faith.

---

## Censer of Contrition

At combat’s end, Burden deals 25% less HP loss.

Design warning: This is powerful because it softens the main downside.

---

## Thorned Rosary

Whenever you actually gain Burden, deal 1 damage to all enemies.

Design note: Should trigger only when Burden remains after Faith is consumed.

---

## Ash-Stained Veil

The first 3 Burden you would gain each combat is prevented.

Design warning: This overlaps with Faith’s role. Test carefully.

---

## Martyr’s Bell

Whenever Faith prevents damage, gain 1 temporary Strength this turn.

---

## Sealed Confessional

At the start of combat, gain 3 Faith. If you have Burden, gain 5 Faith instead.

---

## Heretic’s Candle

Heresy cards deal 3 additional damage, but whenever you play one, gain 1 Burden.

Note: Only use this if Heresy becomes a real internal card tag.

---

# 16. Potion Ideas

## Bottled Prayer

Gain 10 Faith.

## Draught of Mercy

Atone 8.

## Ashen Tonic

Gain Faith equal to twice your Burden.

## Heretic’s Ichor

Gain 10 Burden. Deal 20 damage to all enemies.

## Martyr’s Draught

Atone an ally 10. Gain 10 Burden. Exhaust-equivalent potion effect.

---

# 17. Balance Risks

## Risk 1: Faith Becomes Too Universal

Faith prevents damage, cleanses Burden, and absorbs new Burden.

Countermeasures:

* Keep Faith values modest.
* Keep Faith decay.
* Avoid large common Faith cards.
* Avoid relics that generate too much Faith every combat.

## Risk 2: Burden Becomes Too Easy To Erase

Because Faith removes Burden, every Faith card is also a Burden management card.

Countermeasures:

* Reduce Faith numbers.
* Make major Burden-cleansing effects uncommon or rare.
* Ensure Heresy cards can push past Faith meaningfully.
* Use cards like Fall From Grace to force the player across the scale.

## Risk 3: Atone Breaks Attrition

Healing is powerful because HP persists between encounters.

Countermeasures:

* Atone creates Burden equal to actual HP restored.
* True healing without Burden should be rare.
* Ally Atone should be limited or Exhausting.
* Burden must remain dangerous after combat.

## Risk 4: Multiplayer Healing Becomes Too Strong

The Penitent may preserve the whole team’s HP pool.

Countermeasures:

* Large ally heals should Exhaust.
* Keep ally Atone numbers conservative.
* Avoid too many cards that fully clear Burden.
* Burden payoff cards should not always remove Burden.

## Risk 5: Heresy Turns Burden Into Pure Upside

If Burden converts too efficiently into damage, Atone becomes a setup tool for offense instead of a cost.

Countermeasures:

* Full Burden clearing should be uncommon or rare.
* Some Burden-scaling cards should not remove Burden.
* Common Burden payoffs should be conditional or capped.
* Large payoffs should Exhaust, cost HP, or require setup.

## Risk 6: Cards Feel Like They Do Nothing

Under the scale, gaining Faith while Burdened may result in no visible Faith gained. Gaining Burden while Faithful may result in no visible Burden gained.

Countermeasures:

* Strong VFX for cancellation.
* Clear tooltip language.
* Power flashing when consumed.
* Card text and keyword descriptions must be direct.

---

# 18. Prototype Implementation Plan

## Phase 1 — Core Systems

Implement:

* The Penitent character.
* Faith power/status.
* Burden power/status.
* Faith damage prevention.
* Faith decay.
* Burden end-of-combat resolution.
* Faith/Burden scale helper command.
* Atone helper action.

Prototype cards:

* Prayer
* Mend Wounds
* Confess
* Blasphemous Bolt
* Heavy Soul
* Dark Whisper
* Leap of Faith
* Intercession
* Fall From Grace
* Ruinous Confession

Goal:

> Prove that the Faith/Burden Scale creates an enjoyable character loop.

---

## Phase 2 — Multiplayer Validation

Implement or test:

* Atone self.
* Atone ally.
* The Penitent takes Burden from ally healing.
* Allies do not receive Faith or Burden.
* Faith absorbs ally-healing Burden.
* Burden payoff cards after ally healing.

Goal:

> Prove that The Penitent can support allies without making the whole party manage Penitent-specific mechanics.

---

## Phase 3 — First Card Pool

Add roughly:

* 8 common cards.
* 8 uncommon cards.
* 4 rare cards.
* 3 relics.
* 2 potions.

Goal:

> Determine whether Devotion, Contrition, and Heresy each have enough support to form partial decks.

---

## Phase 4 — Balance Pass

Test for:

* Too much sustain.
* Too much Faith stacking.
* Burden feeling too punitive.
* Burden feeling too easy to erase.
* Heresy making Burden too beneficial.
* Ally healing being too strong.
* Starter deck frustration.
* Whether Faith/Burden cancellation is understandable.

Important test cases:

* Low HP with high Burden.
* High Faith stacking.
* Faith absorbing Atone Burden.
* Faith absorbing Heresy Burden.
* Burden-to-damage conversion.
* Ally Atone into Burden payoff.
* Long fights.
* Multi-enemy fights.
* Elite fights.
* Boss fights.
* Multiplayer fights where multiple allies need healing.

---

# 19. Implementation Notes

## Centralize Scale Logic

The Faith/Burden cancellation rule should not be implemented separately in every card.

Use a dedicated helper command or service.

Recommended structure:

```text
Cards
  call ThePenitentMechanicCard helpers

ThePenitentMechanicCard
  calls PenitentPowerCmd.ApplyFaith / ApplyBurden / Atone

PenitentPowerCmd
  owns the Faith/Burden scale cancellation logic

FaithPower
  owns Faith damage prevention and Faith decay

BurdenPower
  owns end-of-combat Burden punishment
```

## Important Rule

Cards should not normally call raw power application directly:

```csharp
PowerCmd.Apply<FaithPower>
PowerCmd.Apply<BurdenPower>
```

They should call Penitent-specific helpers:

```csharp
PenitentPowerCmd.ApplyFaith(...)
PenitentPowerCmd.ApplyBurden(...)
```

Only use raw power application for rare effects that explicitly bypass the scale.

## Atone Implementation

Atone should usually:

1. Read target HP before healing.
2. Heal target.
3. Read target HP after healing.
4. Calculate actual HP restored.
5. Apply Burden to The Penitent equal to actual HP restored.

This prevents overhealing from generating excess Burden.

## Trigger Semantics

Effects that say “Whenever you gain Burden” should trigger only when Burden is actually gained after Faith cancellation.

Example:

The Penitent has 5 Faith.
A card gives 3 Burden.
Faith drops to 2.
No Burden is gained.

Result:

* “Whenever you gain Burden” should not trigger.

The Penitent has 2 Faith.
A card gives 5 Burden.
Faith drops to 0.
3 Burden is gained.

Result:

* “Whenever you gain Burden” should trigger once for 3 Burden.

This matters for balance and clarity.

---

# 20. Open Design Questions

These should be answered through prototyping, not theory alone.

## Question 1

Should Faith decay at the start of the player turn or end of the player turn?

Initial recommendation:

> Start of player turn. Lose half of current Faith, rounded up.

This makes leftover Faith temporary but still useful across enemy turns.

## Question 2

Should Atone apply Burden based on intended healing or actual HP restored?

Initial recommendation:

> Actual HP restored.

This is fairer and avoids punishing overhealing too harshly.

## Question 3

Should allies ever receive Faith or Burden?

Initial recommendation:

> Not by default.

The Penitent should own the scale. Allies can receive healing, Block, or other ordinary effects.

## Question 4

Should enemies receive Burden?

Initial recommendation:

> Not in the first prototype.

Transferring Burden to enemies is flavorful, but it risks trivializing the scale. Add later only if the character needs it.

## Question 5

Should Heresy be a formal card tag?

Initial recommendation:

> Not in the first prototype.

Start with Burden synergy. Add a Heresy tag later only if relics, powers, or events need it.

## Question 6

Should Burden resolve after combat victory or any combat end?

Initial recommendation:

> Prefer victory/survived-combat resolution.

This should be tested against multiplayer combat flow. Avoid accidental Burden resolution during death, aborted combat, or unusual room transitions.

---

# 21. Current Best Version

The strongest version of The Penitent is not simply “healer priest,” “shield priest,” or “shadow priest.”

The strongest version is:

> A priest divided between Faith and Burden.

Faith protects.
Burden empowers.
Atone saves others at personal cost.
Heresy turns spiritual debt into violence.

The Penitent should constantly ask the player:

> Do I endure, repent, or fall deeper for power?

That is the character’s identity.
