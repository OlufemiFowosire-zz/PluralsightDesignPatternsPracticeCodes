using AdapterPatternLibrary.StarWarsCharacter;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AdapterPatternTest
{
    public class StarWarsCharacterDisplayServiceTest
    {
        private readonly ITestOutputHelper output;

        public StarWarsCharacterDisplayServiceTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public async Task DisplayCharactersFile()
        {
            var service = new StarWarsCharacterDisplayService(CharacterSource.File);

            var result = await service.ListCharacters2();

            output.WriteLine(result);
        }

        [Fact]
        public async Task DisplayCharactersApi()
        {
            var service = new StarWarsCharacterDisplayService(CharacterSource.API);

            var result = await service.ListCharacters2();

            output.WriteLine(result);
        }

        [Fact]
        public async Task DisplayCharactersFromFile()
        {
            var service = new StarWarsCharacterDisplayService(new CharacterFileSourceAdapter(@"People.json", new CharacterFileSource()));

            var result = await service.ListCharactersRefactored3();

            output.WriteLine(result);
        }

        [Fact]
        public async Task DisplayCharactersFromApi()
        {
            var service = new StarWarsCharacterDisplayService(new StarWarsApiCharacterSourceAdapter(new StarWarsApiClient()));

            var result = await service.ListCharactersRefactored3();

            output.WriteLine(result);
        }
    }
}
