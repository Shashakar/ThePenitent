# Penitent Remaining Visual Scenes Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Add visual-only Penitent coverage for remaining character-adjacent scenes.

**Architecture:** Use BaseLib's character model hooks for rest-site visuals and random select eligibility. Use a narrow Harmony getter patch for merchant visuals because `CharacterModel.MerchantAnimPath` is not virtual. Add small Godot scenes that reuse the existing Penitent visual rather than creating new behavior.

**Tech Stack:** C#, Godot scene files, BaseLib character model hooks, xUnit.

---

### Task 1: Character Visual Contract

**Files:**
- Create: `ThePenitent.Tests/Character/PenitentVisualSceneTests.cs`
- Modify: `ThePenitentCode/Character/ThePenitent.cs`
- Create: `ThePenitent/images/charui/penitent_rest_site.tscn`
- Create: `ThePenitent/images/charui/penitent_merchant.tscn`
- Create: `ThePenitentCode/Patches/PenitentMerchantVisualPath.cs`
- Create: `ThePenitentCode/Patches/PenitentMerchantVisualPatches.cs`

- [ ] **Step 1: Write failing tests**

Add tests that assert `CustomRestSiteAnimPath`, `AllowInVanillaRandomCharacterSelect`, and the rest-site scene contents.

- [ ] **Step 2: Run tests and verify failure**

Run: `dotnet test ThePenitent.Tests/ThePenitent.Tests.csproj --no-restore --filter PenitentVisualSceneTests`

- [ ] **Step 3: Add the rest-site scene**

Create `penitent_rest_site.tscn` that instances `PenitentVisual.tscn`.

- [ ] **Step 4: Wire the character model**

Override `CustomRestSiteAnimPath` and `AllowInVanillaRandomCharacterSelect` in `ThePenitent.cs`.

- [ ] **Step 5: Verify**

Run: `dotnet test ThePenitent.Tests/ThePenitent.Tests.csproj --no-restore`
Run: `dotnet build ThePenitent.csproj --no-restore`
