using System;

namespace Core.UI
{
    public interface IPresentable
    {
        event Action OnUpdatedEvent;
    }
}