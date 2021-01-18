using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPatternLibrary
{
    public class Character
    {
        [JsonProperty("name")]
        public string FullName { get; set; }


        public string Gender { get; set; }


        [JsonProperty("hair_color")]
        public string Hair { get; set; }
    }
}
