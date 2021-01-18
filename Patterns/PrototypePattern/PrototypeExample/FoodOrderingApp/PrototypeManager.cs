using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp
{
    public class PrototypeManager
    {
        private Dictionary<string, Prototype> prototypes = new Dictionary<string, Prototype>();

        public Prototype this[string key]
        {
            get => prototypes[key];
            set => prototypes.Add(key, value);
        }
    }
}
