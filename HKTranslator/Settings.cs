using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modding;

namespace HKTranslator
{
    public class Settings
    {
        private bool enabled;

        public Settings()
        {
            Enabled = true;
        }

        public bool Enabled { get => enabled; 
            set { 
                if (HKTranslator.Instance != null)
                {
                    if (value == true) { Events.SubscribeAll(); }
                    else { Events.RemoveAll(); }
                }
                enabled = value; 
            } 
        }
    }
}
