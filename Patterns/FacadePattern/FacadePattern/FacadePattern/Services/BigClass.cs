using System;

namespace FacadePattern.Services
{
    public class BigClass
    {
        private int i;
        public BigClass()
        {
        }

        public void IncrementI()
        {
            i++;
        }

        public void SetValueI(int i)
        {
            this.i = i;
        }

        public void DecrementI()
        {
            i--;
        }

        public string GetValueB()
        {
            return "Ball of Mud";
        }

        public int GetValueA()
        {
            return i;
        }

        public void AddedThisMethodLater()
        {

        }

        public void UnrelatedMethod()
        {

        }

        public int AddToI(int addMe)
        {
            return i + addMe;
        }

        public void DoSomething()
        {

        }
    }
}