using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPatternLibrary.StarWarsCharacter
{
    public class StarWarsApiCharacterSourceAdapter : ICharacterSourceAdapter
    {
        // Use DI to provide this instance in order to control its lifetime
        private readonly StarWarsApiClient starWarsApi;

        public StarWarsApiCharacterSourceAdapter()
        {
            starWarsApi = new StarWarsApiClient();
        }
        public StarWarsApiCharacterSourceAdapter(StarWarsApiClient starWarsApi)
        {
            this.starWarsApi = starWarsApi;
        }
        public async Task<IEnumerable<Person>> GetCharacters()
        {
            return await starWarsApi.GetCharacters();
        }
    }
}
