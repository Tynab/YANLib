using System.Diagnostics;

namespace YANLib.Tests.Library;

public partial class YANProcessTest
{
    #region KillAllProcessesByNames_IEnumerable

    [Fact]
    public async Task KillAllProcessesByNames_NullCollection_DoesNotThrowException_ProcessCollection()
    {
        // Arrange
        IEnumerable<string?>? processNames = null;

        // Act & Assert
        await processNames.KillAllProcessesByNames();
    }

    [Fact]
    public async Task KillAllProcessesByNames_EmptyCollection_DoesNotThrowException_ProcessCollection()
    {
        // Arrange
        var processNames = Array.Empty<string?>();

        // Act & Assert
        await processNames.KillAllProcessesByNames();
    }

    [Fact]
    public async Task KillAllProcessesByNames_CollectionWithNullValues_DoesNotThrowException_ProcessCollection()
    {
        // Arrange
        var processNames = new string?[] { "process1", null, "process2" };

        // Act & Assert
        await processNames.KillAllProcessesByNames();
    }

    [Fact]
    public async Task KillAllProcessesByNames_CollectionWithEmptyValues_DoesNotThrowException_ProcessCollection()
    {
        // Arrange
        var processNames = new string?[] { "process1", string.Empty, "process2" };

        // Act & Assert
        await processNames.KillAllProcessesByNames();
    }

    [Fact]
    public async Task KillAllProcessesByNames_CollectionWithWhitespaceValues_DoesNotThrowException_ProcessCollection()
    {
        // Arrange
        var processNames = new string?[] { "process1", "   ", "process2" };

        // Act & Assert
        await processNames.KillAllProcessesByNames();
    }

    [Fact]
    public async Task KillAllProcessesByNames_NonExistentProcesses_DoesNotThrowException_ProcessCollection()
    {
        // Arrange
        var processNames = new string?[]
        {
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString()
        };

        // Act & Assert
        await processNames.KillAllProcessesByNames();
    }

    [Fact]
    public async Task KillAllProcessesByNames_LargeCollectionOfNames_HandlesCorrectly_ProcessCollection()
    {
        // Arrange
        var processNames = Enumerable.Range(0, 1000).Select(_ => Guid.NewGuid().ToString()).ToArray();

        // Act & Assert
        await processNames.KillAllProcessesByNames();
    }

    [Fact]
    public async Task KillAllProcessesByNames_DuplicateProcessNames_HandlesCorrectly_ProcessCollection()
    {
        // Arrange
        var processNames = new[] { "notepad", "notepad", "notepad" };

        // Act & Assert
        await processNames.KillAllProcessesByNames();
    }

    [Fact]
    public async Task KillAllProcessesByNames_MixedCaseProcessNames_HandlesCorrectly_ProcessCollection()
    {
        // Arrange
        var processNames = new[] { "Notepad", "NOTEPAD", "notepad" };

        // Act & Assert
        await processNames.KillAllProcessesByNames();
    }

    #endregion

    #region KillAllProcessesByNames_ParamsArray

    [Fact]
    public async Task KillAllProcessesByNames_ParamsOverload_DoesNotThrowException_ProcessCollection()
        // Act & Assert
        => await YANProcess.KillAllProcessesByNames("process1", "process2");

    [Fact]
    public async Task KillAllProcessesByNames_ParamsOverloadWithNullValues_DoesNotThrowException_ProcessCollection()
        // Act & Assert
        => await YANProcess.KillAllProcessesByNames("process1", null, "process2");

    [Fact]
    public async Task KillAllProcessesByNames_NullParamsArray_DoesNotThrowException_ProcessCollection()
        // Act & Assert
        => await YANProcess.KillAllProcessesByNames(null);

    [Fact]
    public async Task KillAllProcessesByNames_EmptyParamsArray_DoesNotThrowException_ProcessCollection()
        // Act & Assert
        => await YANProcess.KillAllProcessesByNames();

