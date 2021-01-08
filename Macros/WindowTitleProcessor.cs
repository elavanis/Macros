using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macros
{
    public class WindowTitleProcessor
    {
        private string TypedKeys { get; set; } = "";
        private WindowTitleSettings TitleSettings { get; set; }

        public WindowTitleProcessor(WindowTitleSettings titleSettings)
        {
            TitleSettings = titleSettings;
        }

        public string WindowTitle
        {
            get
            {
                return TitleSettings.WindowTitle;
            }
        }

        public void TypedKey(char key)
        {
            TypedKeys += key;
        }

        public void Clear()
        {
            TypedKeys = "";
        }

        public string Enter()
        {
            string typedKeys = TypedKeys;
            Clear();

            if (TitleSettings.Macros.TryGetValue(typedKeys, out Macro macro))
            {
                Random random = new Random();
                return macro.Response[random.Next(macro.Response.Count)];
            }
            else
            {
                return null;
            }
        }
    }
}
