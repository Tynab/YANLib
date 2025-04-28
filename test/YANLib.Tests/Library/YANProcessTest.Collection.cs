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

    #endregion
}
