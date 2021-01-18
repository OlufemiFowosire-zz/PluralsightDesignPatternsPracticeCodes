using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPatternLibrary
{
    public class Person
    {
        public virtual string Name { get; set; }

        public virtual string  Gender { get; set; }


        [JsonProperty("hair_color")]
        public virtual string HairColor { get; set; }
    }
}
