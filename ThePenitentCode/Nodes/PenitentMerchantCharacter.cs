using Godot;
using MegaCrit.Sts2.Core.Nodes.Screens.Shops;

namespace ThePenitent.ThePenitentCode.Nodes;

public partial class PenitentMerchantCharacter : NMerchantCharacter
{
    public override void _Ready()
    {
        // Penitent's merchant scene is a static visual-only scene, not a Spine merchant animation.
    }
}
