using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPatternLibrary.StarWarsCharacter
{
    public class StarWarsCharacterDisplayService
    {
        private readonly ICharacterSourceAdapter characterSource;

        public StarWarsCharacterDisplayService(CharacterSource source)
        {
            if (source == CharacterSource.File)
            {
                string filePath = @"People.json";
                characterSource = new CharacterFileSourceAdapter(filePath);
            }
            else if (source == CharacterSource.API)
            {
                characterSource = new StarWarsApiCharacterSourceAdapter();
            }
            else
            {
                throw new Exception("Invalid character source");
            }
        }
        public StarWarsCharacterDisplayService(ICharacterSourceAdapter characterSource)
        {
            this.characterSource = characterSource;
        }

        #region From File Only
        public async Task<string> ListCharacters()
        {
            string filePath = @"People.json";
            var people = JsonConvert.DeserializeObject<List<Person>>(await File.ReadAllTextAsync(filePath));

            var sb = new StringBuilder();
            int nameWidth = 30;
            sb.AppendLine($"{"NAME".PadRight(nameWidth)}\t{"HAIR"}");
            foreach (var person in people)
            {
                sb.AppendLine($"{person.Name.PadRight(nameWidth)}\t{person.HairColor}");
            }

            return sb.ToString();
        }
        #endregion

        #region From two sources but Bad Practice
        public async Task<string> ListCharacters(CharacterSource source)
        {
            List<Person> people;
            if (source == CharacterSource.File)
            {
                string filePath = @"People.json";
                people = JsonConvert.DeserializeObject<List<Person>>(await File.ReadAllTextAsync(filePath));
            }
            else if (source == CharacterSource.API)
            {
                using (var client = new HttpClient())
                {
                    string url = "https://swapi.dev/api/people/";
                    string result = await client.GetStringAsync(url);
                    people = JsonConvert.DeserializeObject<ApiResult<Person>>(result).Results;
                }
            }
            else
            {
                throw new Exception("Invalid character source");
            }

            var sb = new StringBuilder();
            int nameWidth = 30;
            sb.AppendLine($"{"NAME".PadRight(nameWidth)}\t{"HAIR"}");
            foreach (var person in people)
            {
                sb.AppendLine($"{person.Name.PadRight(nameWidth)}\t{person.HairColor}");
            }

            return sb.ToString();
        }
        #endregion

        #region From two sources through the constructor but Bad Practice
        public async Task<string> ListCharacters2()
        {
            var people = await characterSource.GetCharacters();

            var sb = new StringBuilder();
            int nameWidth = 30;
            sb.AppendLine($"{"NAME".PadRight(nameWidth)}\t{"HAIR"}");
            foreach (var person in people)
            {
                sb.AppendLine($"{person.Name.PadRight(nameWidth)}\t{person.HairColor}");
            }

            return sb.ToString();
        }
        #endregion

        #region From two sources: Refactored Step 1
        // Move the implementation details of deserializing
        // to its own class
        public async Task<string> ListCharactersRefactored1(CharacterSource source)
        {
            List<Person> people;
            if (source == CharacterSource.File)
            {
                string filePath = @"People.json";
                var charactersource = new CharacterFileSource();
                people = await charactersource.GetCharactersFromFileAsync(filePath);
            }
            else if (source == CharacterSource.API)
            {
                var swapiSource = new StarWarsApiClient();
                people = await swapiSource.GetCharacters();
            }
            else
            {
                throw new Exception("Invalid character source");
            }

            var sb = new StringBuilder();
            int nameWidth = 30;
            sb.AppendLine($"{"NAME".PadRight(nameWidth)}\t{"HAIR"}");
            foreach (var person in people)
            {
                sb.AppendLine($"{person.Name.PadRight(nameWidth)}\t{person.HairColor}");
            }

            return sb.ToString();
        }
        #endregion

        #region From two sources: Refactored Step 2
        public async Task<string> ListCharactersRefactored2(CharacterSource source)
        {
            ICharacterSourceAdapter characterSource;
            if (source == CharacterSource.File)
            {
                string filePath = @"People.json";
                characterSource = new CharacterFileSourceAdapter(filePath);
            }
            else if (source == CharacterSource.API)
            {
                characterSource = new StarWarsApiCharacterSourceAdapter();
            }
            else
            {
                throw new Exception("Invalid character source");
            }

            var people = await characterSource.GetCharacters();

            var sb = new StringBuilder();
            int nameWidth = 30;
            sb.AppendLine($"{"NAME".PadRight(nameWidth)}\t{"HAIR"}");
            foreach (var person in people)
            {
                sb.AppendLine($"{person.Name.PadRight(nameWidth)}\t{person.HairColor}");
            }

            return sb.ToString();
        }
        #endregion

        #region Refactored Step 3: Use DI/Factory

        public async Task<string> ListCharactersRefactored3()
        {
            var people = await characterSource.GetCharacters();

            var sb = new StringBuilder();
            int nameWidth = 30;
            sb.AppendLine($"{"NAME".PadRight(nameWidth)}\t{"HAIR"}");
            foreach (var person in people)
            {
                sb.AppendLine($"{person.Name.PadRight(nameWidth)}\t{person.HairColor}");
            }

            return sb.ToString();
        }

        #endregion
    }
}
