using System;

using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.FormFlow.Advanced;

namespace BeerBot
{
    public enum InitialOptions {Drink,Pub,Surprise}

    public enum LocationCheck {drinkHere,goForAWalk}
   
    public enum BeerOptions { BlackSheep, Theakstons, Wheat};


    [Serializable]
    public class BeerBotForm
    {
        //  [Prompt("What kind of {&} would you like? {||}")]
        // public BeerStyleOptions BeerStyle;
        public string BeerStyle;
        public string BeerName;

        [Prompt("Select out of the list below:")]
                public int UserVenueID = 0;

        [Prompt("What is the name of the pub?")]
        public string UserVenueName;

        [Prompt("Which city are you in?")]
        public string UserVenueCity;


        public static IForm<BeerBotForm> BuildForm()
        {
            BeerAgent beerAgent = BeerAgent.Instance;
            LocationAgent locationAgent = LocationAgent.Instance;

            return new FormBuilder<BeerBotForm>()
                   
.Field(nameof(UserVenueCity))
                     .Field(nameof(UserVenueName))
          /* .Field(new FieldReflector<BeerBotForm>(nameof(UserVenueID))
                    .SetType(null)
                    .SetDefine(async (state, field) =>
                    {
                       if (state.UserVenueName != null && state.UserVenueCity != null) {
                            foreach (var venue in await locationAgent.GetVenue(state.UserVenueName, state.UserVenueCity)) 
                             field
                                     .AddDescription(venue.venue_name, venue.venue_name)
                                       .AddTerms(venue.venue_name, venue.venue_name);


                        }

                        return true;
                    }
                    )
                    )
                 */
                    .Message("What style of Beer do you fancy?")
                    .Field(new FieldReflector<BeerBotForm>(nameof(BeerStyle))
                    .SetType(null)
                    .SetDefine(async (state, field) =>
                     {
                         if (state.UserVenueName != null && state.UserVenueCity != null)
                         {


                             state.UserVenueID = (await locationAgent.GetVenue(state.UserVenueName, state.UserVenueCity)).venue_id;

                             if (state.UserVenueID != 0)
                             {
                                
                                 foreach (var style in await beerAgent.GetLocalsBeerTypes(state.UserVenueID))
                                     field
                                         .AddDescription(style, style)
                                             .AddTerms(style, style);
                             }
                         }
                         return true;
                     }))
                    .Message("Great, which one?")
                    .Field(new FieldReflector<BeerBotForm>(nameof(BeerName))
                    .SetType(null)
                    .SetDefine(async (state, field) =>
                    {
                        if (state.BeerStyle != null) { 
                        foreach (var beer in await beerAgent.GetBeersByType(state.BeerStyle, state.UserVenueID))
                            field
                                .AddDescription(beer, beer)
                                .AddTerms(beer, beer);
                    }
                        return true;
                    }))
                    .Message("It's on it's way!") 
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