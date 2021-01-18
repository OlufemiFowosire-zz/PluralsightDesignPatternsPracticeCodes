using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPatternLibrary.StarWarsCharacter
{
    public class CharacterFileSourceAdapter : ICharacterSourceAdapter
    {
        private readonly string path;

        private readonly CharacterFileSource characterFileSource;

        public CharacterFileSourceAdapter(string path)
        {
            this.path = path;
            // Use DI to provide this instance in order to manage the undelying lifetime of the target interface
            characterFileSource = new CharacterFileSource();
        }

        // DI introduced to manage the lifetime of CharacterFileSource interface
        public CharacterFileSourceAdapter(string path, CharacterFileSource characterFileSource)
        {
            this.path = path;
            this.characterFileSource = characterFileSource;
        }
        public async Task<IEnumerable<Person>> GetCharacters()
        {
            return (await characterFileSource.GetCharactersFromFileAsync2(path)).Select(character => new CharacterToPersonAdapter(character));
        }
    }
}
