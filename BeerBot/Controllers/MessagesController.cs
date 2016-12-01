using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Connector;

using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace BeerBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        /// 

        internal static IDialog<BeerBotForm> MakeRootDialog()
        {
            return Chain.From(() => FormDialog.FromForm(BeerBotForm.BuildForm));
        }
        //hmm
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                // calculate something for us to return
                int length = (activity.Text ?? string.Empty).Length;

                // return our reply to the user
                //Activity reply = activity.CreateReply($"You sent {activity.Text} which was {length} characters");

                //  Activity reply = activity.CreateReply($"BeerBot");

                //   await connector.Conversations.ReplyToActivityAsync(reply);
                // Activity reply = activity.CreateReply($"Hi From BeerBot!");
                /*
             if (activity.Entities != null )
                {

                    await connector.Conversations.ReplyToActivityAsync(activity.CreateReply($"Entity is not null, there are {activity.Entities.Count}"));
                    string entityValues = "";
                    foreach (Entity entity in activity.Entities)
                    {
                        await connector.Conversations.ReplyToActivityAsync(activity.CreateReply($"Entity type is {entity.Type.ToString()}"));

                        if (entity.Type == "Place")
                        {
                            await connector.Conversations.ReplyToActivityAsync(activity.CreateReply($"Entity is Place"));

                            try
                            {
                                dynamic place = entity.Properties;
                                entityValues = place.geo.latitude + " " + place.geo.longitude;
                            }
                            catch { }
                        }
                   

                    }
               
                 }
                else
                {
                     
                    await connector.Conversations.ReplyToActivityAsync(activity.CreateReply($"Did not get location"));

                }
                await connector.Conversations.ReplyToActivityAsync(activity.CreateReply($"Location logic finished"));
             */   
                await Conversation.SendAsync(activity, MakeRootDialog);
            }
            else
            {
                HandleSystemMessage(activity);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}