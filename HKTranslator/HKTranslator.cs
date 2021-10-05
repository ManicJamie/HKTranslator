using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modding;
using System.Reflection;

namespace HKTranslator
{
    public class HKTranslator : Mod, ITogglableMod
    {
        public static HKTranslator Instance;
        const string RANDOMIZER_TYPE_NAME = "RandomizerMod.Events, RandomizerMod3.0";
        const string BENCHWARP_TYPE_NAME = "Benchwarp.Events, Benchwarp";

        public override void Initialize()
        {
            Instance = this;
            DictHandler.Initialize();
            AddSequentialFunction(DictHandler.TranslateSceneName, BENCHWARP_TYPE_NAME, "OnGetSceneName");
            AddAction(LogHandler.InitHelper, RANDOMIZER_TYPE_NAME, "OnHelperLogInit");
            AddAction(LogHandler.LogHelper, RANDOMIZER_TYPE_NAME, "OnHelperLog");
            AddAction(LogHandler.InitTracker, RANDOMIZER_TYPE_NAME, "OnTrackerLogInit");
            AddAction(LogHandler.LogTracker, RANDOMIZER_TYPE_NAME, "OnTrackerLog");
            AddAction(LogHandler.InitSpoiler, RANDOMIZER_TYPE_NAME, "OnSpoilerLogInit");
            AddAction(LogHandler.LogSpoiler, RANDOMIZER_TYPE_NAME, "OnSpoilerLog");
            AddAction(LogHandler.InitCondensedSpoiler, RANDOMIZER_TYPE_NAME, "OnCondensedSpoilerLogInit");
            AddAction(LogHandler.LogCondensedSpoiler, RANDOMIZER_TYPE_NAME, "OnCondensedSpoilerLog");
        }

        public void Unload()
        {
            Instance = null;
            RemoveSequentialFunction(DictHandler.TranslateSceneName, BENCHWARP_TYPE_NAME, "OnGetSceneName");
            RemoveAction(LogHandler.InitHelper, RANDOMIZER_TYPE_NAME, "OnHelperLogInit");
            RemoveAction(LogHandler.LogHelper, RANDOMIZER_TYPE_NAME, "OnHelperLog");
            RemoveAction(LogHandler.InitTracker, RANDOMIZER_TYPE_NAME, "OnTrackerLogInit");
            RemoveAction(LogHandler.LogTracker, RANDOMIZER_TYPE_NAME, "OnTrackerLog");
            RemoveAction(LogHandler.InitSpoiler, RANDOMIZER_TYPE_NAME, "OnSpoilerLogInit");
            RemoveAction(LogHandler.LogSpoiler, RANDOMIZER_TYPE_NAME, "OnSpoilerLog");
            RemoveAction(LogHandler.InitCondensedSpoiler, RANDOMIZER_TYPE_NAME, "OnCondensedSpoilerLogInit");
            RemoveAction(LogHandler.LogCondensedSpoiler, RANDOMIZER_TYPE_NAME, "OnCondensedSpoilerLog");
        }

        public override string GetVersion() => "0.2b";



        #region Events

        /// <summary>
        /// Subscribes an action to a reflected external event
        /// </summary>
        /// <param name="a">Action to be subscribed</param>
        /// <param name="TypeName">Name of the reflected static type</param>
        public void AddAction(Action<string> a, string TypeName, string EventName)
        {
            try
            {
                Type.GetType(TypeName)
                    .GetEvent(EventName, BindingFlags.Public | BindingFlags.Static)
                    .AddEventHandler(null, a);

                Log($"{TypeName.Split(',')[0]}.{EventName} subscribed successfully");
            }
            catch
            {
                Log($"Could not subscribe {TypeName.Split(',')[0]}.{EventName}");
                return;
            }
        }

        /// <summary>
        /// Subscribes an action to a reflected external event
        /// </summary>
        /// <param name="a">Action to be subscribed</param>
        /// <param name="TypeName">Name of the reflected static type</param>
        public void AddAction(Action a, string TypeName, string EventName)
        {
            try
            {
                Type.GetType(TypeName)
                    .GetEvent(EventName, BindingFlags.Public | BindingFlags.Static)
                    .AddEventHandler(null, a);

                Log($"{TypeName.Split(',')[0]}.{EventName} subscribed successfully");
            }
            catch (Exception ex)
            {
                Log($"Could not subscribe {TypeName.Split(',')[0]}.{EventName}");
                Log(ex);
                return;
            }
        }

        /// <summary>
        /// Subscribes a function to a reflected SequentialEventHandler
        /// </summary>
        /// <param name="f">Function to be subscribed</param>
        /// <param name="TypeName">Name of the reflected static type</param>
        /// <param name="FieldName">Name of the SequentialEventHandler in the reflected type</param>
        public void AddSequentialFunction(Func<string,string> f, string TypeName, string FieldName)
        {
            try
            {
                FieldInfo field = Type.GetType(TypeName)
                    .GetField(FieldName, BindingFlags.Public | BindingFlags.Static);
                field.FieldType
                    .GetEvent("Event", BindingFlags.Public | BindingFlags.Instance)
                    .AddEventHandler(field.GetValue(null), f);

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
        public void RemoveAction(Action<string> a, string TypeName, string EventName)
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
        /// Unsubscribes an action from a reflected external event
        /// </summary>
        /// <param name="a">Action to be unsubscribed</param>
        /// <param name="TypeName">Name of the reflected static type</param>
        public void RemoveAction(Action a, string TypeName, string EventName)
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
        public void RemoveSequentialFunction(Func<string, string> f, string TypeName, string FieldName)
        {
            try
            {
                FieldInfo field = Type.GetType(TypeName)
                    .GetField(FieldName, BindingFlags.Public | BindingFlags.Static);
                field.FieldType
                    .GetEvent("Event", BindingFlags.Public | BindingFlags.Instance)
                    .AddEventHandler(field.GetValue(null), f);

                Log($"{TypeName.Split(',')[0]}.{FieldName} unsubscribed successfully");
            }
            catch
            {
                Log($"Could not unsubscribe {TypeName.Split(',')[0]}.{FieldName}");
                return;
            }
        }

        #endregion
    }
}
