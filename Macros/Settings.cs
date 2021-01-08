using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macros
{
    public partial class Settings : Form
    {
        List<WindowTitleSettings> WindowTitleSettings = new List<WindowTitleSettings>();
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.macro");

            foreach (var item in files)
            {
                WindowTitleSettings.Add(JsonSerialization.Deserialize<WindowTitleSettings>(File.ReadAllText(item)));
            }

            foreach (var item in WindowTitleSettings)
            {
                comboBox_WindowTitle.Items.Add(item.WindowTitle);
            }
        }
        private void LoadSetting(object sender, EventArgs e)
        {
            WindowTitleSettings windowTitleSettings = WindowTitleSettings.FirstOrDefault(f => f.WindowTitle == comboBox_WindowTitle.Text);

            if (windowTitleSettings != null)
            {
                SetTriggers(windowTitleSettings);
            }
        }

        private void SetTriggers(WindowTitleSettings windowTitleSettings)
        {
            comboBox_Trigger.Items.Clear();
            foreach (var item in windowTitleSettings.Macros)
            {
                comboBox_Trigger.Items.Add(item.Key);
            }
        }

        private void UpdateResponses(object sender, EventArgs e)
        {
            WindowTitleSettings windowTitleSettings = WindowTitleSettings.FirstOrDefault(f => f.WindowTitle == comboBox_WindowTitle.Text);

            if (windowTitleSettings != null)
            {
                Macro macro = windowTitleSettings.Macros[comboBox_Trigger.Text];
                if (macro != null)
                {
                    richTextBox_Responses.Clear();
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var item in macro.Response)
                    {
                        stringBuilder.Append(item);
                    }
                    richTextBox_Responses.Text = stringBuilder.ToString();
                }
            }
        }
    }
}
