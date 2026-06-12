using BaseLib.Abstracts;
using BaseLib.Utils;
using ThePenitent.ThePenitentCode.Character;

namespace ThePenitent.ThePenitentCode.Potions;

[Pool(typeof(ThePenitentPotionPool))]
public abstract class ThePenitentPotion : CustomPotionModel;