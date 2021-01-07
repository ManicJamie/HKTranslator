using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modding;

namespace HKTranslator
{
    public class HKTranslator : Mod
    {
        public override string GetVersion() => "1.0";
        public override int LoadPriority() => 1;

        public override void Initialize() // preload Translator and UnTranslator
        {
            base.Initialize();
            Translator.Initialize();
            UnTranslator.Initialize();
        }
    }
}
