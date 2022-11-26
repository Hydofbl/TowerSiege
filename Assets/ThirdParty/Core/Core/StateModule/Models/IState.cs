namespace Core.StateModule.Models
{
    public interface IState
    {
        void Begin();
        void Complete();
    }
}