using BaseLib.Utils;
using HelpYourBro.HelpYourBroCode.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.CardPools;
using MegaCrit.Sts2.Core.ValueProps;

namespace HelpYourBro.HelpYourBroCode.Cards;

[Pool(typeof(ColorlessCardPool))]
public class IGotchu() : HelpYourBroCard(1,
    CardType.Skill, CardRarity.Basic,
    TargetType.AnyAlly)
{
    public override string PortraitPath
    {
        get { return $"HelpYourBro/images/card_portraits/igotchu.png"; }
    }

    protected override IEnumerable<DynamicVar> CanonicalVars
    {
        get { return [new BlockVar(10m, ValueProp.Move)]; }
    }

    public override bool GainsBlock
    {
        get { return true; }
    }

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await CreatureCmd.GainBlock(Owner.Creature, DynamicVars.Block, play); 
    }

    protected override void OnUpgrade()
    {

    }
}