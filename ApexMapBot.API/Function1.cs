using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ApexMapBot.API.Models;
using RestSharp;
using DSharpPlus;
using DSharpPlus.Entities;

namespace ApexMapBot.API
{
    public static class Function1
    {
        [FunctionName("ApexMapBot")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            ulong channelId = 12345; //Provide channel id
            var token = "";
            var apiToken = "";

            var client = new RestClient("https://api.mozambiquehe.re");
            var request = new RestRequest("maprotation.php", Method.Get);
            request.AddParameter("auth", apiToken);
            var response = await client.ExecuteAsync(request);
            try
            {
                var responseObj = JsonConvert.DeserializeObject<MapRotationModel>(response.Content);

                var discordClient = new DiscordClient(new DiscordConfiguration
                {
                    Token = token,
                    TokenType = TokenType.Bot
                });

                DiscordChannel discordChannel = await discordClient.GetChannelAsync(channelId);
                var footer = new DiscordEmbedBuilder.EmbedFooter
                {
                    Text = "Next Map: " + responseObj.Next.MapName
                };
                var embed = new DiscordEmbedBuilder
                {
                    Title = "Apex Map Bot",
                    Description = "Current Map: " + responseObj.Current.MapName + ". Remaining Minutes: " + responseObj.Current.RemainingMins,
                    ImageUrl = responseObj.Current.Asset,
                    Footer = footer                

                };
                var discordResponse = await discordChannel.SendMessageAsync(embed: embed);



            }
            catch (Exception ex)
            {
                log.LogError("Error getting map rotation", ex);
            }



            return new OkResult();
        }
    }
}
