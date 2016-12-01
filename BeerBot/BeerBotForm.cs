using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Bot.Builder.FormFlow;


namespace BeerBot
{
    public enum InitialOptions {Drink,Pub,Surprise}

    public enum LocationCheck {drinkHere,goForAWalk}
    public enum BeerStyleOptions { theUsual, Lager, IPA, Wheat, Porter, SurpriseMe };

    public enum BeerOptions { BlackSheep, Theakstons, Wheat};

    public class BeerBotForm
    {
        [Prompt("What kind of {&} would you like? {||}")]
        public BeerStyleOptions? BeerStyle;


        public static IForm<BeerBotForm> BuildForm()
        {
            return new FormBuilder<BeerBotForm>()
                    .Message("It looks like you are in <Location>, would you like a drink here or do you fancy a walk?")
                    .Message("What style of Beer do you fancy?")
                    .Message()
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