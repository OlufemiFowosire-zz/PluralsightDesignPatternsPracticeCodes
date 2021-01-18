using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPatternLibrary.StarWarsCharacter
{
    public class CharacterFileSource
    {
        public async Task<List<Person>> GetCharactersFromFileAsync(string path)
        {
            return JsonConvert.DeserializeObject<List<Person>>(await File.ReadAllTextAsync(path));
        }

        // Providing an example for adapting different result types from a service provider
        public async Task<List<Character>> GetCharactersFromFileAsync2(string path)
        {
            return JsonConvert.DeserializeObject<List<Character>>(await File.ReadAllTextAsync(path));
        }
    }
}
