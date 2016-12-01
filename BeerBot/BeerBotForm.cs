using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.FormFlow.Advanced;
using System.Threading.Tasks;

namespace BeerBot
{
    public enum InitialOptions {Drink,Pub,Surprise}

    public enum LocationCheck {drinkHere,goForAWalk}
    public enum BeerStyleOptions { theUsual, Lager, IPA, Wheat, Porter, SurpriseMe };

    public enum BeerOptions { BlackSheep, Theakstons, Wheat};


    [Serializable]
    public class BeerBotForm
    {
        //  [Prompt("What kind of {&} would you like? {||}")]
        // public BeerStyleOptions BeerStyle;
        public string BeerStyle;
        public string BeerName;

        public static IForm<BeerBotForm> BuildForm()
        {

            BeerAgent beerAgent = new BeerAgent();

            return new FormBuilder<BeerBotForm>()
                    .Message("It looks like you are in <Location>, would you like a drink here or do you fancy a walk?")
                    .Message("What style of Beer do you fancy?")
                    .Field(new FieldReflector<BeerBotForm>(nameof(BeerStyle))
                    .SetType(null)
                    .SetDefine(async (state, field) =>
                     {
                         foreach (var prod in await MessagesController.GetLocalsBeerTypes(52.2, 0.12))
                             field
                                 .AddDescription(prod, prod)
                                 .AddTerms(prod, prod);

                         return true;
                     }))
                    .Message("Great, which one?")
                    .Field(new FieldReflector<BeerBotForm>(nameof(BeerName))
                    .SetType(null)
                    .SetDefine(async (state, field) =>
                    {
                        foreach (var prod in await MessagesController.GetBeersByType())
                            field
                                .AddDescription(prod, prod)
                                .AddTerms(prod, prod);

                        return true;
                    }))
                     .Build();

/* Hello User how can I help
 * 1. Recommend a great drink
 * 2. Recommend a good pub
 * 3. Surprise me!
 * 
 */ 
        }
    }
}