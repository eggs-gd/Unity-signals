using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace eggsgd.Signals
{
    /// <summary>
    ///     Strongly typed messages with no parameters
    /// </summary>
    public abstract class ASignal : ABaseSignal
    {
        private Action _callback;

        /// <summary>
        ///     Adds a listener to this Signal
        /// </summary>
        /// <param name="handler">Method to be called when signal is fired</param>
        public void AddListener(Action handler)
        {
#if UNITY_EDITOR
            Debug.Assert(
                handler.Method.GetCustomAttributes(typeof(CompilerGeneratedAttribute),
                    false).Length == 0,
                "Adding anonymous delegates as Signal callbacks is not supported (you wouldn't be able to unregister them later).");
#endif
            _callback += handler;
        }

        /// <summary>
        ///     Removes a listener from this Signal
        /// </summary>
        /// <param name="handler">Method to be unregistered from signal</param>
        public void RemoveListener(Action handler)
        {
            _callback -= handler;
        }

        /// <summary>
        ///     Dispatch this signal
        /// </summary>
        public void Dispatch()
        {
            _callback?.Invoke();
        }
    }

    /// <summary>
    ///     Strongly typed messages with 1 parameter
    /// </summary>
    /// <typeparam name="T">Parameter type</typeparam>
    public abstract class ASignal<T> : ABaseSignal
    {
        private Action<T> _callback;

        /// <summary>
        ///     Adds a listener to this Signal
        /// </summary>
        /// <param name="handler">Method to be called when signal is fired</param>
        public void AddListener(Action<T> handler)
        {
#if UNITY_EDITOR
            Debug.Assert(
                handler.Method.GetCustomAttributes(typeof(CompilerGeneratedAttribute),
                    false).Length == 0,
                "Adding anonymous delegates as Signal callbacks is not supported (you wouldn't be able to unregister them later).");
#endif
            _callback += handler;
        }

        /// <summary>
        ///     Removes a listener from this Signal
        /// </summary>
        /// <param name="handler">Method to be unregistered from signal</param>
        public void RemoveListener(Action<T> handler)
        {
            _callback -= handler;
        }

        /// <summary>
        ///     Dispatch this signal with 1 parameter
        /// </summary>
        public void Dispatch(T arg1)
        {
            _callback?.Invoke(arg1);
        }
    }

    /// <summary>
    ///     Strongly typed messages with 2 parameters
    /// </summary>
    /// <typeparam name="T1">First parameter type</typeparam>
    /// <typeparam name="T2">Second parameter type</typeparam>
    public abstract class ASignal<T1, T2> : ABaseSignal
    {
        private Action<T1, T2> _callback;

        /// <summary>
        ///     Adds a listener to this Signal
        /// </summary>
        /// <param name="handler">Method to be called when signal is fired</param>
        public void AddListener(Action<T1, T2> handler)
        {
#if UNITY_EDITOR
            Debug.Assert(
                handler.Method.GetCustomAttributes(typeof(CompilerGeneratedAttribute),
                    false).Length == 0,
                "Adding anonymous delegates as Signal callbacks is not supported (you wouldn't be able to unregister them later).");
#endif
            _callback += handler;
        }

        /// <summary>
        ///     Removes a listener from this Signal
        /// </summary>
        /// <param name="handler">Method to be unregistered from signal</param>
        public void RemoveListener(Action<T1, T2> handler)
        {
            _callback -= handler;
        }

        /// <summary>
        ///     Dispatch this signal
        /// </summary>
        public void Dispatch(T1 arg1, T2 arg2)
        {
            _callback?.Invoke(arg1, arg2);
        }
    }

    /// <summary>
    ///     Strongly typed messages with 3 parameter
    /// </summary>
    /// <typeparam name="T1">First parameter type</typeparam>
    /// <typeparam name="T2">Second parameter type</typeparam>
    /// <typeparam name="T3">Third parameter type</typeparam>
    public abstract class ASignal<T1, T2, T3> : ABaseSignal
    {
        private Action<T1, T2, T3> _callback;

        /// <summary>
        ///     Adds a listener to this Signal
        /// </summary>
        /// <param name="handler">Method to be called when signal is fired</param>
        public void AddListener(Action<T1, T2, T3> handler)
        {
#if UNITY_EDITOR
            Debug.Assert(
                handler.Method.GetCustomAttributes(typeof(CompilerGeneratedAttribute),
                    false).Length == 0,
                "Adding anonymous delegates as Signal callbacks is not supported (you wouldn't be able to unregister them later).");
#endif
            _callback += handler;
        }

        /// <summary>
        ///     Removes a listener from this Signal
        /// </summary>
        /// <param name="handler">Method to be unregistered from signal</param>
        public void RemoveListener(Action<T1, T2, T3> handler)
        {
            _callback -= handler;
        }

        /// <summary>
        ///     Dispatch this signal
        /// </summary>
        public void Dispatch(T1 arg1, T2 arg2, T3 arg3)
        {
            _callback?.Invoke(arg1, arg2, arg3);
        }
    }
}