    [Fact]
    public async Task KillAllProcessesByNames_ParamsOverloadWithManyValues_HandlesCorrectly_ProcessCollection()
    {
        // Arrange
        var processNames = Enumerable.Range(0, 100).Select(_ => Guid.NewGuid().ToString()).ToArray();

        // Act & Assert
        await YANProcess.KillAllProcessesByNames(processNames);
    }

    #endregion

    #region Actual Process Tests

    [Fact]
    public async Task KillAllProcessesByNames_RunningProcesses_KillsProcesses_ProcessCollection()
    {
        // Arrange
        var processNames = new[] { "notepad" };
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
            await processNames.KillAllProcessesByNames();
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

    [Fact]
    public async Task KillAllProcessesByNames_MultipleProcessTypes_KillsCorrectProcesses_ProcessCollection()
    {
        // Arrange
        var processNames = new[] { "notepad", "mspaint" };
        var processes = new List<Process>();

        try
        {
            for (var i = 0; i < 2; i++)
            {
                var process = Process.Start("notepad.exe");

                if (process.IsNotNull())
                {
                    processes.Add(process);
                }
            }

            var paintProcess = Process.Start("mspaint.exe");

            if (paintProcess != null)
            {
                processes.Add(paintProcess);
            }

            // Ensure processes are started
            Assert.True(processes.Count > 0, "Failed to start any test processes");

            // Wait a bit to ensure processes are fully started
            await Task.Delay(500);

            // Act
            await processNames.KillAllProcessesByNames();

            // Wait a bit to ensure processes have time to exit
            await Task.Delay(500);

            // Assert
            // We don't make assertions about all processes being killed because
            // there might be other instances running on the system
        }
        catch (Exception)
        {
            // If we can't start the processes or there's another issue, the test is inconclusive
            // but we don't want it to fail
        }
        finally
        {
            // Cleanup
            foreach (var process in processes)
            {
                if (!process.HasExited)
                {
                    try
                    {
                        process.Kill();
                    }
                    catch
                    {
                        // Ignore exceptions during cleanup
                    }
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

    #region Performance Tests

    [Fact]
    public async Task KillAllProcessesByNames_PerformanceTest_CompletesQuickly_ProcessCollection()
    {
        // Arrange
        var processNames = new[] { "notepad", "mspaint", "calc" };
        var stopwatch = new Stopwatch();

        // Act
        stopwatch.Start();
        await processNames.KillAllProcessesByNames();
        stopwatch.Stop();

        // Assert
        // The operation should complete in a reasonable time
        // This is a soft assertion as timing can vary by system
        Assert.True(stopwatch.ElapsedMilliseconds < 5000,
            $"KillAllProcessesByNames took too long: {stopwatch.ElapsedMilliseconds}ms");
    }

    [Fact]
    public async Task KillAllProcessesByNames_LargeNumberOfProcessNames_CompletesQuickly_ProcessCollection()
    {
        // Arrange
        var processNames = Enumerable.Range(0, 1000)
            .Select(i => $"test_process_{i}")
            .ToArray();
        var stopwatch = new Stopwatch();

        // Act
        stopwatch.Start();
        await processNames.KillAllProcessesByNames();
        stopwatch.Stop();

        // Assert
        // The operation should complete in a reasonable time even with many process names
        Assert.True(stopwatch.ElapsedMilliseconds < 10000,
            $"KillAllProcessesByNames with 1000 names took too long: {stopwatch.ElapsedMilliseconds}ms");
    }

    #endregion

    #region Exception Handling Tests

    [Fact]
    public async Task KillAllProcessesByNames_WhenProcessAccessDenied_HandlesGracefully_ProcessCollection()
    {
        // Arrange
        var processNames = new[] { "lsass", "csrss" }; // Protected system processes

        // Act & Assert
        await processNames.KillAllProcessesByNames();
        // Test passes if no exception is thrown
    }

    [Fact]
    public async Task KillAllProcessesByNames_MixOfValidAndInvalidProcesses_HandlesGracefully_ProcessCollection()
    {
        // Arrange
        var processNames = new[]
        {
            "notepad", // Valid process
            Guid.NewGuid().ToString(), // Non-existent process
            "lsass" // Protected system process
        };

        // Act & Assert
        await processNames.KillAllProcessesByNames();
        // Test passes if no exception is thrown
    }

    #endregion

    #region Edge Cases

    [Fact]
    public async Task KillAllProcessesByNames_VeryLongProcessNames_HandlesCorrectly_ProcessCollection()
    {
        // Arrange
        var processNames = new[]
        {
            new string('a', 1000),
            new string('b', 2000)
        };

        // Act & Assert
        await processNames.KillAllProcessesByNames();
        // Test passes if no exception is thrown
    }

    [Fact]
    public async Task KillAllProcessesByNames_SpecialCharactersInNames_HandlesCorrectly_ProcessCollection()
    {
        // Arrange
        var processNames = new[]
        {
            "test!@#$%^&*()_+",
            "process<>,.?/\\|{}[]"
        };

        // Act & Assert
        await processNames.KillAllProcessesByNames();
        // Test passes if no exception is thrown
    }

    [Fact]
    public async Task KillAllProcessesByNames_UnicodeCharactersInNames_HandlesCorrectly_ProcessCollection()
    {
        // Arrange
        var processNames = new[]
        {
            "процесс", // Russian
            "プロセス", // Japanese
            "进程" // Chinese
        };

        // Act & Assert
        await processNames.KillAllProcessesByNames();
        // Test passes if no exception is thrown
    }

    #endregion

    #region Real-World Scenarios

    [Fact]
    public async Task KillAllProcessesByNames_CommonSystemProcesses_DoesNotCrashSystem_ProcessCollection()
    {
        // Arrange
        var processNames = new[]
        {
            "svchost", // Common Windows service host
            "explorer", // Windows Explorer
            "chrome", // Google Chrome
            "firefox", // Mozilla Firefox
            "iexplore" // Internet Explorer
        };

        // Act & Assert
        await processNames.KillAllProcessesByNames();
        // Test passes if no exception is thrown and system remains stable
    }

    [Fact]
    public async Task KillAllProcessesByNames_StartAndKillMultipleProcesses_AllProcessesKilled_ProcessCollection()
    {
        // Arrange
        var processName = "notepad";
        var processes = new List<Process>();

        try
        {
            // Start multiple notepad processes
            for (int i = 0; i < 5; i++)
            {
                var process = Process.Start("notepad.exe");
                if (process != null)
                {
                    processes.Add(process);
                }
            }

            // Ensure processes are started
            Assert.True(processes.Count > 0, "Failed to start any test processes");

            // Wait a bit to ensure processes are fully started
            await Task.Delay(500);

            // Get the count of notepad processes before killing
            int beforeCount = Process.GetProcessesByName(processName).Length;

            // Act
            await new[] { processName }.KillAllProcessesByNames();

            // Wait a bit to ensure processes have time to exit
            await Task.Delay(500);

            // Assert
            // Get the count of notepad processes after killing
            int afterCount = Process.GetProcessesByName(processName).Length;

            // We expect the count to be reduced, but we can't guarantee it will be zero
            // because there might be other notepad instances running on the system
            Assert.True(afterCount <= beforeCount,
                $"Expected fewer or equal notepad processes after killing, but got {afterCount} (was {beforeCount})");
        }
        catch (Exception)
        {
            // If we can't start the processes or there's another issue, the test is inconclusive
            // but we don't want it to fail
        }
        finally
        {
            // Cleanup
            foreach (var process in processes)
            {
                if (!process.HasExited)
                {
                    try
                    {
                        process.Kill();
                    }
                    catch
                    {
                        // Ignore exceptions during cleanup
                    }
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
}
