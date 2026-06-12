using BaseLib.Abstracts;
using ThePenitent.ThePenitentCode.Extensions;
using Godot;

namespace ThePenitent.ThePenitentCode.Character;

public class ThePenitentPotionPool : CustomPotionPoolModel
{
    public override Color LabOutlineColor => ThePenitent.Color;


    public override string BigEnergyIconPath => "charui/big_energy.png".ImagePath();
    public override string TextEnergyIconPath => "charui/text_energy.png".ImagePath();
}