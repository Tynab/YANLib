using System.Diagnostics;

namespace YANLib.Tests.Library;

public partial class YANProcessTest
{
    #region KillAllProcessesByNames

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
        IEnumerable<string?> processNames = [];

        // Act & Assert
        await processNames.KillAllProcessesByNames();
    }

    [Fact]
    public async Task KillAllProcessesByNames_CollectionWithNullValues_DoesNotThrowException_ProcessCollection()
    {
        // Arrange
        IEnumerable<string?> processNames = [null, null];

        // Act & Assert
        await processNames.KillAllProcessesByNames();
    }

    [Fact]
    public async Task KillAllProcessesByNames_CollectionWithEmptyValues_DoesNotThrowException_ProcessCollection()
    {
        // Arrange
        IEnumerable<string?> processNames = [string.Empty, string.Empty];

        // Act & Assert
        await processNames.KillAllProcessesByNames();
    }

    [Fact]
    public async Task KillAllProcessesByNames_CollectionWithWhitespaceValues_DoesNotThrowException_ProcessCollection()
    {
        // Arrange
        IEnumerable<string?> processNames = ["   ", "  "];

        // Act & Assert
        await processNames.KillAllProcessesByNames();
    }

    [Fact]
    public async Task KillAllProcessesByNames_CollectionWithMixedValues_DoesNotThrowException_ProcessCollection()
    {
        // Arrange
        IEnumerable<string?> processNames = [null, string.Empty, "   ", "validName"];

        // Act & Assert
        await processNames.KillAllProcessesByNames();
    }

    [Fact]
    public async Task KillAllProcessesByNames_CollectionWithNonExistentProcesses_DoesNotThrowException_ProcessCollection()
    {
        // Arrange
        IEnumerable<string?> processNames = ["NonExistentProcess1", "NonExistentProcess2"];

        // Act & Assert
        await processNames.KillAllProcessesByNames();
    }

    [Fact]
    public async Task KillAllProcessesByNames_ParamsOverload_DoesNotThrowException_ProcessCollection()
        // Act & Assert
        => await YANProcess.KillAllProcessesByNames("NonExistentProcess1", "NonExistentProcess2");

    [Fact]
    public async Task KillAllProcessesByNames_NullParamsArray_DoesNotThrowException_ProcessCollection()
        // Act & Assert
        => await YANProcess.KillAllProcessesByNames(null);

    [Fact]
    public async Task KillAllProcessesByNames_EmptyParamsArray_DoesNotThrowException_ProcessCollection()
        // Act & Assert
        => await YANProcess.KillAllProcessesByNames();

    [Fact]
    public async Task KillAllProcessesByNames_MultipleNamesMultipleInstances_KillsAllInstances_ProcessCollection()
    {
        // Arrange
        if (CreateSleepCopy() is not string path1)
        {
            return;
        }

        string? path2 = null;
        var processes = new List<Process>();

        try
        {
            path2 = CreateSleepCopy()!;

            for (var i = 0; i < 2; i++)
            {
                processes.Add(Process.Start(path1, "60"));
                processes.Add(Process.Start(path2, "60"));
            }

            IEnumerable<string?> processNames = [Path.GetFileName(path1), Path.GetFileName(path2)];

            // Act
            await processNames.KillAllProcessesByNames().WaitAsync(TimeSpan.FromSeconds(30));

            // Assert
            Assert.All(processes, static p => Assert.True(p.WaitForExit(5_000)));
        }
        finally
        {
            CleanUp(path1, processes);

            if (path2 is not null)
            {
                File.Delete(path2);
            }
        }
    }

    [Fact]
    public async Task KillAllProcessesByNames_MixedNullAndValidNames_KillsValidProcesses_ProcessCollection()
    {
        // Arrange
        if (CreateSleepCopy() is not string path)
        {
            return;
        }

        var processes = new List<Process>();

        try
        {
            processes.Add(Process.Start(path, "60"));

            IEnumerable<string?> processNames = [null, string.Empty, "   ", Path.GetFileName(path)];

            // Act
            await processNames.KillAllProcessesByNames().WaitAsync(TimeSpan.FromSeconds(30));

            // Assert
            Assert.True(processes[0].WaitForExit(5_000));
        }
        finally
        {
            CleanUp(path, processes);
        }
    }

    [Fact]
    public async Task KillAllProcessesByNames_ParamsWithMixedNullAndValidNames_KillsValidProcesses_ProcessCollection()
    {
        // Arrange
        if (CreateSleepCopy() is not string path)
        {
            return;
        }

        var processes = new List<Process>();

        try
        {
            processes.Add(Process.Start(path, "60"));

            // Act
            await YANProcess.KillAllProcessesByNames(null, string.Empty, "   ", Path.GetFileName(path)).WaitAsync(TimeSpan.FromSeconds(30));

            // Assert
            Assert.True(processes[0].WaitForExit(5_000));
        }
        finally
        {
            CleanUp(path, processes);
        }
    }

    #endregion
}
