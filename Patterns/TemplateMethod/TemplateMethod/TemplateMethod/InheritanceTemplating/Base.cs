using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethod.InheritanceTemplating
{
    // Template Method uses the Hollywood principle
    // Don't call us, we will call you.
    public abstract class Base
    {
        private bool importantSetting;

        public virtual void Do()
        {
            initialize();
        }

        private void initialize()
        {
            importantSetting = true;
        }
    }

    public class Child : Base
    {
        public override void Do()
        {
            // TODO
        }
    }
}
