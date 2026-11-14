using System.Diagnostics;

namespace YANLib.Tests.Library;

// Starts copies of /bin/sleep under unique names (at most 15 characters, the Linux limit for process names) in a temporary
// directory, and on Dispose kills whatever is still running and deletes the directory, also when a test fails.
// Supported only where /bin/sleep exists (Linux); the tests return early elsewhere.
internal sealed class SleepProcesses : IDisposable
{
    private const string SLEEP_PATH = "/bin/sleep";

    private readonly List<(int Id, string Name)> _started = [];

    public SleepProcesses()
    {
        IsSupported = OperatingSystem.IsLinux() && File.Exists(SLEEP_PATH);
        Directory = Path.Combine(Path.GetTempPath(), $"yanlib-process-{Guid.NewGuid():N}");

        if (IsSupported)
        {
            _ = System.IO.Directory.CreateDirectory(Directory);
        }
    }

    public bool IsSupported { get; }

    public string Directory { get; }

    // A unique process name: prefix + 8 hex digits.
    public static string UniqueName(string prefix = "ys") => $"{prefix}{Guid.NewGuid():N}"[..(prefix.Length + 8)];

    // Copies /bin/sleep as fileName and starts it for 60 seconds; the returned Process is owned by the caller.
    public Process Start(string fileName) => Start(fileName, new Process());

    public TProcess Start<TProcess>(string fileName, TProcess process) where TProcess : Process
    {
        var path = Path.Combine(Directory, fileName);

        if (!File.Exists(path))
        {
            File.Copy(SLEEP_PATH, path);
        }

        process.StartInfo = new ProcessStartInfo(path, "60")
        {
            UseShellExecute = false
        };

        _ = process.Start();
        _started.Add((process.Id, fileName));

        return process;
    }

    public void Dispose()
    {
        foreach (var (id, name) in _started)
        {
            try
            {
                using var process = Process.GetProcessById(id);

                // Never kill a recycled process id.
                if (process.ProcessName == name)
                {
                    process.Kill();
                    _ = process.WaitForExit(TimeSpan.FromSeconds(10));
                }
            }
            catch
            {
                // Already exited.
            }
        }

        try
        {
            System.IO.Directory.Delete(Directory, recursive: true);
        }
        catch
        {
            // Best effort.
        }
    }
}

// Records whether Dispose was called.
internal sealed class DisposeTrackingProcess : Process
{
    public bool IsDisposed { get; private set; }

    protected override void Dispose(bool disposing)
    {
        IsDisposed = true;
        base.Dispose(disposing);
    }
}

public partial class YANProcessTest
{
    // Generous: the machine may be busy; a passing test returns as soon as the process has exited.
    private static readonly TimeSpan ExitTimeout = TimeSpan.FromSeconds(30);

    #region Kill

