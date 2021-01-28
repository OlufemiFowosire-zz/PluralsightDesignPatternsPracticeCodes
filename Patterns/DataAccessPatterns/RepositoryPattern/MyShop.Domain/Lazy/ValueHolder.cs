using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Lazy
{
    public class ValueHolder<T> : IValueHolder<T>
    {
        private readonly Func<object, T> valueLoader;
        private T value;
        public ValueHolder(Func<object, T> valueLoader)
        {
            this.valueLoader = valueLoader;
        }
        public T GetValue(object parameter)
        {
            if(value == null)
            {
                value = valueLoader(parameter);
            }
            return value;
        }
    }
}
