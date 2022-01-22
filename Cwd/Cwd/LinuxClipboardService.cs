using Cwd.Abstraction;
using Cwd.Extensions;
using System;
using System.Diagnostics;
using System.IO;

namespace Cwd
{
    public class LinuxClipboardService : IClipboardService
    {
        private const string _wslEnvVariableName = "WSL_DISTRO_NAME";

        public void CopyToClipboard(string value)
        {
            var isWsl = Environment.GetEnvironmentVariable(_wslEnvVariableName) is not null;

            var tempFilePath = Path.GetTempFileName();
            File.WriteAllText(tempFilePath, value);

            try
            {
                var argument = (isWsl)
                    ? $"cat {tempFilePath} | clip.exe"
                    : $"cat {tempFilePath} | xsel -i --clipboard";

                using var process = new Process
                {
                    StartInfo = new()
                    {
                        FileName = "bash",
                        Arguments = argument,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = false,
                    }
                };

                process.Start();

                if (!process.DoubleWaitForExit()) throw new TimeoutException($"Process timed out for {argument}.");

                if (process.ExitCode == 0) return;

                throw new InvalidOperationException($"Operation failed for {argument}");
            }
            catch
            {
                throw;
            }
            finally
            {
                File.Delete(tempFilePath);
            }
        }
    }
}
