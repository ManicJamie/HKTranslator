using Modding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UObject = UnityEngine.Object;
using System.IO;
using System.Reflection;
using System.Linq;

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
            if (!CheckSavesDict())
            {
                WriteToFile(Path.Combine(Application.persistentDataPath, "TranslatorDictionary.xml"),
                            ReadEmbeddedXML());
            }

            Instance = this;
            if (_gs == null) { _gs = new Settings(); }
            DictHandler.Initialize();
            if (_gs.Enabled) { Events.SubscribeAll(); }
            
            Log("Initialized");
        }

        private string ReadEmbeddedXML()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith("TranslatorDictionary.xml"));

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new(stream);
            return reader.ReadToEnd();
        }

        private void WriteToFile(string path, string input)
        {
            FileStream fs = File.Create(path);
            var writer = new StreamWriter(fs);
            writer.Write(input);
            Log($"Wrote {path}");
        }

        private bool CheckSavesDict()
        {
            if (!File.Exists(Path.Combine(Application.persistentDataPath, "TranslatorDictionary.xml")))
            {
                Log("TranslatorDictionary.xml missing! Please add TranslatorDictionary.xml to your saves folder. Can be found here: https://github.com/ManicJamie/HKTranslator/blob/master/TranslatorDictionary.xml");
                return false;
            }
            return true;
        }

    }
}