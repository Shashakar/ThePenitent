# Hurt Animation Transition Design

## Goal

When the Penitent takes a hit, transition immediately from the looping `idle` animation into the non-looping `hurt` animation, then return smoothly to `idle` when `hurt` finishes.

## Existing Integration

BaseLib maps the game's `Hit` animation trigger to the Godot animation name `hurt`. The current visual scene already contains looping `idle` and non-looping, 0.3-second `hurt` animations.

## Design

Add an `AnimationTree` using an `AnimationNodeStateMachine` to `PenitentVisual.tscn`.

- Start in `idle`.
- Travel immediately to `hurt` when BaseLib requests the `hurt` animation.
- Automatically advance from `hurt` to `idle` when the hurt animation ends.
- Use no crossfade into `hurt`, preserving a responsive impact.
- Use a 0.07-second crossfade from `hurt` back to `idle`.
- A new hurt trigger while `hurt` is playing restarts the hurt state.

The existing `AnimationPlayer` remains the source of animation clips. No Penitent-specific C# animation script is needed.

## Future States

The same state machine can later add `attack`, `cast`, and `die`. Death must not automatically return to idle; other one-shot actions may follow the same automatic return pattern as hurt.

## Verification

- Confirm MegaDot can import the scene without animation-tree errors.
- Confirm BaseLib can discover the `AnimationTree` and find both `idle` and `hurt` animations.
- Publish the mod and test that taking damage plays the full hurt animation once and returns to looping idle.
- Test two hits in quick succession to confirm the second hit restarts hurt cleanly.
