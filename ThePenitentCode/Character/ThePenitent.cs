using BaseLib.Abstracts;
using BaseLib.Utils.NodeFactories;
using ThePenitent.ThePenitentCode.Extensions;
using Godot;
using MegaCrit.Sts2.Core.Entities.Characters;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Relics;
using ThePenitent.ThePenitentCode.Cards;
using ThePenitent.ThePenitentCode.Relics;

namespace ThePenitent.ThePenitentCode.Character;

public class ThePenitent : PlaceholderCharacterModel
{
    public const string CharacterId = "ThePenitent";

    public static readonly Color Color = new("D8C89A");

    public override Color NameColor => Color;
    public override Color MapDrawingColor => Color;
    public override Color EnergyLabelOutlineColor => Color;
    
    public override CharacterGender Gender => CharacterGender.Masculine;
    public override int StartingHp => 65;

    public override IEnumerable<CardModel> StartingDeck =>
    [
        ModelDb.Card<ThePenitentStrikeCard>(),
        ModelDb.Card<ThePenitentStrikeCard>(),
        ModelDb.Card<ThePenitentStrikeCard>(),
        ModelDb.Card<ThePenitentStrikeCard>(),
        ModelDb.Card<ThePenitentDefendCard>(),
        ModelDb.Card<ThePenitentDefendCard>(),
        ModelDb.Card<ThePenitentDefendCard>(),
        ModelDb.Card<ThePenitentDefendCard>(),
        ModelDb.Card<MendWoundsCard>(),
        ModelDb.Card<PrayerCard>(),
        ModelDb.Card<BlasphemousBoltCard>(),
    ];

    public override IReadOnlyList<RelicModel> StartingRelics =>
    [
        ModelDb.Relic<FracturedHaloRelic>()
    ];

    public override CardPoolModel CardPool => ModelDb.CardPool<ThePenitentCardPool>();
    public override RelicPoolModel RelicPool => ModelDb.RelicPool<ThePenitentRelicPool>();
    public override PotionPoolModel PotionPool => ModelDb.PotionPool<ThePenitentPotionPool>();

    /*  PlaceholderCharacterModel will utilize placeholder basegame assets for most of your character assets until you
        override all the other methods that define those assets.
        These are just some of the simplest assets, given some placeholders to differentiate your character with.
        You don't have to, but you're suggested to rename these images. */
    public override Control CustomIcon
    {
        get
        {
            var icon = NodeFactory<Control>.CreateFromResource(CustomIconTexturePath);
            icon.SetAnchorsAndOffsetsPreset(Control.LayoutPreset.FullRect);
            return icon;
        }
    }

    public override string CustomIconTexturePath => "character_icon_char_name.png".CharacterUiPath();
    public override string CustomCharacterSelectIconPath => "ThePenitentCharSelect.png".CharacterUiPath();
    public override string CustomCharacterSelectLockedIconPath => "ThePenitentCharSelected.png".CharacterUiPath();
    public override string CustomMapMarkerPath => "map_marker_char_name.png".CharacterUiPath();
    public override string CustomCharacterSelectBg =>  "charselect_bg_penitent.tscn".CharacterUiPath();
    public override string CustomVisualPath => "penitent.tscn".CharacterUiPath();
    public override string CustomEnergyCounterPath => "penitent_energy_counter.tscn".CharacterUiPath();
}