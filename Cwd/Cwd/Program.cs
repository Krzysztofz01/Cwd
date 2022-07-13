using Cwd.Abstraction;
using Cwd.Extensions;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Cwd
{
    class Program
    {
        private const int _success = 0;
        private const int _failure = 1;

        static int Main(string[] args)
        {
            try
            {
                if (args.HasParam("-h", "--help"))
                {
                    Help.Print();

                    return _success;
                }

                var printCurrentDirectory = args.HasParam("-p", "--print");
                var addAdditionalEnterForJump = args.HasParam("-j", "--jump");

                var clipboardService = GetClipboardService();

                string currentDirectory = Directory.GetCurrentDirectory();

                string valueToCopy = addAdditionalEnterForJump
                    ? $"cd {currentDirectory}{Environment.NewLine}"
                    : currentDirectory;

                clipboardService.CopyToClipboard(valueToCopy);

                if (printCurrentDirectory) Console.WriteLine($"{Environment.NewLine}{currentDirectory}{Environment.NewLine}");

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
                return new WindowsClipboardService();
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return new LinuxClipboardService();
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
            }

            throw new PlatformNotSupportedException("This operation system is not supported.");
        }
    }
}
