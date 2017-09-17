using EasyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Xilium.CefGlue.Client
{
    public class ProcessHook
    {
        public void InitHook()
        {
            var CreateFileHook = LocalHook.Create(EasyHook.LocalHook.GetProcAddress("kernel32.dll", "CreateProcessA"), new CreateProcessDelegate(CreateProcessHooked), null);
            CreateFileHook.ThreadACL.SetExclusiveACL(new int[] { });

        }

        public bool CreateProcessHooked(string lpApplicationName, string lpCommandLine, ref SECURITY_ATTRIBUTES lpProcessAttributes, ref SECURITY_ATTRIBUTES lpThreadAttributes, bool bInheritHandles, UInt32 dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, [In]ref STARTUPINFO lpStartupInfo, ref PROCESS_INFORMATION lpProcessInformation)
        {

            if ((lpCommandLine.IndexOf("echo NOT SANDBOXED")) > 0)
            {
                return System.Convert.ToBoolean(1);
            }

            return CreateProcess(lpApplicationName, lpCommandLine, ref lpProcessAttributes, ref lpThreadAttributes, bInheritHandles, dwCreationFlags, lpEnvironment, lpCurrentDirectory, ref lpStartupInfo, ref lpProcessInformation);
        }

        [UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = true)]
        public delegate bool CreateProcessDelegate(string lpApplicationName, string lpCommandLine, ref SECURITY_ATTRIBUTES lpProcessAttributes, ref SECURITY_ATTRIBUTES lpThreadAttributes, bool bInheritHandles, UInt32 dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, [In]ref STARTUPINFO lpStartupInfo, ref PROCESS_INFORMATION lpProcessInformation);

        [DllImport("kernel32.dll")]
        public static extern bool CreateProcess(string lpApplicationName, string lpCommandLine, ref SECURITY_ATTRIBUTES lpProcessAttributes, ref SECURITY_ATTRIBUTES lpThreadAttributes, bool bInheritHandles, UInt32 dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, [In]ref STARTUPINFO lpStartupInfo, ref PROCESS_INFORMATION lpProcessInformation);

        [StructLayout(LayoutKind.Sequential)]
        public
            struct SECURITY_ATTRIBUTES
        {
            public int nLength;
            public IntPtr lpSecurityDescriptor;
            public int bInheritHandle;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public
            struct STARTUPINFO
        {
            public int cb;
            public string lpReserved;
            public string lpDesktop;
            public string lpTitle;
            public int dwX;
            public int dwY;
            public int dwXSize;
            public int dwYSize;
            public int dwXCountChars;
            public int dwYCountChars;
            public int dwFillAttribute;
            public int dwFlags;
            public short wShowWindow;
            public short cbReserved2;
            public int lpReserved2;
            public int hStdInput;
            public int hStdOutput;
            public int hStdError;
        }

        public struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public int dwProcessId;
            public int dwThreadId;
        }



    }
}
