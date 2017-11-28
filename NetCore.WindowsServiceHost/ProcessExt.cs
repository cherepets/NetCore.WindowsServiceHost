using System.Diagnostics;

namespace NetCore.WindowsServiceHost
{
    internal static class ProcessExt
    {
        public static bool IsRunning(this Process process)
        {
            if (process == null) return false;
            try
            {
                return !process.HasExited;
            }
            catch
            {
                return false;
            }
        }

        public static int GetId(this Process process)
        {
            if (process == null) return -1;
            try
            {
                return process.Id;
            }
            catch
            {
                return -1;
            }
        }

        public static bool Exit(this Process process)
        {
            if (process == null) return false;
            try
            {
                if (!process.IsRunning()) return false;
                process.Kill();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}