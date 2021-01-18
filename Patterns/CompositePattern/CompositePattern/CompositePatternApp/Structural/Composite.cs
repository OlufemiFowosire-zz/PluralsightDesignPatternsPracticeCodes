using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePatternApp.Structural
{
    public class Composite : Component
    {
        private List<Component> children = new List<Component>();
        public Composite(string name) : base(name)
        {
        }

        public override void Add(Component c)
        {
            children.Add(c);
        }

        public override void PrimaryOperation(int depth)
        {
            Console.WriteLine(new string('-', depth) + Name);
            children.ForEach(c => c.PrimaryOperation(depth + 2));
        }

        public override void Remove(Component c)
        {
            children.Remove(c);
        }
    }
}
