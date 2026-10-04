using System.Diagnostics;

namespace YANLib.Tests.Library;

public partial class YANProcessTest
{
    #region KillAllProcessesByName

    [Fact]
    public async Task KillAllProcessesByName_NullName_DoesNotThrowException_Process()
    {
        // Arrange
        string? processName = null;

        // Act & Assert
        await processName.KillAllProcessesByName();
    }

    [Fact]
    public async Task KillAllProcessesByName_EmptyName_DoesNotThrowException_Process()
    {
        // Arrange
        var processName = string.Empty;

        // Act & Assert
        await processName.KillAllProcessesByName();
    }

    [Fact]
    public async Task KillAllProcessesByName_WhitespaceName_DoesNotThrowException_Process()
    {
        // Arrange
        var processName = "   ";

        // Act & Assert
        await processName.KillAllProcessesByName();
    }

    [Fact]
    public async Task KillAllProcessesByName_NonExistentProcess_DoesNotThrowException_Process()
    {
        // Arrange
        var processName = "NonExistentProcessName12345";

        // Act & Assert
        await processName.KillAllProcessesByName();
    }

    [Fact]
    public async Task KillAllProcessesByName_ValidProcessName_KillsProcess_Process()
    {
        // Arrange
        var processName = "notepad";

        try
        {
            var process = Process.Start("notepad.exe");

            if (process is not null)
            {
                // Act
                await processName.KillAllProcessesByName();
            }
        }
        catch { }
    }

    [Fact]
    public async Task KillAllProcessesByName_MultipleInstances_KillsAllInstances_Process()
    {
        // Arrange
        if (CreateSleepCopy() is not string path)
        {
            return;
        }

        var processes = new List<Process>();

        try
        {
            for (var i = 0; i < 3; i++)
            {
                processes.Add(Process.Start(path, "60"));
            }

            // Act
            await Path.GetFileName(path).KillAllProcessesByName().WaitAsync(TimeSpan.FromSeconds(30));

            // Assert
            Assert.All(processes, static p => Assert.True(p.WaitForExit(5_000)));
        }
        finally
        {
            CleanUp(path, processes);
        }
    }

    #endregion

    private static string? CreateSleepCopy()
    {
        const string sleep = "/bin/sleep";

        // Multi-call binaries such as busybox dispatch on argv[0], so a renamed copy would not behave as sleep
        if (OperatingSystem.IsWindows() || !File.Exists(sleep) || new FileInfo(sleep).ResolveLinkTarget(true) is { Name: not "sleep" })
        {
            return null;
        }

        var path = Path.Combine(Path.GetTempPath(), $"yan{Guid.NewGuid():N}"[..12]);

        File.Copy(sleep, path);

        return path;
    }

    private static void CleanUp(string path, IEnumerable<Process> processes)
    {
        foreach (var process in processes)
        {
            try
            {
                process.Kill();
            }
            catch { }

            process.Dispose();
        }

        File.Delete(path);
    }
}
