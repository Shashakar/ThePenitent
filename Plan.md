# The Penitent — Character Design README

## Summary

**The Penitent** is a Slay the Spire 2 custom character built around a spiritual scale between **Faith** and **Burden**.

The character's central fantasy is:

> Faith protects and purifies. Burden empowers and corrupts. The Penitent survives by moving between the two, healing others at personal cost, and deciding when to endure, repent, or fall deeper for power.

The Penitent has three primary archetypes:

1. **Devotion** — Ascend toward Faith, prevent damage, and convert spiritual certainty into defense.
2. **Contrition** — Atone to heal self or allies, while The Penitent takes on the Burden.
3. **Heresy** — Descend toward Burden for stronger attacks and dangerous payoff cards.

The core gameplay question is:

> Which side of the scale am I feeding this turn?

---

## Core Scale System

The Penitent is defined by a two-sided spiritual scale:

```text
Faith ← Neutral → Burden
```

The Penitent should normally have **Faith**, **Burden**, or neither. Faith and Burden should not normally coexist. When one is gained, it consumes the other first.

### Faith

**Faith** is the positive side of the scale.

Rules:

- Faith prevents HP damage 1-for-1 after Block is applied.
- When The Penitent gains Faith, remove that much Burden first.
- Any excess becomes Faith.
- Faith persists between turns.

Example:

```text
The Penitent has 6 Faith.
The Penitent would take 4 unblocked HP damage.
Faith prevents 4 damage and becomes 2.
```

Example with Burden:

```text
The Penitent has 7 Burden.
The Penitent Ascends 5.
Burden is reduced to 2.
No Faith is gained.
```

### Burden

**Burden** is the negative side of the scale.

Rules:

- When The Penitent gains Burden, remove that much Faith first.
- Any excess becomes Burden.
- At combat's end, The Penitent loses HP equal to Burden.
- If Burden would be lethal, The Penitent survives at 1 HP and loses Max HP for each unpaid HP.

Example:

```text
The Penitent has 6 Faith.
The Penitent Descends 4.
Faith is reduced to 2.
No Burden is gained.
```

Example with overflow:

```text
The Penitent has 2 Faith.
The Penitent Descends 5.
Faith is reduced to 0.
The Penitent gains 3 Burden.
```

### Ascend

**Ascend** moves The Penitent toward Faith.

Rules:

```text
Ascend X:
Remove up to X Burden.
If X exceeds current Burden, gain the excess as Faith.
```

Use Ascend when a card represents prayer, repentance, cleansing, discipline, or returning from Burden.

### Descend

**Descend** moves The Penitent toward Burden.

Rules:

```text
Descend X:
Remove up to X Faith.
If X exceeds current Faith, gain the excess as Burden.
```

Use Descend when a card represents doubt, heresy, desperation, corruption, or spiritual collapse.

Important trigger rule:

> Effects that say "Whenever you gain Burden" should trigger only when Burden actually remains after Faith is consumed.

Example:

```text
The Penitent has 5 Faith.
A card says Descend 3.
Faith drops to 2.
No Burden is gained.
"Whenever you gain Burden" does not trigger.
```

```text
The Penitent has 2 Faith.
A card says Descend 5.
Faith drops to 0.
The Penitent gains 3 Burden.
"Whenever you gain Burden" triggers once.
```

---

## Atone

**Atone** is The Penitent's healing action.

Rules:

```text
Atone X:
Heal the target for X HP.
The Penitent gains Burden equal to the HP restored.
```

The target may be The Penitent or another player, depending on card targeting.

The important multiplayer rule:

> The healed ally does not gain Burden. The Penitent takes the Burden.

Atone should generally use **actual HP restored**, not intended healing amount.

---

## Multiplayer Design

The Penitent should be a **martyr-support** character in multiplayer.

The Penitent can heal allies, but The Penitent personally carries the cost.

The multiplayer fantasy is:

> I can save you, but I carry the Burden.

### Allies Should Not Normally Gain Faith or Burden

Faith and Burden are Penitent-owned mechanics by default.

Allies may receive normal game effects such as healing, Block, Strength, or other ordinary support effects. Allies should not normally receive Faith, Burden, or the Faith/Burden scale.

This keeps the character readable in multiplayer and avoids forcing every player to understand The Penitent's resource system.

### Ally Atone Balance

Ally healing can become very strong because it smooths out the whole team's HP pool.

Recommended constraints:

- Modest Atone cards can target any player.
- Larger ally Atone cards should often be ally-only.
- Large ally Atone cards should usually Exhaust.
- Burden payoff cards should not all fully clear Burden.
- Full Burden clearing should stay mostly rare, costly, or Exhausting.

---

## Starter Relic

## Fractured Halo

```text
At the start of each combat, gain 4 Faith.
```

Design intent:

Fractured Halo nudges The Penitent toward Devotion at combat start. It gives a small buffer before Atone or Heresy cards push the character toward Burden.

