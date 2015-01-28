using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shadowInput
{
    public class InputHook
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int hookId, HookProc lpfn, IntPtr hMod, uint dwThreadId);
        private static delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        private static List<Hotkey> hotkeys = new List<Hotkey>();

        private static string _process = "";

        private static bool paused = true;

        private static IntPtr hook;

        public static void Init(string process)
        {
            _process = process;
            paused = true;
        }
        
        public static void UnInit()
        {

        }

        public static void RegisterHotkey(Hotkey hotkey, bool checkWindowAndChat = true)
        {
            if (checkWindowAndChat)
                hotkey.Check = true;

            hotkeys.Add(hotkey);
        }

        private static IntPtr Hook(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code < 0 || !paused)
                return CallNextHookEx(hook, code, wParam, lParam);



            return CallNextHookEx(hook, code, wParam, lParam);
        }

        public static bool Paused
        {
            get { return paused; }
            set { paused = value; }
        }


    }
}
