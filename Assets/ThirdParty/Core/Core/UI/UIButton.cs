using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public abstract class UIButton : MonoBehaviour
    {
        protected Button _button;

        protected virtual void Awake()
        {
            InitializeDependencies();
            ListenEvents();
        }

        protected virtual void InitializeDependencies()
        {
            _button = GetComponent<Button>() ?? throw new System.NullReferenceException("Button component not found!");
        }

        protected virtual void OnDestroy() => DestroySafely();
        protected virtual void DestroySafely() => UnsubscribeFromEvents();
        protected virtual void ListenEvents() => _button.onClick.AddListener(DoAction);
        protected virtual void UnsubscribeFromEvents() => _button.onClick.RemoveListener(DoAction);

        protected abstract void DoAction();
    }
}
