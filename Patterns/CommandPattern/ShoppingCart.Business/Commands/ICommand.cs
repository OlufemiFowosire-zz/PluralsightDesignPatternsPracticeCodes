namespace ShoppingCart.Business.Commands
{
    public interface ICommand
    {
        void Execute();
        bool CanExecute();
        void Undo();
    } 
}
