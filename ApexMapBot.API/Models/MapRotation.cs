using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexMapBot.API.Models
{
    public class MapRotation
    {
        [JsonProperty("start")]
        public string Start { get; set; }
        [JsonProperty("end")]
        public string End { get; set; }
        [JsonProperty("readableDate_start")]
        public string StartFormatted { get; set; }
        [JsonProperty("readableDate_end")]
        public string EndFormatted { get; set; }
        [JsonProperty("map")]
        public string MapName { get; set; }
        [JsonProperty("code")]
        public string MapCode { get; set; }
        [JsonProperty("DurationInSecs")]
        public int DurationInSecs { get; set; }
        [JsonProperty("DurationInMinutes")]
        public int DurationMins { get; set; }
        [JsonProperty("asset")]
        public string Asset { get; set; }
        [JsonProperty("remainingSecs")]
        public int RemainingSecs { get; set; }
        [JsonProperty("remainingMins")]
        public int RemainingMins { get; set; }
        [JsonProperty("remainingTimer")]
        public string RemainingTime { get; set; }

       


    }
}
