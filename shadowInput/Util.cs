using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace shadowInput
{
    static class Util
    {
        // TODO Add to shadowAPI2

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        public static bool IsRunning(string proc, bool foreground = true)
        {
            foreach (var item in Process.GetProcessesByName(proc))
            {
                if (!foreground)
                    return true;

                if (item.MainWindowHandle == Util.GetForegroundWindow())
                    return true;
            }

            return false;
        }

        public static bool IsGTARunning(string proc)
        {
            if (Process.GetProcessesByName(proc).Length > 0)
                return true;

            return false;
        }

        public static Process GetGTAProcess(string proc)
        {
            Process[] procs = Process.GetProcessesByName(proc);

            if (procs.Length > 0)
                return procs[0];

            return null;
        }
    }
}
