using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2CWindowsDesktopClient
{
    public class Configuration
    {
        public Configuration()
        {
            IsPaused = false;
            LoggedInAs = string.Empty;
            LastCliboardText = string.Empty;
        }
        
        public bool IsPaused { get; set; }
        public string LoggedInAs { get; set; }
        public string LastCliboardText {get;set;}
    }
}
