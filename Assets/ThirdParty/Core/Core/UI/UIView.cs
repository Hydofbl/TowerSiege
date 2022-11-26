using UnityEngine;

namespace Core.UI
{
    public abstract class UIView<T> : MonoBehaviour where T : IPresentable
    {
        protected T _boundObject;
        
        public virtual void Setup(T obj)
        {
            _boundObject = obj;

            _boundObject.OnUpdatedEvent += UpdateView;
            
            UpdateView();
        }

        protected abstract void UpdateView();

        protected void OnDestroy()
        {
            DestroySafely();
        }

        protected virtual void DestroySafely()
        {
            UnsubscribeFromEvents();
        }

        protected virtual void UnsubscribeFromEvents()
        {
            if (_boundObject != null)
            {
                _boundObject.OnUpdatedEvent -= UpdateView;
            }
        }
        
        public T GetBoundObject() => _boundObject;
    }
}