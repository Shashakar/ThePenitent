# Faith Burden Scale Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Introduce a Penitent-owned Faith/Burden scale API that separates scale rules from ordinary power usage while preserving current gameplay behavior during the migration.

**Architecture:** Add a pure `PenitentScale` value object for signed Faith/Burden math, cover it with tests, then route gameplay reads through `PenitentScaleTracker`. For this first slice the tracker bridges to existing visible powers so cards/relics keep working; a later UI slice can replace that storage with a custom meter.

**Tech Stack:** C#/.NET 9, Godot.NET, xUnit test project, existing StS2 power APIs.

---

### Task 1: Test Project and Pure Scale Model

**Files:**
- Create: `ThePenitent.Tests/ThePenitent.Tests.csproj`
- Create: `ThePenitent.Tests/Scale/PenitentScaleTests.cs`
- Create: `ThePenitentCode/Scale/PenitentScale.cs`
- Modify: `ThePenitent.sln`

- [ ] **Step 1: Write failing tests** for neutral state, Ascend clearing Burden before Faith, Descend clearing Faith before Burden, and signed-value construction.
- [ ] **Step 2: Run `dotnet test ThePenitent.Tests/ThePenitent.Tests.csproj --no-restore`** and verify it fails because `PenitentScale` does not exist.
- [ ] **Step 3: Implement `PenitentScale`** as an immutable readonly struct with `Value`, `Faith`, `Burden`, `HasFaith`, `HasBurden`, `Ascend(decimal)`, `Descend(decimal)`, `FromFaith(decimal)`, and `FromBurden(decimal)`.
- [ ] **Step 4: Run tests** and verify the pure scale tests pass.

### Task 2: Tracker Bridge Over Current Powers

**Files:**
- Create: `ThePenitentCode/Scale/PenitentScaleTracker.cs`
- Test: `ThePenitent.Tests/Scale/PenitentScaleTrackerTests.cs`

- [ ] **Step 1: Write failing tests** for tracker amount decisions where current Faith/Burden powers are supplied as numeric inputs.
- [ ] **Step 2: Implement tracker helpers** for `FromAmounts(decimal faith, decimal burden)` and read helpers used by cards.
- [ ] **Step 3: Run tests** and verify tracker tests pass.

### Task 3: Route Code Through Scale Helpers

**Files:**
- Modify: `ThePenitentCode/Commands/PenitentPowerCmd.cs`
- Modify: `ThePenitentCode/Cards/ThePenitentMechanicCard.cs`
- Modify card/relic files that directly query `FaithPower` or `BurdenPower`

- [ ] **Step 1: Replace direct card/relic checks** with helper methods such as `HasFaith`, `HasBurden`, `FaithAmount`, and `BurdenAmount`.
- [ ] **Step 2: Keep `PowerCmd.Apply<FaithPower>` and `PowerCmd.Apply<BurdenPower>` inside `PenitentPowerCmd` only for this bridge slice.**
- [ ] **Step 3: Run `dotnet test` and `dotnet build ThePenitent.csproj`.**

### Task 4: Verify Scope Boundary

**Files:**
- Modify: `Plan.md` if needed

- [ ] **Step 1: Search for direct Faith/Burden power reads outside the bridge.**
- [ ] **Step 2: Document remaining intentional power usage as bridge-only.**
- [ ] **Step 3: Run final build and tests.**