Starting at 4 Faith is safer than 6 under the scale model because Faith prevents damage, cleanses Burden, and absorbs future Burden gain.

---

## Current Card List

This list reflects the current implemented / planned values.

## Starter Cards

| Card | Type | Rarity | Cost | Effect | Upgrade |
|---|---:|---:|---:|---|---|
| Strike | Attack | Starter | 1 | Deal 6 damage. | Deal 9 damage. |
| Defend | Skill | Starter | 1 | Gain 5 Block. | Gain 8 Block. |
| Prayer | Skill | Starter/Common | 1 | Ascend 4. | Ascend 6. |
| Mend Wounds | Skill | Starter/Common | 1 | Atone 5. | Atone 7. |

## Devotion Cards

| Card | Type | Rarity | Cost | Effect | Upgrade |
|---|---:|---:|---:|---|---|
| Empty Hands | Skill | Common | TBD | If you have no Block, Ascend 10. | If you have no Block, Ascend 12. |
| Steady Conviction | Skill | Common | TBD | Gain 4 Block and 3 Faith. | Gain 6 Block and 4 Faith. |
| Zealous Retort | Power | Uncommon | TBD | Whenever Faith prevents damage, deal 3 damage to the attacker. | Deal 4 damage instead. |
| Crisis of Faith | Skill | Uncommon | TBD | Descend equal to your Faith. Gain twice that much Block. | Gain twice that much Block + 5. |
| Confess | Skill | Uncommon/Common | TBD | Gain 5 Faith. Draw 1 card. | Gain 7 Faith. Draw 1 card. |

Design note: `Crisis of Faith` intentionally uses Descend. In this design, Faith removal is Descending and Burden removal is Ascending. This keeps scale language consistent.

## Contrition Cards

| Card | Type | Rarity | Cost | Effect | Upgrade |
|---|---:|---:|---:|---|---|
| Mend Wounds | Skill | Common | 1 | Atone 5. | Atone 7. |
| Intercession | Skill | Uncommon | 1 | Atone an ally 7. | Atone an ally 9. |
| Gentle Mercy | Skill | Rare | 1 | Heal 6. This healing does not generate Burden. | Heal 9. This healing does not generate Burden. |

Design note: `Intercession` is multiplayer-only and ally-targeted. It gives The Penitent a stronger support tool without making every Atone card ally-only.

## Heresy Cards

| Card | Type | Rarity | Cost | Effect | Upgrade |
|---|---:|---:|---:|---|---|
| Blasphemous Bolt | Attack | Common | 1 | Deal 13 damage. Descend 4. | Deal 16 damage. Descend 5. |
| Dark Whisper | Skill | Common | 0 | Descend 3. Draw 1 card. | TBD |
| Heavy Soul | Attack | Common | 1 | Deal 6 damage. If you have Burden, deal 6 additional damage. | Deal 8 damage. If you have Burden, deal 8 additional damage. |
| Black Benediction | Attack | Uncommon | 2 | Deal 24 damage. Descend 8. | Deal 32 damage. Descend 8. |
| Fall From Grace | Attack | Uncommon | 1 | Descend twice your Faith. Deal damage equal to twice the Burden gained. | Deal damage equal to twice the Burden gained + 5. |
| Grim Uncertainty | Power | Uncommon | TBD | Whenever you gain Burden, deal 2 damage to a random enemy. | Deal 3 damage instead. |
| Ruinous Confession | Attack | Rare | 3 | Ascend equal to your Burden. Deal damage equal to twice the Ascended amount to all enemies. | Currently upgraded by cost or other tuning; final upgrade text TBD. |
| Final Penance | Attack | Rare | 3 | Lose HP equal to half your Burden, rounded down. Deal damage to all enemies equal to three times the HP lost. Ascend equal to your Burden. Exhaust. | Damage becomes four times the HP lost. |

Design notes:

- `Grim Uncertainty` should trigger only when Burden is actually gained after Faith is consumed.
- `Ruinous Confession` is a Burden cashout. It Ascends first, then deals AoE damage based on the Ascended amount.
- `Final Penance` is the dangerous version of a Burden cashout. It costs HP and Exhausts.

---

## Archetype Notes

## Devotion

Devotion wants to stay Faith-positive.

Typical goals:

- Prevent damage with Faith.
- Use Ascend to cleanse Burden.
- Use Faith as a buffer before Atone or Heresy effects.
- Convert Faith into Block through Crisis of Faith.
- Punish attackers with Zealous Retort.

Risk: if Faith values are too high, Devotion becomes too safe and Burden stops mattering.

## Contrition

Contrition uses Atone to survive and support allies.

Typical goals:

- Heal self or allies.
- Let Faith absorb the Burden from Atone.
- Use Atone when healing is worth moving toward Burden.
- Use Gentle Mercy sparingly as true healing.

Risk: if Atone is too efficient, The Penitent breaks the attrition model. If ally Atone is too efficient, The Penitent becomes the best multiplayer healer by default.

