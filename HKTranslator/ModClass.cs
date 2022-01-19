using Modding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace HKTranslator
{
    public partial class HKTranslator : Mod, IGlobalSettings<Settings>
    {
        internal static HKTranslator Instance;

        private Settings _gs;


        public void OnLoadGlobal(Settings s)
        {
            _gs = s ?? new Settings();
        }

        public Settings OnSaveGlobal() => _gs;

        public override string GetVersion() => "a0.1";

        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            Log("Initializing");

            Instance = this;
            if (_gs == null) { _gs = new Settings(); }
            DictHandler.Initialize();
            if (_gs.Enabled) { Events.SubscribeAll(); }
            
            Log("Initialized");
        }


    }
}