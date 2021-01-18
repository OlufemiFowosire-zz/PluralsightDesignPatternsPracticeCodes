namespace TemplateMethod
{
    public abstract class PanFoodServiceBase<T> where T: PanFood, new ()
    {
        protected LoggerAdapter logger;
        protected T item;

        public PanFoodServiceBase(LoggerAdapter logger)
        {
            this.logger = logger;
        }

        // The Template Method
        public T Prepare()
        {
            item = new T();
            PrepareCrust();
            AddToppings();
            Cover();
            if (item.RequiresBaking)
                Bake();
            Slice();
            return item;
        }

        protected abstract void Slice();
        protected virtual void Cover() { }
        protected virtual void Bake() { }
        protected abstract void AddToppings();
        protected abstract void PrepareCrust();
    }
}