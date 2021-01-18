using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdapterPatternLibrary.StarWarsCharacter
{
    public interface ICharacterSourceAdapter
    {
        Task<IEnumerable<Person>> GetCharacters();
    }
}
