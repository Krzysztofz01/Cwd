﻿using Cwd.Abstraction;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Cwd
{
    class Program
    {
        private static readonly int _success = 0;
        private static readonly int _failure = 1;

        static int Main(string[] args)
        {
            bool printCurrentDirectory = false;

            try
            {
                if (args.Any(a => a.ToLower().Contains("-h") || a.ToLower().Contains("--help")))
                {
                    Help.Print();

                    return _success;
                }

                if (args.Any(a => a.ToLower().Contains("-p") || a.ToLower().Contains("--print"))) printCurrentDirectory = true;

                var clipboardService = GetClipboardService();

                string currentDirectory = Directory.GetCurrentDirectory();

                clipboardService.CopyToClipboard(currentDirectory);

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
