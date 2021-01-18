using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp
{
    public abstract class Prototype
    {
        public abstract Prototype ShallowCopy();

        public abstract Prototype DeepCopy();

        public abstract void Debug();
    }
}
