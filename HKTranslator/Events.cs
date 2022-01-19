using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace HKTranslator
{
    internal static class Events
    {
        //const string RANDOMIZER_TYPE_NAME = "placeholder randomizer events name";
        const string BENCHWARP_TYPE_NAME = "Benchwarp.Events, Benchwarp";

        private static readonly List<Tuple<Delegate, string, string>> _subActions = new();
        private static readonly List<Tuple<Delegate, string, string>> _subSeqFuncs = new();

        /// <summary>
        /// Subscribes an action to a reflected external event
        /// </summary>
        /// <param name="a">Action to be subscribed</param>
        /// <param name="TypeName">Name of the reflected static type</param>
        public static void AddAction(Delegate a, string TypeName, string EventName)
        {
            try
            {
                Type.GetType(TypeName)
                    .GetEvent(EventName, BindingFlags.Public | BindingFlags.Static)
                    .AddEventHandler(null, a);

                _subActions.Add(Tuple.Create(a, TypeName, EventName));
                Log($"{TypeName.Split(',')[0]}.{EventName} subscribed successfully");
            }
            catch
            {
                Log($"Could not subscribe {TypeName.Split(',')[0]}.{EventName}");
                return;
            }
        }

        /// <summary>
        /// Subscribes a function to a reflected SequentialEventHandler
        /// </summary>
        /// <param name="f">Function to be subscribed</param>
        /// <param name="TypeName">Name of the reflected static type</param>
        /// <param name="FieldName">Name of the SequentialEventHandler in the reflected type</param>
        public static void AddSequentialFunction(Delegate f, string TypeName, string FieldName)
        {
            try
            {
                FieldInfo field = Type.GetType(TypeName)
                    .GetField(FieldName, BindingFlags.Public | BindingFlags.Static);
                field.FieldType
                    .GetEvent("Event", BindingFlags.Public | BindingFlags.Instance)
                    .AddEventHandler(field.GetValue(null), f);

                _subSeqFuncs.Add(Tuple.Create(f, TypeName, FieldName));
                Log($"{TypeName.Split(',')[0]}.{FieldName} subscribed successfully");
            }
            catch
            {
                Log($"Could not subscribe {TypeName.Split(',')[0]}.{FieldName}");
                return;
            }
        }

        /// <summary>
        /// Unsubscribes an action from a reflected external event
        /// </summary>
        /// <param name="a">Action to be unsubscribed</param>
        /// <param name="TypeName">Name of the reflected static type</param>
        public static void RemoveAction(Delegate a, string TypeName, string EventName)
        {
            try
            {
                Type.GetType(TypeName)
                    .GetEvent(EventName, BindingFlags.Public | BindingFlags.Instance)
                    .RemoveEventHandler(null, a);

                Log($"{TypeName.Split(',')[0]}.{EventName} unsubscribed successfully");
            }
            catch
            {
                Log($"Could not unsubscribe {TypeName.Split(',')[0]}.{EventName}");
                return;
            }
        }

        /// <summary>
        /// Unsubscribes a function from a reflected SequentialEventHandler
        /// </summary>
        /// <param name="f">Function to be unsubscribed</param>
        /// <param name="TypeName">Name of the reflected static type</param>
        /// <param name="FieldName">Name of the SequentialEventHandler in the reflected type</param>
        public static void RemoveSequentialFunction(Delegate f, string TypeName, string FieldName)
        {
            try
            {
                FieldInfo field = Type.GetType(TypeName)
                    .GetField(FieldName, BindingFlags.Public | BindingFlags.Static);
                field.FieldType
                    .GetEvent("Event", BindingFlags.Public | BindingFlags.Instance)
                    .RemoveEventHandler(field.GetValue(null), f);

                Log($"{TypeName.Split(',')[0]}.{FieldName} unsubscribed successfully");
            }
            catch
            {
                Log($"Could not unsubscribe {TypeName.Split(',')[0]}.{FieldName}");
                return;
            }
        }

        public static void SubscribeAll()
        {
            AddSequentialFunction(DictHandler.TranslateSceneName, BENCHWARP_TYPE_NAME, "OnGetSceneName");
        }

        public static void RemoveAll()
        {
            foreach (Tuple<Delegate, string, string> func in _subSeqFuncs)
            {
                RemoveSequentialFunction(func.Item1, func.Item2, func.Item3);
            }
            _subSeqFuncs.Clear();
            foreach (Tuple<Delegate, string, string> act in _subActions)
            {
                RemoveAction(act.Item1, act.Item2, act.Item3);
            }
            _subActions.Clear();
        }

        private static void Log(object message)
        {
            HKTranslator.Instance.Log(message);
        }
    }
}