    [Fact]
    public async Task KillAllProcessesByName_RunningProcess_KillsIt_Process()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsSupported)
        {
            return;
        }

        var name = SleepProcesses.UniqueName();
        using var process = sleepers.Start(name);

        // Act
        await name.KillAllProcessesByName();

        // Assert
        Assert.True(process.WaitForExit(ExitTimeout));
    }

    [Fact]
    public async Task KillAllProcessesByName_NameWithDot_KillsIt_Process()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsSupported)
        {
            return;
        }

        var name = SleepProcesses.UniqueName("ys.");
        using var process = sleepers.Start(name);

        // Act
        await name.KillAllProcessesByName();

        // Assert
        Assert.True(process.WaitForExit(ExitTimeout));
    }

    [Fact]
    public async Task KillAllProcessesByName_PathWithExtension_KillsProcessNamedWithoutExtension_Process()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsSupported)
        {
            return;
        }

        var name = SleepProcesses.UniqueName();
        using var process = sleepers.Start(name);

        // Act (like passing Assembly.Location of an app whose apphost has the assembly's name)
        await Path.Combine(sleepers.Directory, $"{name}.dll").KillAllProcessesByName();

        // Assert
        Assert.True(process.WaitForExit(ExitTimeout));
    }

    [Fact]
    public async Task KillAllProcessesByName_DottedNameWithExtension_KillsProcessNamedWithoutExtension_Process()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsSupported)
        {
            return;
        }

        var name = SleepProcesses.UniqueName("ys.");
        using var process = sleepers.Start(name);

        // Act
        await $"{name}.exe".KillAllProcessesByName();

        // Assert
        Assert.True(process.WaitForExit(ExitTimeout));
    }

    [Fact]
    public async Task KillAllProcessesByNames_BlankNamesMixedIn_KillsTheValidNames_ProcessCollection()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsSupported)
        {
            return;
        }

        var name1 = SleepProcesses.UniqueName();
        var name2 = SleepProcesses.UniqueName();
        using var process1 = sleepers.Start(name1);
        using var process2 = sleepers.Start(name2);

        // Act
        await new[] { null, name1, string.Empty, "   ", name2 }.KillAllProcessesByNames();

        // Assert
        Assert.True(process1.WaitForExit(ExitTimeout));
        Assert.True(process2.WaitForExit(ExitTimeout));
    }

    [Fact]
    public async Task KillAllProcessesByName_SeveralProcessesWithSameName_KillsAll_Process()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsSupported)
        {
            return;
        }

        var name = SleepProcesses.UniqueName();
        using var process1 = sleepers.Start(name);
        using var process2 = sleepers.Start(name);

        // Act
        await name.KillAllProcessesByName();

        // Assert
        Assert.True(process1.WaitForExit(ExitTimeout));
        Assert.True(process2.WaitForExit(ExitTimeout));
    }

    [Fact]
    public async Task KillAndDispose_OneProcessFails_KillsTheOthersDisposesAllAndRethrowsFirstFailure_Process()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsSupported)
        {
            return;
        }

        var name = SleepProcesses.UniqueName();
        var failing = new DisposeTrackingProcess();
        var target = sleepers.Start(name, new DisposeTrackingProcess());
        var targetId = target.Id;

        // Act (a Process that was never started has no Id: reading it throws InvalidOperationException)
        _ = await Assert.ThrowsAsync<InvalidOperationException>(() => new Process[] { failing, target }.KillAndDispose());

        // Assert
        Assert.True(failing.IsDisposed);
        Assert.True(target.IsDisposed);

        try
        {
            using var stillRunning = Process.GetProcessById(targetId);

            Assert.True(stillRunning.ProcessName != name || stillRunning.WaitForExit(ExitTimeout));
        }
        catch (ArgumentException)
        {
            // The process no longer exists.
        }
    }

    [Fact]
    public async Task KillAndDispose_CurrentProcess_IsSkipped_Process()
    {
        // Arrange
        var current = Process.GetCurrentProcess();

        // Act
        var exception = await Record.ExceptionAsync(() => new[] { current }.KillAndDispose());

        // Assert (Kill(entireProcessTree: true) on the calling process would throw InvalidOperationException)
        Assert.Null(exception);
    }

    [Theory]
    [InlineData("some/directory/")]
    [InlineData("/")]
    [InlineData(".exe")]
    [InlineData("   ")]
    public void GetProcessesByFileName_NoFileNameLeft_ReturnsNoProcesses_Process(string processNameOrPath)
    {
        // Arrange & Act (Process.GetProcessesByName("") would return every process)
        var processes = processNameOrPath.GetProcessesByFileName();

        // Assert
        Assert.Empty(processes);
    }

    [Fact]
    public void GetProcessesByFileName_NonExistentName_ReturnsNoProcesses_Process()
        // Arrange & Act & Assert
        => Assert.Empty(SleepProcesses.UniqueName("yn.").GetProcessesByFileName());

    #endregion
}
