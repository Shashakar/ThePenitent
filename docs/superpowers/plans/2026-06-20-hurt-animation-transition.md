# Hurt Animation Transition Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Play `hurt` when BaseLib emits the hit trigger and automatically crossfade back to looping `idle`.

**Architecture:** Keep `AnimationPlayer` as the clip source and add an active `AnimationTree` state machine to the same visual scene. BaseLib discovers the tree recursively, travels to `hurt`, and the state machine automatically advances back to `idle`.

**Tech Stack:** Godot/MegaDot 4.5.1 scene resources, BaseLib 3.2 custom animation dispatch

---

### Task 1: Add and verify the state machine

**Files:**
- Modify: `ThePenitent/images/charui/PenitentVisual.tscn`

- [x] **Step 1: Run a structural assertion that fails while no AnimationTree exists**

Run a PowerShell assertion requiring `AnimationNodeStateMachine`, `AnimationTree`, `idle`, `hurt`, and a 0.07-second return crossfade. Expected: FAIL because the tree is absent.

- [x] **Step 2: Add the minimal state-machine resources**

Add animation nodes for `idle` and `hurt`, an immediate transition into hurt, an auto-advance transition back to idle with `xfade_time = 0.07`, and an active `AnimationTree` linked to `AnimationPlayer`.

- [x] **Step 3: Re-run the structural assertion**

Expected: PASS for all required nodes and transition properties.

- [x] **Step 4: Parse and exercise the scene in MegaDot**

Load the scene headlessly, travel to `hurt`, wait beyond 0.3 seconds, and assert that playback returns to `idle`.

- [x] **Step 5: Publish the mod**

Run `dotnet publish ThePenitent.csproj -c Release --no-restore`. Expected: exit code 0 and a refreshed installed `ThePenitent.pck`.
