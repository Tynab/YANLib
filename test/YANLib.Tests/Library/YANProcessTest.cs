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

            if (process.IsNotNull())
            {
                // Act
                await processName.KillAllProcessesByName();
            }
        }
        catch { }
    }

    #endregion
}
