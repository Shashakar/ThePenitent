# Penitent Remaining Visual Scenes Design

## Goal

Finish the visual-only migration for remaining character-adjacent scenes without adding merchant, campsite, or random-selection gameplay behavior.

## Decisions

- Rest-site/campsite visuals use BaseLib's `CustomRestSiteAnimPath` character hook.
- The rest-site scene reuses the existing Penitent visual assets, scaled and positioned for the campsite.
- Merchant/shop behavior remains unchanged. Merchant visuals use a narrow Harmony patch on `CharacterModel.MerchantAnimPath` because the vanilla property exists but is not virtual.
- Random character eligibility is made explicit with `AllowInVanillaRandomCharacterSelect`.
- Ancient dialogue/audio placeholders are outside this visual-only slice.

## Testing

Add focused tests for the character model asset contract and the rest-site scene file.
