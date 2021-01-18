using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethod
{
    public class ColdVeggiePizza : PanFood
    {
        public ColdVeggiePizza()
        {
            RequiresBaking = false;
        }
    }
}
