using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace Macros
{
    public partial class Form1 : Form
    {
        private static bool run = true;
        private static List<WindowTitleProcessor> titleProcessors = new List<WindowTitleProcessor>();
        private static InputSimulator inputSimulator = new InputSimulator();

        //#region Keyboard Monitoring
        //private static LowLevelProc _procKeyboard = new LowLevelProc(HookCallback);
        //private static IntPtr _hookIDKeyboard = IntPtr.Zero;
        //private const int WH_KEYBOARD_LL = 13;
        //private const int WM_KEYDOWN = 256;

        //private delegate IntPtr LowLevelProc(int nCode, IntPtr wParam, IntPtr lParam);

        //private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        //{
        //    if (run)
        //    {
        //        string activeTitle = GetActiveWindowTitle();

        //        if (titleProcessors.TryGetValue(activeTitle, out TitleProcessor titleProcessor))
        //        {
        //        }

        //        if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN))
        //        {

        //        }
        //    }
        //    return CallNextHookEx(_hookIDKeyboard, nCode, wParam, lParam);
        //}

        //private IntPtr SetHook(LowLevelProc proc, int constToWatch)
        //{
        //    using (Process currentProcess = Process.GetCurrentProcess())
        //    {
        //        using (ProcessModule mainModule = currentProcess.MainModule)
        //            return SetWindowsHookEx(constToWatch, proc, GetModuleHandle(mainModule.ModuleName), 0U);
        //    }
        //}

        //[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        //[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelProc lpfn, IntPtr hMod, uint dwThreadId);

        //[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //private static extern IntPtr GetModuleHandle(string lpModuleName);
        //#endregion Keyboard Monitoring

        #region Active Window
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }
        #endregion Active Window

        #region Keyboard Monitoring
        private IKeyboardMouseEvents m_GlobalHook;
        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("KeyPress: \t{0}", e.KeyChar);


            if (run)
            {
                string activeWindowTitle = GetActiveWindowTitle();

                foreach (var titleProcessor in titleProcessors)
                {
                    if (titleProcessor.WindowTitle == activeWindowTitle)
                    {
                        if (e.KeyChar == 13)
                        {

                            string response = titleProcessor.Enter();

                            if (response != null)
                            {
                                Task.Run(() =>
                                {
                                    Thread.Sleep(100);
                                    inputSimulator.Keyboard.TextEntry(response);
                                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                                });


                            }
                        }
                        else
                        {
                            titleProcessor.TypedKey(e.KeyChar);
                        }
                    }
                    else
                    {
                        titleProcessor.Clear();
                    }
                }
            }
        }
        #endregion Keyboard Monitoring

        public Form1()
        {
            InitializeComponent();

            List<WindowTitleSettings> settings = LoadSettings();
            foreach (var item in settings)
            {
                WindowTitleProcessor titleProcessor = new WindowTitleProcessor(item);
                titleProcessors.Add(titleProcessor);
            }

            // _hookIDKeyboard = SetHook(_procKeyboard, WH_KEYBOARD_LL);

            m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.KeyPress += GlobalHookKeyPress;
        }

        private List<WindowTitleSettings> LoadSettings()
        {
            ////throw new NotImplementedException();
            WindowTitleSettings titleSettings = new WindowTitleSettings();
            titleSettings.WindowTitle = "*new 1 - Notepad++";
            Macro macro = new Macro();
            macro.Trigger = "/shrug";
            macro.Response = new List<string>() { @"¯\_(ツ)_/¯" };
            titleSettings.Macros = new Dictionary<string, Macro>();
            titleSettings.Macros.Add(macro.Trigger, macro);

            File.WriteAllText("g.macro", JsonSerialization.Serialize(titleSettings));

            //return new List<WindowTitleSettings>() { titleSettings };

            List<WindowTitleSettings> windowTitleSettings = new List<WindowTitleSettings>();
            foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.macro"))
            {
                WindowTitleSettings settings = JsonSerialization.Deserialize<WindowTitleSettings>(File.ReadAllText(file));
                windowTitleSettings.Add(settings);
            }

            return windowTitleSettings;
        }

        private void OpenSettings(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }
    }
}
