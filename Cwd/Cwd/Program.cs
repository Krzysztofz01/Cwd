using Cwd.Abstraction;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Cwd
{
    class Program
    {
        private static readonly int _success = 0;
        private static readonly int _failure = 1;

        static int Main(string[] args)
        {
            try
            {

                var clipboardService = GetClipboardService();

                string currentDirectory = Directory.GetCurrentDirectory();

                clipboardService.SetClipboardText(currentDirectory);

                Console.WriteLine("Current directory path copied to clipboard...");

                return _success;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return _failure;
            }
        }

        private static IClipboardService GetClipboardService()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {

            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                throw new NotImplementedException();
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                throw new NotImplementedException();
            }

            throw new PlatformNotSupportedException("This operation system is not supported.");
        }
    }
}
