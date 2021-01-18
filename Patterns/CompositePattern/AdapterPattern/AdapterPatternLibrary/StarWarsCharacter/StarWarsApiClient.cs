using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPatternLibrary.StarWarsCharacter
{
    public class StarWarsApiClient
    {
        public async Task<List<Person>> GetCharacters()
        {
            using (var client = new HttpClient())
            {
                string url = "https://swapi.dev/api/people/";
                string result = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ApiResult<Person>>(result).Results;
            }
        }
    }
}
