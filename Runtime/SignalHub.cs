using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace eggsgd.Signals
{
    /// <summary>
    ///     A hub for Signals you can implement in your classes
    /// </summary>
    public class SignalHub
    {
        private readonly Dictionary<Type, ISignal> _signals = new();

        /// <summary>
        ///     Getter for a signal of a given type
        /// </summary>
        /// <typeparam name="TSignal">Type of signal</typeparam>
        /// <returns>The proper signal binding</returns>
        public TSignal Get<TSignal>() where TSignal : ISignal, new()
        {
            var signalType = typeof(TSignal);

            if (_signals.TryGetValue(signalType, out var signal))
            {
                return (TSignal)signal;
            }

            return (TSignal)Bind(signalType);
        }

        /// <summary>
        ///     Manually provide a SignalHash and bind it to a given listener
        ///     (you most likely want to use an AddListener, unless you know exactly
        ///     what you are doing)
        /// </summary>
        /// <param name="signalHash">Unique hash for signal</param>
        /// <param name="handler">Callback for signal listener</param>
        public void AddListenerToHash(string signalHash, Action handler)
        {
            var signal = GetSignalByHash(signalHash);
            if (signal is ASignal aSignal)
            {
                aSignal.AddListener(handler);
            }
        }

        /// <summary>
        ///     Manually provide a SignalHash and unbind it from a given listener
        ///     (you most likely want to use a RemoveListener, unless you know exactly
        ///     what you are doing)
        /// </summary>
        /// <param name="signalHash">Unique hash for signal</param>
        /// <param name="handler">Callback for signal listener</param>
        public void RemoveListenerFromHash(string signalHash, Action handler)
        {
            var signal = GetSignalByHash(signalHash);
            if (signal is ASignal aSignal)
            {
                aSignal.RemoveListener(handler);
            }
        }

        private ISignal Bind(Type signalType)
        {
            if (_signals.TryGetValue(signalType, out var signal))
            {
                Debug.LogError($"Signal already registered for type {signalType}");
                return signal;
            }

            signal = (ISignal)Activator.CreateInstance(signalType);
            _signals.Add(signalType, signal);
            return signal;
        }

        private ISignal Bind<T>() where T : ISignal, new() => Bind(typeof(T));

        private ISignal GetSignalByHash(string signalHash)
        {
            return _signals.Values.FirstOrDefault(signal => signal.Hash == signalHash);
        }
    }
}