## Heresy

Heresy intentionally Descends.

Typical goals:

- Use Descend cards for above-rate attacks or draw.
- Let small Burden costs consume Faith when safe.
- Push past Faith into actual Burden for payoffs.
- Use Burden-positive cards like Heavy Soul, Grim Uncertainty, Ruinous Confession, and Final Penance.

Risk: if Burden payoffs are too efficient, Burden becomes pure upside and the scale stops being tense.

---

## Balance Watchlist

## Faith May Be Too Universal

Faith prevents damage, removes Burden, and absorbs future Burden. This is powerful.

Countermeasures:

- Keep Faith values modest.
- Avoid too many free or low-cost Ascend effects.
- Be careful with starting relic Faith value.

## Burden May Become Too Easy To Clear

Because Ascend removes Burden, every Ascend card doubles as Burden management.

Countermeasures:

- Keep common Ascend values modest.
- Make full Burden cashouts rare, expensive, or Exhausting.
- Ensure Heresy cards can push past Faith meaningfully.

## Atone Can Break Attrition

Healing persists across combats, so Atone must carry a meaningful cost.

Countermeasures:

- Atone creates Burden equal to actual HP restored.
- Larger ally Atone cards should be limited or Exhausting.
- True healing without Burden should remain rare.

## Multiplayer Healing Can Become Too Strong

The Penitent can potentially preserve the team's entire HP pool.

Countermeasures:

- Keep ally Atone numbers conservative.
- Exhaust large ally heals.
- Avoid too many full Burden-clearing effects.
- Avoid making ally Atone into a reliable setup for huge damage every fight.

## Heresy Can Become Pure Upside

If every Burden card gives too much value, the player always wants to Descend.

Countermeasures:

- Make some Heresy cards leave Burden behind.
- Make some payoff cards consume Burden.
- Make the largest payoffs cost HP, Exhaust, or require setup.
- Watch combinations like Atone ally → gain Burden → Ruinous Confession / Final Penance.

---

## Implementation Notes

## Centralize Scale Logic

Cards should not manually implement Faith/Burden cancellation.

Use a dedicated helper such as:

```csharp
PenitentPowerCmd.ApplyFaith(...)
PenitentPowerCmd.ApplyBurden(...)
```

Expected structure:

```text
Cards
  call ThePenitentMechanicCard helpers

ThePenitentMechanicCard
  calls Ascend / Descend / Atone helpers

PenitentPowerCmd
  owns Faith/Burden scale cancellation

FaithPower
  owns damage prevention

BurdenPower
  owns end-of-combat punishment
```

## Avoid Raw Power Application

Most cards should not call:

```csharp
PowerCmd.Apply<FaithPower>(...)
PowerCmd.Apply<BurdenPower>(...)
```

They should call Penitent-specific helpers:

```csharp
Ascend(...)
Descend(...)
AtoneTarget(...)
```

Only use raw application for effects that intentionally bypass the scale.

## Atone Implementation

Atone should:

1. Read target HP before healing.
2. Heal the target.
3. Read target HP after healing.
4. Calculate actual HP restored.
5. Descend The Penitent by that amount.

This ensures overhealing does not create excess Burden.

## Trigger Semantics

There are two important event types:

### Descend

Triggered whenever a card or effect moves The Penitent toward Burden.

This can remove Faith without creating Burden.

### Gain Burden

Triggered only when Burden actually remains after Faith is consumed.

Example:

```text
The Penitent has 5 Faith.
A card says Descend 3.
Faith drops to 2.
No Burden is gained.
Grim Uncertainty does not trigger.
```

```text
The Penitent has 2 Faith.
A card says Descend 5.
Faith drops to 0.
The Penitent gains 3 Burden.
Grim Uncertainty triggers.
```

This distinction is critical for balance.

---

## Open Questions

These should be answered through playtesting.

1. Are current Faith values still modest enough now that Faith does not decay?
2. Is Fractured Halo at 4 Faith too low, too high, or correct?
- I went with 6, but we can still test this out
3. Are common Ascend values too strong because they also cleanse Burden?
4. Should `Ruinous Confession` upgrade by cost reduction, removing Exhaust, or increasing multiplier?
5. Is `Fall From Grace` text readable enough with "Descend twice your Faith"?
6. Does `Crisis of Faith` feel good at its current cost?
7. Are ally Atone cards too strong in multiplayer?
8. Should any enemies ever receive Burden, or should Burden remain Penitent-only?
9. Should Heresy become a formal internal tag later?
10. Does Grim Uncertainty need a clearer name if the mechanic is deterministic once Burden is actually gained?

---

## Current Best Version

The Penitent is strongest when treated as a character divided between Faith and Burden.

Faith protects.  
Burden empowers.  
Atone saves others at personal cost.  
Heresy turns spiritual debt into violence.

The Penitent should constantly ask:

> Do I endure, repent, or fall deeper for power?
