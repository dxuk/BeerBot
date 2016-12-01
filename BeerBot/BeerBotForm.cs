using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Bot.Builder.FormFlow;


namespace BeerBot
{
    public enum BeerStyleOptions { Lager, IPA, Wheat };

    public enum BeerOptions { BlackSheep, Theakstons, Wheat};

    public class BeerBotForm
    {
        [Prompt("What kind of {&} would you like? {||}")]
        public BeerStyleOptions? BeerStyle;


        public static IForm<BeerBotForm> BuildForm()
        {
            return new FormBuilder<BeerBotForm>()
                    .Message("What do you fancy?!")
                    .Build();
        }
    }
}