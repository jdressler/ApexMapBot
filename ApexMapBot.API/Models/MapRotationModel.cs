using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexMapBot.API.Models
{
    public class MapRotationModel
    {
        [JsonProperty("current")]
        public MapRotation Current { get; set; }
        [JsonProperty("next")]
        public MapRotation Next { get; set; }

    }
}
