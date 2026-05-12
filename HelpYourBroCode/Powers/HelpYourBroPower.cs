using BaseLib.Abstracts;
using BaseLib.Extensions;
using HelpYourBro.HelpYourBroCode.Extensions;
using Godot;

namespace HelpYourBro.HelpYourBroCode.Powers;

public abstract class HelpYourBroPower : CustomPowerModel
{
    //Loads from HelpYourBro/images/powers/your_power.png
    public override string CustomPackedIconPath
    {
        get { return $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".PowerImagePath(); }
    }

    public override string CustomBigIconPath
    {
        get { return $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigPowerImagePath(); }
    }
}