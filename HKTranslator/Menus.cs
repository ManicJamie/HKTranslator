using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modding;

namespace HKTranslator
{
    public partial class HKTranslator : IMenuMod
    {
        public bool ToggleButtonInsideMenu => false;

        public List<IMenuMod.MenuEntry> GetMenuData(IMenuMod.MenuEntry? toggleButtonEntry)
        {
            return new List<IMenuMod.MenuEntry>
            {
                new IMenuMod.MenuEntry
                {
                    Name = "Enabled",
                    Description = null,
                    Values = new string[] {"Off", "On"},
                    Saver = opt => {
                        _gs.Enabled = opt switch {
                            0 => false,
                            1 => true,
                            // This should never be called
                            _ => throw new InvalidOperationException(), 
                        }; 
                    },
                    Loader = () => _gs.Enabled switch
                    {
                        false => 0,
                        true => 1
                    }
                }
            };
        }
    }
}
