using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modding;

namespace HKTranslator
{
    public class HKTranslator : Mod, ITogglableMod
    {
        public override string GetVersion() => "1.0";
        public override int LoadPriority() => 1;

        public bool translatorsInit = false;

        public override void Initialize() // preload Translator and UnTranslator
        {
            Log("Loading HKTransltor...");
            base.Initialize();
            if (!translatorsInit)
            {
                Log("Initialising dictionaries...");
                Translator.Initialize();
                UnTranslator.Initialize();
                translatorsInit = true;
            } else
            {
                Translator.isTranslating = true;
                UnTranslator.isTranslating = true;
            }
        }

        public void Unload()
        {
            Log("Unloading HKTranslator...");
            Translator.isTranslating = false;
            UnTranslator.isTranslating = false;
        }
    }
}
