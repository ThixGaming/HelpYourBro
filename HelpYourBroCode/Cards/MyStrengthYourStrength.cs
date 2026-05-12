using BaseLib.Utils;
using HelpYourBro.HelpYourBroCode.Cards;
using HelpYourBro.HelpYourBroCode.Extensions;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.CardPools;
using MegaCrit.Sts2.Core.Models.Powers;

namespace HelpYourBro.HelpYourBroCode.Cards;

// my comments are literal guesses btw... XD

[Pool(typeof(ColorlessCardPool))]
public class MyStrengthYourStrength() : HelpYourBroCard(3, CardType.Skill, CardRarity.Uncommon, TargetType.AnyAlly)
{
    public override string PortraitPath
    {
        get { return "res://HelpYourBro/images/card_portraits/mystrengthyourstrength.png"; }
    }

    public override string CustomPortraitPath
    {
        get { return "res://HelpYourBro/images/card_portraits/big/mystrengthyourstrength.png"; }
    }
    // These 2 are lambda functions (method{get{return lalala;}})

    /*
     * Apparently, expression-bodied properties.
    */
    public override IEnumerable<CardKeyword> CanonicalKeywords
    {
        get { return [CardKeyword.Exhaust]; }
    }

    // for card keywords, do public override IENumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Keyword];
    protected override IEnumerable<DynamicVar> CanonicalVars
    {
        get { return [new PowerVar<StrengthPower>(2m)]; }
    }
    // This line is calling for a new object. It's creating a new powervar object. The variable that it'll depend on will be inside the <> of the PowerVar.
    // In this case, for a "dynamic variable" used inside methods, i want to call:
    //  protected override IEnumerable<DynamicVar> CanonicalVars => [new VariableHere<DynamicVariableName>(value)];
    
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        //On play: protected override async (1) Task OnPlay(PlayerChoiceContext (2) choiceContext, CardPlay (3) cardPlay){}
        // (1) async asks for await; (2) PlayerChoiceContext seems to be a Type; (3) CardPlay should be an object class.
        ArgumentNullException.ThrowIfNull(cardPlay.Target, "cardPlay.Target");
        // Throw Exception if returns null (i assume), cardPlay.Target means that cardPlay has a Target method.
        
        /*
         * What it all means:
         *  await: since it's running this code block asynchronously, we need to say "await"
         *  CanonicalVar.Apply<DynVar>: It's grabbing the Apply method from the desired CanonicalVar, and applying the dynamic variable DynVar.
         *  cardPlay.Target:
         *  Owner.Creature: the owner is the creature...?
         *  this: says that this is the source card.
         
         overall i think the syntax is CanonicalVarOfChoice.Apply<DynamicVarName>(choiceContext, target, BaseValue, Owner, source cards
        */
        await PowerCmd.Apply<StrengthPower>(
            choiceContext,
            cardPlay.Target,                          // ally target
            DynamicVars["StrengthPower"].BaseValue,   // Base Value
            Owner.Creature,                     // applier/source creature
            this                            // source card
        );
        
        await PowerCmd.Apply<StrengthPower>(
            choiceContext,
            Owner.Creature,                    // self target
            -2m,                              // Base Value
            Owner.Creature,                    // applier/source creature
            this                           // source card
        );
    }

    
    // MyStrengthYourStrength.OnUpgrade method
    protected override void OnUpgrade()
    {
        RemoveKeyword(CardKeyword.Exhaust);
        DynamicVars["StrengthPower"].UpgradeValueBy(1m);
        
    }
}