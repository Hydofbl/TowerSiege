using Core.Patterns.Behavioral.IObserver;

namespace Core.Patterns.Behavioral
{
    public interface IObserver<T>
    {
        void Update(IObservable<T> observable);
    }
}