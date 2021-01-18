using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern.Services
{
    public class BigClassFacade
    {
        private BigClass bigClass;

        public BigClassFacade()
        {

        }

        public void IncreaseBy(int numberToAdd)
        {
            bigClass.AddToI(numberToAdd);
        }

        public void DecreaseBy(int numberToSubtract)
        {
            bigClass.AddToI(-numberToSubtract);
        }

        public int GetCurrentValue()
        {
            return bigClass.GetValueA();
        }
    }
}
