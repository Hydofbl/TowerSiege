using System;
using System.Collections.Generic;
using Core.StateModule.Models;
using JetBrains.Annotations;
using UnityEngine;

namespace Core.StateModule.Core
{
    public class StateHandler : IDisposable
    {
        private readonly Queue<IState> _stateQueue;

        private IState _currentState;
        
        public event Action<IState> OnNewStateStartedEvent;
        public event Action<IState> OnStateCompletedEvent;
        public event Action OnStateQueueEmptiedEvent;

        public StateHandler()
        {
            _stateQueue = new Queue<IState>();
        }

        public StateHandler AddState([NotNull] IState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
            _stateQueue.Enqueue(state);

            return this;
        }

        public IState Next()
        {
            CompleteCurrentState();

            if (_stateQueue.Count <= 0)
            {
                OnStateQueueEmptied();

                return null;
            }
            _currentState = _stateQueue.Dequeue();

            StartCurrentState();
            OnNewStateStarted();

            return _currentState;
        }
        
        private void StartCurrentState() => _currentState?.Begin();

        public void CompleteCurrentState()
        {
            if (_currentState == null)
            {
                return;
            }
            
            _currentState.Complete();
            
            OnStateCompleted();
        }

        private void OnNewStateStarted() => OnNewStateStartedEvent?.Invoke(_currentState);
        private void OnStateCompleted() => OnStateCompletedEvent?.Invoke(_currentState);
        private void OnStateQueueEmptied() => OnStateQueueEmptiedEvent?.Invoke();
        

        public IState GetCurrentState() => _currentState;
        public IState PeekNextState() => _stateQueue.Peek();

        public void Dispose()
        {
            _stateQueue.Clear();
            ReleaseUnmanagedResources();

            GC.SuppressFinalize(this);
        }

        private void ReleaseUnmanagedResources()
        {
            OnNewStateStartedEvent = null;
            OnStateCompletedEvent = null;
            OnStateQueueEmptiedEvent = null;
        }
    }
}