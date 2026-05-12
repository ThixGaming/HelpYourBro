using BaseLib.Abstracts;
using BaseLib.Extensions;
using HelpYourBro.HelpYourBroCode.Extensions;
using Godot;

namespace HelpYourBro.HelpYourBroCode.Relics;

public abstract class HelpYourBroRelic : CustomRelicModel
{
    //HelpYourBro/images/relics
    public override string PackedIconPath
    {
        get { return $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".RelicImagePath(); }
    }

    protected override string PackedIconOutlinePath
    {
        get { return $"{Id.Entry.RemovePrefix().ToLowerInvariant()}_outline.png".RelicImagePath(); }
    }

    protected override string BigIconPath
    {
        get { return $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigRelicImagePath(); }
    }
}