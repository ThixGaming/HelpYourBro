using BaseLib.Utils;
using HelpYourBro.HelpYourBroCode.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.CardPools;
using MegaCrit.Sts2.Core.Models.Powers;

namespace HelpYourBro.HelpYourBroCode.Cards;
[Pool(typeof(ColorlessCardPool))]
public class KaChow() : HelpYourBroCard(2, CardType.Skill, CardRarity.Ancient, TargetType.AnyAlly)
{
    public override string PortraitPath
    {
        get { return "res://HelpYourBro/images/card_portraits/kachow.png"; }
    }

    public override string CustomPortraitPath
    {
        get { return "res://HelpYourBro/images/card_portraits/big/kachow.png"; }
    }


    public override IEnumerable<CardKeyword> CanonicalKeywords
    {
        get { return [CardKeyword.Exhaust]; }
    }

    protected override IEnumerable<DynamicVar> CanonicalVars
    {
        get { return [new PowerVar<DexterityPower>(3m)]; }
    }

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay cardPlay)
    {
        ArgumentNullException.ThrowIfNull(cardPlay.Target, "cardPlay.Target");

        await PowerCmd.Apply<DexterityPower>(
            choiceContext, 
            cardPlay.Target,
            DynamicVars["DexterityPower"].BaseValue,
            Owner.Creature, 
            this);
        

    }

    protected override void OnUpgrade()
    {
        DynamicVars["DexterityPower"].UpgradeValueBy(2m);
    }
}