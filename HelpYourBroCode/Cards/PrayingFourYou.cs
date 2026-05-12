using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using HelpYourBro.HelpYourBroCode.Cards;
using HelpYourBro.HelpYourBroCode.Extensions;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Models.CardPools;

namespace HelpYourBro.HelpYourBroCode.Cards;

[Pool(typeof(ColorlessCardPool))]
public class PrayingFourYou() : HelpYourBroCard(2, CardType.Skill, CardRarity.Rare, TargetType.AnyAlly)
{
    public override string PortraitPath
    {
	    get { return "res://HelpYourBro/images/card_portraits/prayingfouryou.png"; }
    }

    public override string CustomPortraitPath
    {
	    get { return "res://HelpYourBro/images/card_portraits/big/prayingfouryou.png"; }
    }

    protected override IEnumerable<DynamicVar> CanonicalVars
    {
	    get { return [new PowerVar<RegenPower>(4m)]; }
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        ArgumentNullException.ThrowIfNull(cardPlay.Target, "cardPlay.Target");  

        await PowerCmd.Apply<RegenPower>(
            choiceContext,
            cardPlay.Target,      // ally target
            DynamicVars["RegenPower"].BaseValue, //BaseValue field of RegenPower (prolly defined as DynamicVars RegenPower = new DynamicVars;), returns a decimal
            Owner.Creature,       // applier/source creature
            this                  // source card
        );
    }
    // so... for reference, this is the Task with Apply
    /*
    public static async Task<IReadOnlyList<T>> Apply<T>(PlayerChoiceContext choiceContext, IEnumerable<Creature> targets, decimal amount, Creature? applier, CardModel? cardSource, bool silent = false) where T : PowerModel
	{
		List<T> powers = new List<T>();
		foreach (Creature target in targets)
		{
			T val = await Apply<T>(choiceContext, target, amount, applier, cardSource, silent);
			if (val != null)
			{
				powers.Add(val);
			}
		}
		return powers;
	}
     */
    protected override void OnUpgrade()
    {
        DynamicVars["RegenPower"].UpgradeValueBy(2m);
    }
}