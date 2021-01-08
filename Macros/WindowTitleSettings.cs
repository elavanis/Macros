using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macros
{
    public class WindowTitleSettings
    {
        public string WindowTitle { get; set; }

        public Dictionary<string, Macro> Macros { get; set; }
    }
}
