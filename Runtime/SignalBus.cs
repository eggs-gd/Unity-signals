// ========================================================================================
// Signals - A typesafe, lightweight messaging lib for Unity.
// ========================================================================================
// 2017-2019, Yanko Oliveira  / http://yankooliveira.com / http://twitter.com/yankooliveira
// Special thanks to Max Knoblich for code review and Aswhin Sudhir for the anonymous 
// function asserts suggestion.
// ========================================================================================
// Inspired by StrangeIOC, minus the clutter.
// Based on http://wiki.unity3d.com/index.php/CSharpMessenger_Extended
// Converted to use strongly typed parameters and prevent use of strings as ids.
//
// Supports up to 3 parameters. More than that, and you should probably use a VO.
//
// Usage:
//    1) Define your class, eg:
//          ScoreSignal : ASignal<int> {}
//    2) Add listeners on portions that should react, eg on Awake():
//          SignalBus.Get<ScoreSignal>().AddListener(OnScore);
//    3) Dispatch, eg:
//          SignalBus.Get<ScoreSignal>().Dispatch(userScore);
//    4) Don't forget to remove the listeners upon destruction! Eg on OnDestroy():
//          SignalBus.Get<ScoreSignal>().RemoveListener(OnScore);
//    5) If you don't want to use global Signals, you can have your very own SignalHub
//       instance in your class
//
// ========================================================================================

using System;

namespace eggsgd.Signals
{
    /// <summary>
    ///     Signals main facade class for global, game-wide signals
    /// </summary>
    public static class SignalBus
    {
        private static readonly SignalHub Hub = new();

        public static TSignal Get<TSignal>() where TSignal : ISignal, new() => Hub.Get<TSignal>();

        public static void AddListenerToHash(string signalHash, Action handler)
        {
            Hub.AddListenerToHash(signalHash, handler);
        }

        public static void RemoveListenerFromHash(string signalHash, Action handler)
        {
            Hub.RemoveListenerFromHash(signalHash, handler);
        }
    }
}