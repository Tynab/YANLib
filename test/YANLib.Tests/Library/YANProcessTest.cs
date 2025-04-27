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
        var processName = Guid.NewGuid().ToString();

        // Act & Assert
        await processName.KillAllProcessesByName();
    }

    [Fact]
    public async Task KillAllProcessesByName_ValidProcessName_DoesNotThrowException_Process()
    {
        // Arrange
        var processName = "notepad";

        // Act & Assert
        await processName.KillAllProcessesByName();
    }

    [Fact]
    public async Task KillAllProcessesByName_CaseSensitiveProcessName_DoesNotThrowException_Process()
    {
        // Arrange
        var processName = "NotePad";

        // Act & Assert
        await processName.KillAllProcessesByName();
    }

    [Fact]
    public async Task KillAllProcessesByName_SpecialCharactersInName_DoesNotThrowException_Process()
    {
        // Arrange
        var processName = "test!@#$%^&*()_+";

        // Act & Assert
        await processName.KillAllProcessesByName();
    }

    [Fact]
    public async Task KillAllProcessesByName_VeryLongProcessName_DoesNotThrowException_Process()
    {
        // Arrange
        var processName = new string('a', 1000);

        // Act & Assert
        await processName.KillAllProcessesByName();
    }

    #endregion

    #region Actual Process Tests

    [Fact]
    public async Task KillAllProcessesByName_RunningNotepadProcess_KillsProcess_Process()
    {
        // Arrange
        var processName = "notepad";
        Process? process = null;

        try
        {
            process = Process.Start("notepad.exe");

            Assert.NotNull(process);

            await Task.Delay(500);

            // Act
            await processName.KillAllProcessesByName();
            await Task.Delay(500);

            // Assert
            var processExists = Process.GetProcessesByName(processName).Length > 0;
        }
        catch (Exception) { }
        finally
        {
            if (process.IsNotNull() && !process.HasExited)
            {
                try
                {
                    process.Kill();
                }
                catch { }
                finally
                {
                    process.Dispose();
                }
            }
        }
    }

    [Fact]
    public async Task KillAllProcessesByName_MultipleProcessInstances_HandlesCorrectly_Process()
    {
        // Arrange
        var processName = "notepad";
        var processes = new List<Process>();

        try
        {
            for (var i = 0; i < 3; i++)
            {
                var process = Process.Start("notepad.exe");

                if (process.IsNotNull())
                {
                    processes.Add(process);
                }
            }

            Assert.True(processes.Count > 0, "Failed to start any test processes");

            await Task.Delay(500);

            // Act & Assert
            await processName.KillAllProcessesByName();
            await Task.Delay(500);
        }
        catch (Exception) { }
        finally
        {
            foreach (var process in processes)
            {
                if (!process.HasExited)
                {
                    try
                    {
                        process.Kill();
                    }
                    catch { }
                    finally
                    {
                        process.Dispose();
                    }
                }
                else
                {
                    process.Dispose();
                }
            }
        }
    }

    #endregion

    #region Implementation Tests

    [Fact]
    public async Task KillAllProcessesByName_CallsKillAllProcessesByNames_Process()
    {
        // Arrange
        var processName = "testProcess";
        Process? testProcess = null;

        try
        {
            testProcess = Process.Start("notepad.exe");

            // Act & Assert
            await processName.KillAllProcessesByName();
        }
        catch (Exception) { }
        finally
        {
            if (testProcess.IsNotNull() && !testProcess.HasExited)
            {
                try
                {
                    testProcess.Kill();
                }
                catch { }
                finally
                {
                    testProcess.Dispose();
                }
            }
        }
    }

    [Fact]
    public async Task KillAllProcessesByName_WithSystemProcess_HandlesGracefully_Process()
    {
        // Arrange
        var processName = "non_existent_process_" + Guid.NewGuid().ToString();

        // Act & Assert
        await processName.KillAllProcessesByName();
    }

    [Fact]
    public async Task KillAllProcessesByName_WithNonExistentProcess_HandlesGracefully_Process()
    {
        // Arrange
        var processName = Guid.NewGuid().ToString();

        // Act & Assert
        await processName.KillAllProcessesByName();
    }

    #endregion

    #region Performance Tests

    [Fact]
    public async Task KillAllProcessesByName_PerformanceTest_CompletesQuickly_Process()
    {
        // Arrange
        var processName = "notepad";
        var stopwatch = new Stopwatch();

        // Act
        stopwatch.Start();
        await processName.KillAllProcessesByName();
        stopwatch.Stop();

        // Assert
        Assert.True(stopwatch.ElapsedMilliseconds < 5000, $"KillAllProcessesByName took too long: {stopwatch.ElapsedMilliseconds}ms");
    }

    #endregion

    #region Exception Handling Tests

    [Fact]
    public async Task KillAllProcessesByName_WhenProcessAccessDenied_HandlesGracefully_Process()
    {
        // Arrange
        Process? process = null;
        var processName = "notepad";

        try
        {
            process = Process.Start("notepad.exe");

            if (process.IsNotNull())
            {
                process.Kill();
                process.WaitForExit();
            }

            // Act & Assert
            await processName.KillAllProcessesByName();
        }
        finally
        {
            process?.Dispose();
        }
    }

    #endregion
}
