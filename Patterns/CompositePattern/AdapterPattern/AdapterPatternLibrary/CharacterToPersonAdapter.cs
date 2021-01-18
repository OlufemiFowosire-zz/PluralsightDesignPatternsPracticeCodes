using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPatternLibrary
{
    public class CharacterToPersonAdapter : Person
    {
        private readonly Character character;

        public CharacterToPersonAdapter(Character character)
        {
            this.character = character ?? throw new ArgumentNullException(nameof(Character));
        }

        public override string Name 
        {
            get => character.FullName;
            set => character.FullName = value; 
        }

        public override string HairColor
        { 
            get => character.Hair; 
            set => character.Hair = value; 
        }
    }
}
