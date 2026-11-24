using YANLib.Snowflake;

namespace YANLib.Tests.Library.Snowflake;

public partial class IdGeneratorTest
{
    #region Constructor Tests

    [Fact]
    public void Constructor_ValidParameters_CreatesInstance()
    {
        // Arrange & Act
        var idGenerator = new IdGenerator(1, 1);

        // Assert
        Assert.Equal(1, idGenerator.WorkerId);
        Assert.Equal(1, idGenerator.DatacenterId);
        Assert.Equal(0, idGenerator.Sequence);
    }

    [Fact]
    public void Constructor_WithSequence_CreatesInstance()
    {
        // Arrange & Act
        var idGenerator = new IdGenerator(1, 1, 100);

        // Assert
        Assert.Equal(1, idGenerator.WorkerId);
        Assert.Equal(1, idGenerator.DatacenterId);
        Assert.Equal(100, idGenerator.Sequence);
    }

    [Theory]
    [InlineData(-1, 1)]
    [InlineData(32, 1)]
    public void Constructor_InvalidWorkerId_ThrowsArgumentException(long workerId, long datacenterId)
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new IdGenerator(workerId, datacenterId));

        Assert.Contains("Worker ID must be between 0 and 31", exception.Message);
    }

    [Theory]
    [InlineData(1, -1)]
    [InlineData(1, 32)]
    public void Constructor_InvalidDatacenterId_ThrowsArgumentException(long workerId, long datacenterId)
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new IdGenerator(workerId, datacenterId));

        Assert.Contains("Datacenter ID must be between 0 and 31", exception.Message);
    }

    #endregion

    #region NextId Tests

    [Fact]
    public void NextId_GeneratesUniqueIds()
    {
        // Arrange
        var idGenerator = new IdGenerator(1, 1);
        var ids = new long[100];

        // Act
        for (var i = 0; i < ids.Length; i++)
        {
            ids[i] = idGenerator.NextId();
        }

        // Assert
        Assert.Equal(ids.Length, ids.Distinct().Count());
    }

    [Fact]
    public void NextId_WithCustomEpoch_GeneratesCorrectId()
    {
        // Arrange
        var idGenerator = new IdGenerator(1, 1);
        var customEpoch = 1672531200000 + 86400000;

        // Act
        var id = idGenerator.NextId(customEpoch);
        var (_, WorkerId, DatacenterId) = IdGenerator.ExtractIdComponents(id, customEpoch);

        // Assert
        Assert.Equal(1, WorkerId);
        Assert.Equal(1, DatacenterId);
    }

    [Fact]
    public void NextId_SequentialCalls_GeneratesIncreasingIds()
    {
        // Arrange
        var idGenerator = new IdGenerator(1, 1);

        // Act
        var id1 = idGenerator.NextId();
        var id2 = idGenerator.NextId();
        var id3 = idGenerator.NextId();

        // Assert
        Assert.True(id1 < id2);
        Assert.True(id2 < id3);
    }

    #endregion

    #region NextIdAlphabetic Tests

    [Fact]
    public void NextIdAlphabetic_GeneratesValidString()
    {
        // Arrange
        var idGenerator = new IdGenerator(1, 1);

        // Act
        var id = idGenerator.NextIdAlphabetic();

        // Assert
        Assert.NotNull(id);
        Assert.NotEmpty(id);
        Assert.Matches("^[A-Z]+$", id);
    }

    [Fact]
    public void NextIdAlphabetic_WithCustomEpoch_GeneratesValidString()
    {
        // Arrange
        var idGenerator = new IdGenerator(1, 1);
        var customEpoch = 1672531200000 + 86400000;

        // Act
        var id = idGenerator.NextIdAlphabetic(customEpoch);

        // Assert
        Assert.NotNull(id);
        Assert.NotEmpty(id);
        Assert.Matches("^[A-Z]+$", id);
    }

    [Fact]
    public void NextIdAlphabetic_SequentialCalls_GeneratesUniqueIds()
    {
        // Arrange
        var idGenerator = new IdGenerator(1, 1);
        var ids = new string[100];

        // Act
        for (var i = 0; i < ids.Length; i++)
        {
            ids[i] = idGenerator.NextIdAlphabetic();
        }

        // Assert
        Assert.Equal(ids.Length, ids.Distinct().Count());
    }

    #endregion

    #region NextIdAlphanumeric Tests

    [Fact]
    public void NextIdAlphanumeric_GeneratesValidString()
    {
        // Arrange
        var idGenerator = new IdGenerator(1, 1);

        // Act
        var id = idGenerator.NextIdAlphanumeric();

        // Assert
        Assert.NotNull(id);
        Assert.NotEmpty(id);
        Assert.Matches("^[0-9A-Z]+$", id);
    }

    [Fact]
    public void NextIdAlphanumeric_WithCustomEpoch_GeneratesValidString()
    {
        // Arrange
        var idGenerator = new IdGenerator(1, 1);
        var customEpoch = 1672531200000 + 86400000;

        // Act
        var id = idGenerator.NextIdAlphanumeric(customEpoch);

        // Assert
        Assert.NotNull(id);
        Assert.NotEmpty(id);
        Assert.Matches("^[0-9A-Z]+$", id);
    }

    [Fact]
    public void NextIdAlphanumeric_SequentialCalls_GeneratesUniqueIds()
    {
        // Arrange
        var idGenerator = new IdGenerator(1, 1);
        var ids = new string[100];

        // Act
        for (var i = 0; i < ids.Length; i++)
        {
            ids[i] = idGenerator.NextIdAlphanumeric();
        }

        // Assert
        Assert.Equal(ids.Length, ids.Distinct().Count());
    }

    #endregion

    #region ExtractIdComponents Tests

    [Fact]
    public void ExtractIdComponents_ValidId_ReturnsCorrectComponents()
    {
        // Arrange
        var idGenerator = new IdGenerator(5, 10);
        var id = idGenerator.NextId();

        // Act
        var (Timestamp, WorkerId, DatacenterId) = IdGenerator.ExtractIdComponents(id);

        // Assert
        Assert.Equal(5, WorkerId);
        Assert.Equal(10, DatacenterId);
        Assert.True(Timestamp > DateTime.UtcNow.AddMinutes(-1) && Timestamp <= DateTime.UtcNow);
    }

    [Fact]
    public void ExtractIdComponents_WithCustomEpoch_ReturnsCorrectComponents()
    {
        // Arrange
        var idGenerator = new IdGenerator(5, 10);
        var customEpoch = 1672531200000 + 86400000;
        var id = idGenerator.NextId(customEpoch);

        // Act
        var (Timestamp, WorkerId, DatacenterId) = IdGenerator.ExtractIdComponents(id, customEpoch);

        // Assert
        Assert.Equal(5, WorkerId);
        Assert.Equal(10, DatacenterId);
        Assert.True(Timestamp > DateTime.UtcNow.AddMinutes(-1) && Timestamp <= DateTime.UtcNow);
    }

    [Fact]
    public void ExtractIdComponents_WithSequence_ReturnsCorrectComponents()
    {
        // Arrange
        var idGenerator = new IdGenerator(5, 10);
        var id = idGenerator.NextId();
        var sequence = 42L;

        // Act
        var (_, WorkerId, DatacenterId) = IdGenerator.ExtractIdComponents(id, IdGenerator.TIMESTAMP_EPOCH, sequence);

        // Assert
        Assert.Equal(5, WorkerId);
        Assert.Equal(10, DatacenterId);
    }

    #endregion

    #region ExtractIdAlphabeticComponents Tests

    [Fact]
    public void ExtractIdAlphabeticComponents_ValidId_ReturnsCorrectComponents()
    {
        // Arrange
        var idGenerator = new IdGenerator(5, 10);
        var id = idGenerator.NextIdAlphabetic();

        // Act
        var (Timestamp, WorkerId, DatacenterId) = IdGenerator.ExtractIdAlphabeticComponents(id);

        // Assert
        Assert.Equal(5, WorkerId);
        Assert.Equal(10, DatacenterId);
        Assert.True(Timestamp > DateTime.UtcNow.AddMinutes(-1) && Timestamp <= DateTime.UtcNow);
    }

    [Fact]
    public void ExtractIdAlphabeticComponents_WithCustomEpoch_ReturnsCorrectComponents()
    {
        // Arrange
        var idGenerator = new IdGenerator(5, 10);
        var customEpoch = 1672531200000 + 86400000;
        var id = idGenerator.NextIdAlphabetic(customEpoch);

        // Act
        var (Timestamp, WorkerId, DatacenterId) = IdGenerator.ExtractIdAlphabeticComponents(id, customEpoch);

        // Assert
        Assert.Equal(5, WorkerId);
        Assert.Equal(10, DatacenterId);
        Assert.True(Timestamp > DateTime.UtcNow.AddMinutes(-1) && Timestamp <= DateTime.UtcNow);
    }

    [Fact]
    public void ExtractIdAlphabeticComponents_WithSequence_ReturnsCorrectComponents()
    {
        // Arrange
        var idGenerator = new IdGenerator(5, 10);
        var id = idGenerator.NextIdAlphabetic();
        var sequence = 42L;

        // Act
        var (_, WorkerId, DatacenterId) = IdGenerator.ExtractIdAlphabeticComponents(id, IdGenerator.TIMESTAMP_EPOCH, sequence);

        // Assert
        Assert.Equal(5, WorkerId);
        Assert.Equal(10, DatacenterId);
    }

    #endregion

    #region ExtractIdAlphanumericComponents Tests

    [Fact]
    public void ExtractIdAlphanumericComponents_ValidId_ReturnsCorrectComponents()
    {
        // Arrange
        var idGenerator = new IdGenerator(5, 10);
        var id = idGenerator.NextIdAlphanumeric();

        // Act
        var (Timestamp, WorkerId, DatacenterId) = IdGenerator.ExtractIdAlphanumericComponents(id);

        // Assert
        Assert.Equal(5, WorkerId);
        Assert.Equal(10, DatacenterId);
        Assert.True(Timestamp > DateTime.UtcNow.AddMinutes(-1) && Timestamp <= DateTime.UtcNow);
    }

    [Fact]
    public void ExtractIdAlphanumericComponents_WithCustomEpoch_ReturnsCorrectComponents()
    {
        // Arrange
        var idGenerator = new IdGenerator(5, 10);
        var customEpoch = 1672531200000 + 86400000;
        var id = idGenerator.NextIdAlphanumeric(customEpoch);

        // Act
        var (Timestamp, WorkerId, DatacenterId) = IdGenerator.ExtractIdAlphanumericComponents(id, customEpoch);

        // Assert
        Assert.Equal(5, WorkerId);
        Assert.Equal(10, DatacenterId);
        Assert.True(Timestamp > DateTime.UtcNow.AddMinutes(-1) && Timestamp <= DateTime.UtcNow);
    }

    [Fact]
    public void ExtractIdAlphanumericComponents_WithSequence_ReturnsCorrectComponents()
    {
        // Arrange
        var idGenerator = new IdGenerator(5, 10);
        var id = idGenerator.NextIdAlphanumeric();
        var sequence = 42L;

        // Act
        var (_, WorkerId, DatacenterId) = IdGenerator.ExtractIdAlphanumericComponents(id, IdGenerator.TIMESTAMP_EPOCH, sequence);

        // Assert
        Assert.Equal(5, WorkerId);
        Assert.Equal(10, DatacenterId);
    }

    #endregion

    #region Integration Tests

    [Fact]
    public void IdGeneration_RoundTrip_NumericId()
    {
        // Arrange
        var idGenerator = new IdGenerator(5, 10);

        // Act
        var id = idGenerator.NextId();
        var (_, WorkerId, DatacenterId) = IdGenerator.ExtractIdComponents(id);

        // Assert
        Assert.Equal(5, WorkerId);
        Assert.Equal(10, DatacenterId);
    }

    [Fact]
    public void IdGeneration_RoundTrip_AlphabeticId()
    {
        // Arrange
        var idGenerator = new IdGenerator(5, 10);

        // Act
        var id = idGenerator.NextIdAlphabetic();
        var (_, WorkerId, DatacenterId) = IdGenerator.ExtractIdAlphabeticComponents(id);

        // Assert
        Assert.Equal(5, WorkerId);
        Assert.Equal(10, DatacenterId);
    }

    [Fact]
    public void IdGeneration_RoundTrip_AlphanumericId()
    {
        // Arrange
        var idGenerator = new IdGenerator(5, 10);

        // Act
        var id = idGenerator.NextIdAlphanumeric();
        var (_, WorkerId, DatacenterId) = IdGenerator.ExtractIdAlphanumericComponents(id);

        // Assert
        Assert.Equal(5, WorkerId);
        Assert.Equal(10, DatacenterId);
    }

    [Fact]
    public void IdGeneration_MultipleGenerators_ProduceUniqueIds()
    {
        // Arrange
        var generator1 = new IdGenerator(1, 1);
        var generator2 = new IdGenerator(2, 1);
        var generator3 = new IdGenerator(1, 2);

        // Act
        var id1 = generator1.NextId();
        var id2 = generator2.NextId();
        var id3 = generator3.NextId();

        // Assert
        Assert.NotEqual(id1, id2);
        Assert.NotEqual(id1, id3);
        Assert.NotEqual(id2, id3);
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void NextId_MaximumSequence_GeneratesUniqueIds()
    {
        // Arrange
        var idGenerator = new IdGenerator(1, 1, 4095);

        // Act
        var id1 = idGenerator.NextId();
        var id2 = idGenerator.NextId();

        // Assert
        Assert.NotEqual(id1, id2);
    }

    [Fact]
    public void NextId_MaximumWorkerAndDatacenter_GeneratesValidId()
    {
        // Arrange
        var idGenerator = new IdGenerator(31, 31);

        // Act
        var id = idGenerator.NextId();
        var (_, WorkerId, DatacenterId) = IdGenerator.ExtractIdComponents(id);

        // Assert
        Assert.Equal(31, WorkerId);
        Assert.Equal(31, DatacenterId);
    }

    #endregion

    #region Custom Bit Allocation Constructor Tests

    [Fact]
    public void Constructor_WithCustomBitAllocation_CreatesInstance()
    {
        // Arrange & Act
        var idGenerator = new IdGenerator(workerId: 3, datacenterId: 2, sequence: 0, workerIdBits: 10, datacenterIdBits: 10, sequenceBits: 3);

        // Assert
        Assert.Equal(3, idGenerator.WorkerId);
        Assert.Equal(2, idGenerator.DatacenterId);
        Assert.Equal(0, idGenerator.Sequence);
        Assert.Equal(10, idGenerator.WorkerIdBits);
        Assert.Equal(10, idGenerator.DatacenterIdBits);
        Assert.Equal(3, idGenerator.SequenceBits);
        Assert.Equal(1023, idGenerator.MaxWorkerId);
        Assert.Equal(1023, idGenerator.MaxDatacenterId);
        Assert.Equal(7, idGenerator.MaxSequence);
    }

    [Fact]
    public void Constructor_WithHighVolumeAllocation_CreatesInstance()
    {
        // Arrange & Act
        var idGenerator = new IdGenerator(workerId: 1, datacenterId: 1, sequence: 0, workerIdBits: 2, datacenterIdBits: 2, sequenceBits: 19);

        // Assert
        Assert.Equal(1, idGenerator.WorkerId);
        Assert.Equal(1, idGenerator.DatacenterId);
        Assert.Equal(0, idGenerator.Sequence);
        Assert.Equal(2, idGenerator.WorkerIdBits);
        Assert.Equal(2, idGenerator.DatacenterIdBits);
        Assert.Equal(19, idGenerator.SequenceBits);
        Assert.Equal(3, idGenerator.MaxWorkerId);
        Assert.Equal(3, idGenerator.MaxDatacenterId);
        Assert.Equal(524287, idGenerator.MaxSequence);
    }

    [Theory]
    [InlineData(10, 10, 4)]
    [InlineData(10, 10, 2)]
    [InlineData(24, 0, -1)]
    public void Constructor_InvalidBitAllocation_ThrowsArgumentException(int workerIdBits, int datacenterIdBits, int sequenceBits)
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new IdGenerator(1, 1, 0, workerIdBits, datacenterIdBits, sequenceBits));

        if (sequenceBits < 0)
        {
            Assert.Contains("Sequence bits must be non-negative", exception.Message);
        }
        else
        {
            Assert.Contains("The total bits allocated for worker ID, datacenter ID, and sequence must equal 23", exception.Message);
        }
    }

    [Theory]
    [InlineData(10, 10, 3, 1500, 1)]
    [InlineData(10, 10, 3, 1, 1500)]
    public void Constructor_IdOutOfRangeForCustomBits_ThrowsArgumentException(int workerIdBits, int datacenterIdBits, int sequenceBits, long workerId, long datacenterId)
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new IdGenerator(workerId, datacenterId, 0, workerIdBits, datacenterIdBits, sequenceBits));

        if (workerId > (1 << workerIdBits) - 1)
        {
            Assert.Contains("Worker ID must be between 0 and", exception.Message);
        }
        else
        {
            Assert.Contains("Datacenter ID must be between 0 and", exception.Message);
        }
    }

    #endregion

    #region Custom Bit Allocation NextId Tests

    [Fact]
    public void NextId_WithCustomBitAllocation_GeneratesUniqueIds()
    {
        // Arrange
        var idGenerator = new IdGenerator(workerId: 3, datacenterId: 2, sequence: 0, workerIdBits: 10, datacenterIdBits: 10, sequenceBits: 3);
        var ids = new long[20];

        // Act
        for (var i = 0; i < ids.Length; i++)
        {
            ids[i] = idGenerator.NextId();
        }

        // Assert
        Assert.Equal(ids.Length, ids.Distinct().Count());
    }

    [Fact]
    public void NextId_WithHighVolumeAllocation_GeneratesUniqueIds()
    {
        // Arrange
        var idGenerator = new IdGenerator(workerId: 1, datacenterId: 1, sequence: 0, workerIdBits: 2, datacenterIdBits: 2, sequenceBits: 19);
        var ids = new long[1000];

        // Act
        for (var i = 0; i < ids.Length; i++)
        {
            ids[i] = idGenerator.NextId();
        }

        // Assert
        Assert.Equal(ids.Length, ids.Distinct().Count());
    }

    [Fact]
    public void NextId_WithCustomBitAllocation_SequenceOverflow_GeneratesUniqueIds()
    {
        // Arrange
        var idGenerator = new IdGenerator(workerId: 1, datacenterId: 1, sequence: 6, workerIdBits: 10, datacenterIdBits: 10, sequenceBits: 3);

        // Act
        var id1 = idGenerator.NextId();
        var id2 = idGenerator.NextId();
        var id3 = idGenerator.NextId();

        // Assert
        Assert.True(id1 < id2);
        Assert.True(id2 < id3);
    }

    #endregion

    #region Custom Bit Allocation Component Extraction Tests

    [Fact]
    public void ExtractIdComponents_WithCustomBitAllocation_ReturnsCorrectComponents()
    {
        // Arrange
        var idGenerator = new IdGenerator(workerId: 100, datacenterId: 200, sequence: 0, workerIdBits: 10, datacenterIdBits: 10, sequenceBits: 3);
        var id = idGenerator.NextId();

        // Act
        var (Timestamp, WorkerId, DatacenterId) = IdGenerator.ExtractIdComponents(id, IdGenerator.TIMESTAMP_EPOCH, 0, 10, 10, 3);

        // Assert
        Assert.Equal(100, WorkerId);
        Assert.Equal(200, DatacenterId);
        Assert.True(Timestamp > DateTime.UtcNow.AddMinutes(-1) && Timestamp <= DateTime.UtcNow);
    }

    [Fact]
    public void ExtractIdComponents_WithWrongBitAllocation_ReturnsIncorrectComponents()
    {
        // Arrange
        var idGenerator = new IdGenerator(workerId: 100, datacenterId: 200, sequence: 0, workerIdBits: 10, datacenterIdBits: 10, sequenceBits: 3);
        var id = idGenerator.NextId();

        // Act
        var (_, WorkerId, DatacenterId) = IdGenerator.ExtractIdComponents(id);

        // Assert
        Assert.NotEqual(100, WorkerId);
        Assert.NotEqual(200, DatacenterId);
    }

    [Fact]
    public void ExtractIdAlphabeticComponents_WithCustomBitAllocation_ReturnsCorrectComponents()
    {
        // Arrange
        var idGenerator = new IdGenerator(workerId: 100, datacenterId: 200, sequence: 0, workerIdBits: 10, datacenterIdBits: 10, sequenceBits: 3);
        var id = idGenerator.NextIdAlphabetic();

        // Act
        var (Timestamp, WorkerId, DatacenterId) = IdGenerator.ExtractIdAlphabeticComponents(id, IdGenerator.TIMESTAMP_EPOCH, 0, 10, 10, 3);

        // Assert
        Assert.Equal(100, WorkerId);
        Assert.Equal(200, DatacenterId);
        Assert.True(Timestamp > DateTime.UtcNow.AddMinutes(-1) && Timestamp <= DateTime.UtcNow);
    }

    [Fact]
    public void ExtractIdAlphanumericComponents_WithCustomBitAllocation_ReturnsCorrectComponents()
    {
        // Arrange
        var idGenerator = new IdGenerator(workerId: 100, datacenterId: 200, sequence: 0, workerIdBits: 10, datacenterIdBits: 10, sequenceBits: 3);
        var id = idGenerator.NextIdAlphanumeric();

        // Act
        var (Timestamp, WorkerId, DatacenterId) = IdGenerator.ExtractIdAlphanumericComponents(id, IdGenerator.TIMESTAMP_EPOCH, 0, 10, 10, 3);

        // Assert
        Assert.Equal(100, WorkerId);
        Assert.Equal(200, DatacenterId);
        Assert.True(Timestamp > DateTime.UtcNow.AddMinutes(-1) && Timestamp <= DateTime.UtcNow);
    }

    #endregion

    #region Custom Bit Allocation Integration Tests

    [Fact]
    public void IdGeneration_RoundTrip_WithCustomBitAllocation()
    {
        // Arrange
        var idGenerator = new IdGenerator(workerId: 100, datacenterId: 200, sequence: 0, workerIdBits: 10, datacenterIdBits: 10, sequenceBits: 3);

        // Act
        var id = idGenerator.NextId();
        var (_, WorkerId, DatacenterId) = IdGenerator.ExtractIdComponents(id, IdGenerator.TIMESTAMP_EPOCH, 0, 10, 10, 3);

        // Assert
        Assert.Equal(100, WorkerId);
        Assert.Equal(200, DatacenterId);
    }

    [Fact]
    public void IdGeneration_DifferentBitAllocations_ProduceUniquePatterns()
    {
        // Arrange
        var defaultGenerator = new IdGenerator(1, 1);
        var distributedGenerator = new IdGenerator(1, 1, 0, 10, 10, 3);
        var highVolumeGenerator = new IdGenerator(1, 1, 0, 2, 2, 19);

        // Act
        var defaultId = defaultGenerator.NextId();
        var distributedId = distributedGenerator.NextId();
        var highVolumeId = highVolumeGenerator.NextId();

        // Assert
        Assert.NotEqual(defaultId, distributedId);
        Assert.NotEqual(defaultId, highVolumeId);
        Assert.NotEqual(distributedId, highVolumeId);
    }

    [Fact]
    public void IdGeneration_MaximumValues_WithCustomBitAllocation()
    {
        // Arrange
        var idGenerator = new IdGenerator(workerId: 1023, datacenterId: 1023, sequence: 7, workerIdBits: 10, datacenterIdBits: 10, sequenceBits: 3);

        // Act
        var id = idGenerator.NextId();
        var (_, WorkerId, DatacenterId) = IdGenerator.ExtractIdComponents(id, IdGenerator.TIMESTAMP_EPOCH, 0, 10, 10, 3);

        // Assert
        Assert.Equal(1023, WorkerId);
        Assert.Equal(1023, DatacenterId);
    }

    #endregion

    #region BitAllocationStrategy Constructor Tests

    [Fact]
    public void Constructor_WithDefaultStrategy_CreatesInstance()
    {
        // Arrange & Act
        var idGenerator = new IdGenerator(1, 1, 0, BitAllocationStrategy.Default);

        // Assert
        Assert.Equal(1, idGenerator.WorkerId);
        Assert.Equal(1, idGenerator.DatacenterId);
        Assert.Equal(0, idGenerator.Sequence);
        Assert.Equal(5, idGenerator.WorkerIdBits);
        Assert.Equal(5, idGenerator.DatacenterIdBits);
        Assert.Equal(13, idGenerator.SequenceBits);
        Assert.Equal(31, idGenerator.MaxWorkerId);
        Assert.Equal(31, idGenerator.MaxDatacenterId);
        Assert.Equal(8191, idGenerator.MaxSequence);
    }

    [Fact]
    public void Constructor_WithMoreDistributedStrategy_CreatesInstance()
    {
        // Arrange & Act
        var idGenerator = new IdGenerator(100, 200, 0, BitAllocationStrategy.MoreDistributed);

        // Assert
        Assert.Equal(100, idGenerator.WorkerId);
        Assert.Equal(200, idGenerator.DatacenterId);
        Assert.Equal(0, idGenerator.Sequence);
        Assert.Equal(10, idGenerator.WorkerIdBits);
        Assert.Equal(10, idGenerator.DatacenterIdBits);
        Assert.Equal(3, idGenerator.SequenceBits);
        Assert.Equal(1023, idGenerator.MaxWorkerId);
        Assert.Equal(1023, idGenerator.MaxDatacenterId);
        Assert.Equal(7, idGenerator.MaxSequence);
    }

    [Fact]
    public void Constructor_WithHighVolumeStrategy_CreatesInstance()
    {
        // Arrange & Act
        var idGenerator = new IdGenerator(1, 1, 0, BitAllocationStrategy.HighVolume);

        // Assert
        Assert.Equal(1, idGenerator.WorkerId);
        Assert.Equal(1, idGenerator.DatacenterId);
        Assert.Equal(0, idGenerator.Sequence);
        Assert.Equal(2, idGenerator.WorkerIdBits);
        Assert.Equal(2, idGenerator.DatacenterIdBits);
        Assert.Equal(19, idGenerator.SequenceBits);
        Assert.Equal(3, idGenerator.MaxWorkerId);
        Assert.Equal(3, idGenerator.MaxDatacenterId);
        Assert.Equal(524287, idGenerator.MaxSequence);
    }

    [Fact]
    public void Constructor_WithBalancedStrategy_CreatesInstance()
    {
        // Arrange & Act
        var idGenerator = new IdGenerator(50, 50, 0, BitAllocationStrategy.Balanced);

        // Assert
        Assert.Equal(50, idGenerator.WorkerId);
        Assert.Equal(50, idGenerator.DatacenterId);
        Assert.Equal(0, idGenerator.Sequence);
        Assert.Equal(8, idGenerator.WorkerIdBits);
        Assert.Equal(8, idGenerator.DatacenterIdBits);
        Assert.Equal(7, idGenerator.SequenceBits);
        Assert.Equal(255, idGenerator.MaxWorkerId);
        Assert.Equal(255, idGenerator.MaxDatacenterId);
        Assert.Equal(127, idGenerator.MaxSequence);
    }

    [Theory]
    [InlineData(BitAllocationStrategy.MoreDistributed, 1500, 1)]
    [InlineData(BitAllocationStrategy.HighVolume, 1, 5)]
    public void Constructor_IdOutOfRangeForStrategy_ThrowsArgumentException(BitAllocationStrategy strategy, long workerId, long datacenterId)
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new IdGenerator(workerId, datacenterId, 0, strategy));

        if (strategy == BitAllocationStrategy.MoreDistributed && workerId > 1023)
        {
            Assert.Contains("Worker ID must be between 0 and 1023", exception.Message);
        }
        else if (strategy == BitAllocationStrategy.HighVolume && datacenterId > 3)
        {
            Assert.Contains("Datacenter ID must be between 0 and 3", exception.Message);
        }
    }

    #endregion

    #region BitAllocationStrategy NextId Tests

    [Fact]
    public void NextId_WithDifferentStrategies_GeneratesUniqueIds()
    {
        // Arrange
        var defaultGenerator = new IdGenerator(1, 1, 0, BitAllocationStrategy.Default);
        var distributedGenerator = new IdGenerator(1, 1, 0, BitAllocationStrategy.MoreDistributed);
        var highVolumeGenerator = new IdGenerator(1, 1, 0, BitAllocationStrategy.HighVolume);
        var balancedGenerator = new IdGenerator(1, 1, 0, BitAllocationStrategy.Balanced);

        // Act
        var defaultId = defaultGenerator.NextId();
        var distributedId = distributedGenerator.NextId();
        var highVolumeId = highVolumeGenerator.NextId();
        var balancedId = balancedGenerator.NextId();

        // Assert
        var ids = new[] { defaultId, distributedId, highVolumeId, balancedId };
        Assert.Equal(ids.Length, ids.Distinct().Count());
    }

    [Fact]
    public void NextId_WithHighVolumeStrategy_GeneratesSequentialIds()
    {
        // Arrange
        var idGenerator = new IdGenerator(1, 1, 0, BitAllocationStrategy.HighVolume);
        var ids = new long[1000];

        // Act
        for (var i = 0; i < ids.Length; i++)
        {
            ids[i] = idGenerator.NextId();
        }

        // Assert
        Assert.Equal(ids.Length, ids.Distinct().Count());
        for (var i = 1; i < ids.Length; i++)
        {
            Assert.True(ids[i] > ids[i - 1]);
        }
    }

    #endregion

    #region BitAllocationStrategy Component Extraction Tests

    [Fact]
    public void ExtractIdComponents_WithStrategy_ReturnsCorrectComponents()
    {
        // Arrange
        var idGenerator = new IdGenerator(100, 200, 0, BitAllocationStrategy.MoreDistributed);
        var id = idGenerator.NextId();

        // Act
        var (Timestamp, WorkerId, DatacenterId) = IdGenerator.ExtractIdComponents(id, BitAllocationStrategy.MoreDistributed);

        // Assert
        Assert.Equal(100, WorkerId);
        Assert.Equal(200, DatacenterId);
        Assert.True(Timestamp > DateTime.UtcNow.AddMinutes(-1) && Timestamp <= DateTime.UtcNow);
    }

    [Fact]
    public void ExtractIdComponents_WithWrongStrategy_ReturnsIncorrectComponents()
    {
        // Arrange
        var idGenerator = new IdGenerator(100, 200, 0, BitAllocationStrategy.MoreDistributed);
        var id = idGenerator.NextId();

        // Act
        var (_, WorkerId, DatacenterId) = IdGenerator.ExtractIdComponents(id, BitAllocationStrategy.Default);

        Assert.NotEqual(100, WorkerId);
        Assert.NotEqual(200, DatacenterId);
    }

    [Fact]
    public void ExtractIdAlphabeticComponents_WithStrategy_ReturnsCorrectComponents()
    {
        // Arrange
        var idGenerator = new IdGenerator(100, 200, 0, BitAllocationStrategy.MoreDistributed);
        var id = idGenerator.NextIdAlphabetic();

        // Act
        var (Timestamp, WorkerId, DatacenterId) = IdGenerator.ExtractIdAlphabeticComponents(id, BitAllocationStrategy.MoreDistributed);

        // Assert
        Assert.Equal(100, WorkerId);
        Assert.Equal(200, DatacenterId);
        Assert.True(Timestamp > DateTime.UtcNow.AddMinutes(-1) && Timestamp <= DateTime.UtcNow);
    }

    [Fact]
    public void ExtractIdAlphanumericComponents_WithStrategy_ReturnsCorrectComponents()
    {
        // Arrange
        var idGenerator = new IdGenerator(100, 200, 0, BitAllocationStrategy.MoreDistributed);
        var id = idGenerator.NextIdAlphanumeric();

        // Act
        var (Timestamp, WorkerId, DatacenterId) = IdGenerator.ExtractIdAlphanumericComponents(id, BitAllocationStrategy.MoreDistributed);

        // Assert
        Assert.Equal(100, WorkerId);
        Assert.Equal(200, DatacenterId);
        Assert.True(Timestamp > DateTime.UtcNow.AddMinutes(-1) && Timestamp <= DateTime.UtcNow);
    }

    #endregion

    #region BitAllocationStrategy Integration Tests

    [Fact]
    public void IdGeneration_RoundTrip_WithStrategy()
    {
        // Arrange
        var strategies = new[]
        {
            BitAllocationStrategy.Default,
            BitAllocationStrategy.MoreDistributed,
            BitAllocationStrategy.HighVolume,
            BitAllocationStrategy.Balanced
        };

        foreach (var strategy in strategies)
        {
            long workerId, datacenterId;

            switch (strategy)
            {
                case BitAllocationStrategy.MoreDistributed:
                {
                    workerId = 100;
                    datacenterId = 200;
                    break;
                }
                case BitAllocationStrategy.HighVolume:
                {
                    workerId = 2;
                    datacenterId = 3;
                    break;
                }
                case BitAllocationStrategy.Balanced:
                {
                    workerId = 50;
                    datacenterId = 100;
                    break;
                }
                default:
                {
                    workerId = 10;
                    datacenterId = 20;
                    break;
                }
            }

            var idGenerator = new IdGenerator(workerId, datacenterId, 0, strategy);

            // Act
            var id = idGenerator.NextId();
            var (_, extractedWorkerId, extractedDatacenterId) = IdGenerator.ExtractIdComponents(id, strategy);

            // Assert
            Assert.Equal(workerId, extractedWorkerId);
            Assert.Equal(datacenterId, extractedDatacenterId);
        }
    }

    [Fact]
    public void IdGeneration_MaximumValues_WithStrategy()
    {
        // Arrange & Act & Assert

        // Default strategy (5-5-13)
        var defaultGenerator = new IdGenerator(31, 31, 0, BitAllocationStrategy.Default);
        var defaultId = defaultGenerator.NextId();
        var (_, defaultWorkerId, defaultDatacenterId) = IdGenerator.ExtractIdComponents(defaultId, BitAllocationStrategy.Default);
        Assert.Equal(31, defaultWorkerId);
        Assert.Equal(31, defaultDatacenterId);

        // MoreDistributed strategy (10-10-3)
        var distributedGenerator = new IdGenerator(1023, 1023, 0, BitAllocationStrategy.MoreDistributed);
        var distributedId = distributedGenerator.NextId();
        var (_, distributedWorkerId, distributedDatacenterId) = IdGenerator.ExtractIdComponents(distributedId, BitAllocationStrategy.MoreDistributed);
        Assert.Equal(1023, distributedWorkerId);
        Assert.Equal(1023, distributedDatacenterId);

        // HighVolume strategy (2-2-19)
        var highVolumeGenerator = new IdGenerator(3, 3, 0, BitAllocationStrategy.HighVolume);
        var highVolumeId = highVolumeGenerator.NextId();
        var (_, highVolumeWorkerId, highVolumeDatacenterId) = IdGenerator.ExtractIdComponents(highVolumeId, BitAllocationStrategy.HighVolume);
        Assert.Equal(3, highVolumeWorkerId);
        Assert.Equal(3, highVolumeDatacenterId);

        // Balanced strategy (8-8-7)
        var balancedGenerator = new IdGenerator(255, 255, 0, BitAllocationStrategy.Balanced);
        var balancedId = balancedGenerator.NextId();
        var (_, balancedWorkerId, balancedDatacenterId) = IdGenerator.ExtractIdComponents(balancedId, BitAllocationStrategy.Balanced);
        Assert.Equal(255, balancedWorkerId);
        Assert.Equal(255, balancedDatacenterId);
    }

    #endregion

    #region Sequence, Round Trip and Validation

    [Theory]
    [InlineData(-1)]
    [InlineData(8192)]
    public void Constructor_SequenceOutOfRange_ThrowsArgumentOutOfRangeException(long sequence)
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new IdGenerator(1, 1, sequence));

        Assert.Equal("sequence", exception.ParamName);
        Assert.Contains("Sequence must be between 0 and 8191", exception.Message);
    }

    [Fact]
    public void Constructor_SequenceOutOfRangeForCustomBits_ThrowsArgumentOutOfRangeException()
        // Arrange & Act & Assert
        => _ = Assert.Throws<ArgumentOutOfRangeException>(() => new IdGenerator(1, 1, 8, 10, 10, 3));

    [Fact]
    public void Constructor_SequenceOutOfRangeForStrategy_ThrowsArgumentOutOfRangeException()
        // Arrange & Act & Assert
        => _ = Assert.Throws<ArgumentOutOfRangeException>(() => new IdGenerator(1, 1, 128, BitAllocationStrategy.Balanced));

    [Fact]
    public void NextId_WithInitialSequence_UsesItForFirstId()
    {
        // Arrange
        var idGenerator = new IdGenerator(1, 1, 100);

        // Act
        var id = idGenerator.NextId();

        // Assert
        Assert.Equal(100, id & idGenerator.MaxSequence);
        Assert.Equal(100, idGenerator.Sequence);
    }

    [Fact]
    public void NextId_WithMaximumInitialSequence_StaysUnique()
    {
        // Arrange
        var idGenerator = new IdGenerator(workerId: 1, datacenterId: 1, sequence: 7, workerIdBits: 10, datacenterIdBits: 10, sequenceBits: 3);

        // Act
        var ids = Enumerable.Range(0, 100).Select(_ => idGenerator.NextId()).ToList();

        // Assert
        Assert.Equal(7, ids[0] & 7);
        Assert.Equal(ids.Count, ids.Distinct().Count());
        Assert.Equal(ids.OrderBy(x => x), ids);
    }

    [Theory]
    [InlineData(BitAllocationStrategy.Default, 31, 7)]
    [InlineData(BitAllocationStrategy.MoreDistributed, 1000, 1023)]
    [InlineData(BitAllocationStrategy.HighVolume, 3, 2)]
    [InlineData(BitAllocationStrategy.Balanced, 200, 100)]
    public void NextId_RoundTrip_ExtractsAllComponents(BitAllocationStrategy strategy, long workerId, long datacenterId)
    {
        // Arrange
        var idGenerator = new IdGenerator(workerId, datacenterId, 0, strategy);

        // Act
        var before = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        var id = idGenerator.NextId();
        var after = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        var sequence = idGenerator.Sequence;
        var (timestamp, extractedWorkerId, extractedDatacenterId) = IdGenerator.ExtractIdComponents(id, strategy);
        var milliseconds = new DateTimeOffset(timestamp).ToUnixTimeMilliseconds();

        // Assert
        Assert.Equal(DateTimeKind.Utc, timestamp.Kind);
        Assert.InRange(milliseconds, before, after);
        Assert.Equal(workerId, extractedWorkerId);
        Assert.Equal(datacenterId, extractedDatacenterId);
        Assert.Equal(sequence, id & idGenerator.MaxSequence);
    }

    [Fact]
    public void ExtractIdComponents_WithSequenceArgument_DoesNotShiftTimestamp()
    {
        // Arrange
        var idGenerator = new IdGenerator(5, 10);
        var id = idGenerator.NextId();

        // Act
        var (withoutSequence, _, _) = IdGenerator.ExtractIdComponents(id);
        var (withSequence, _, _) = IdGenerator.ExtractIdComponents(id, IdGenerator.TIMESTAMP_EPOCH, 42);
        var (alphabetic, _, _) = IdGenerator.ExtractIdAlphabeticComponents(idGenerator.NextIdAlphabetic(), IdGenerator.TIMESTAMP_EPOCH, 42);

        // Assert
        Assert.Equal(withoutSequence, withSequence);
        Assert.InRange(alphabetic, withoutSequence, DateTime.UtcNow);
    }

    [Fact]
    public void NextId_EpochInFuture_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var idGenerator = new IdGenerator(5, 10);
        var epoch = DateTimeOffset.UtcNow.AddDays(1).ToUnixTimeMilliseconds();

        // Act & Assert (8.3.3 returned a negative ID)
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => idGenerator.NextId(epoch));

        Assert.Equal("timestampEpoch", exception.ParamName);
        Assert.Equal(epoch, exception.ActualValue);
    }

    [Fact]
    public void NextIdAlphabetic_EpochInFuture_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var idGenerator = new IdGenerator(5, 10);
        var epoch = DateTimeOffset.UtcNow.AddDays(1).ToUnixTimeMilliseconds();

        // Act & Assert (8.3.3 returned the negative ID encoded as its unsigned 64-bit value)
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => idGenerator.NextIdAlphabetic(epoch));

        Assert.Equal("timestampEpoch", exception.ParamName);
    }

    [Fact]
    public void NextIdAlphanumeric_EpochInFuture_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var idGenerator = new IdGenerator(5, 10);
        var epoch = DateTimeOffset.UtcNow.AddDays(1).ToUnixTimeMilliseconds();

        // Act & Assert (8.3.3 returned the negative ID encoded as its unsigned 64-bit value)
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => idGenerator.NextIdAlphanumeric(epoch));

        Assert.Equal("timestampEpoch", exception.ParamName);
    }

    [Theory]
    [InlineData(long.MaxValue)]
    [InlineData(long.MinValue)]
    [InlineData(long.MinValue + 1)]
    public void NextId_EpochAtTheEndsOfLong_ThrowsArgumentOutOfRangeException(long epoch)
    {
        // Arrange (long.MinValue: the subtraction wraps, the time since the epoch is far beyond 2^41 ms)
        var idGenerator = new IdGenerator(5, 10);

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => idGenerator.NextId(epoch));

        Assert.Equal("timestampEpoch", exception.ParamName);
    }

    [Fact]
    public void NextId_EpochIsNow_HasTimestampZeroOrJustAbove()
    {
        // Arrange (the current time can only be at or after the epoch when NextId reads it)
        var idGenerator = new IdGenerator(5, 10);
        var epoch = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        // Act
        var id = idGenerator.NextId(epoch);
        var after = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        var (timestamp, workerId, datacenterId) = IdGenerator.ExtractIdComponents(id, epoch);

        // Assert
        Assert.InRange(id >> 23, 0, after - epoch);
        Assert.InRange(new DateTimeOffset(timestamp).ToUnixTimeMilliseconds(), epoch, after);
        Assert.Equal(5, workerId);
        Assert.Equal(10, datacenterId);
    }

    [Fact]
    public void NextId_EpochNearlyTwoToThe41MillisecondsAgo_FillsTheTimestampField()
    {
        // Arrange: 2^41 - 1 ms before now, plus a margin of ten minutes for the time the test takes. The timestamp reaches the sign bit,
        // so the ID is negative, and the string forms encode it as its unsigned 64-bit value
        const long largest = (1L << 41) - 1;
        const long margin = 10 * 60 * 1000;
        var idGenerator = new IdGenerator(5, 10);
        var epoch = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - largest + margin;

        // Act
        var id = idGenerator.NextId(epoch);
        var alphabetic = idGenerator.NextIdAlphabetic(epoch);
        var alphanumeric = idGenerator.NextIdAlphanumeric(epoch);
        var (_, workerId, datacenterId) = IdGenerator.ExtractIdAlphabeticComponents(alphabetic, epoch);
        var (_, alphanumericWorkerId, alphanumericDatacenterId) = IdGenerator.ExtractIdAlphanumericComponents(alphanumeric, epoch);

        // Assert
        Assert.True(id < 0);
        Assert.InRange((long)((ulong)id >> 23), largest - margin, largest);
        Assert.Matches("^[A-Z]+$", alphabetic);
        Assert.Matches("^[0-9A-Z]+$", alphanumeric);
        Assert.Equal((5L, 10L), (workerId, datacenterId));
        Assert.Equal((5L, 10L), (alphanumericWorkerId, alphanumericDatacenterId));
    }

    [Fact]
    public void ExtractIdComponents_IdWithTheSignBitSet_ReadsTheTimestampUnsigned()
    {
        // Arrange: the Unix epoch is more than 2^40 ms (about 34.8 years) ago, so the timestamp reaches the sign bit and the ID is negative
        // (8.3.3 read such a timestamp 2^41 ms, about 69.7 years, too early)
        var idGenerator = new IdGenerator(5, 10);
        var before = DateTime.UtcNow.AddMinutes(-10);

        // Act
        var id = idGenerator.NextId(0L);
        var (timestamp, workerId, datacenterId) = IdGenerator.ExtractIdComponents(id, 0L);
        var (alphabeticTimestamp, _, _) = IdGenerator.ExtractIdAlphabeticComponents(idGenerator.NextIdAlphabetic(0L), 0L);
        var (alphanumericTimestamp, _, _) = IdGenerator.ExtractIdAlphanumericComponents(idGenerator.NextIdAlphanumeric(0L), 0L);
        var after = DateTime.UtcNow.AddMinutes(10);

        // Assert
        Assert.True(id < 0);
        Assert.InRange(timestamp, before, after);
        Assert.InRange(alphabeticTimestamp, before, after);
        Assert.InRange(alphanumericTimestamp, before, after);
        Assert.Equal((5L, 10L), (workerId, datacenterId));
    }

    [Fact]
    public void NextId_EpochTwoToThe41MillisecondsAgo_ThrowsArgumentOutOfRangeException()
    {
        // Arrange (whenever NextId reads the clock, at least 2^41 ms have passed since this epoch)
        var idGenerator = new IdGenerator(5, 10);
        var epoch = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - (1L << 41);

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => idGenerator.NextIdAlphabetic(epoch));

        Assert.Equal("timestampEpoch", exception.ParamName);
        Assert.Equal(epoch, exception.ActualValue);
    }

    [Fact]
    public void NextId_InvalidEpoch_DoesNotUseUpASequenceNumber()
    {
        // Arrange
        var idGenerator = new IdGenerator(workerId: 1, datacenterId: 1, sequence: 5);
        var lastTimestamp = typeof(IdGenerator).GetField("_lastTimestamp", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        var future = DateTimeOffset.UtcNow.AddDays(1).ToUnixTimeMilliseconds();

        Assert.NotNull(lastTimestamp);

        // Act & Assert: before the first ID
        _ = Assert.Throws<ArgumentOutOfRangeException>(() => idGenerator.NextId(future));
        _ = Assert.Throws<ArgumentOutOfRangeException>(() => idGenerator.NextIdAlphabetic(future));

        Assert.Equal(5, idGenerator.Sequence);
        Assert.Equal(-1L, lastTimestamp.GetValue(idGenerator));

        // the first ID still uses the sequence passed to the constructor
        var id = idGenerator.NextId();

        Assert.Equal(5, id & idGenerator.MaxSequence);

        // after an ID, a failing call leaves the last timestamp and the sequence as they were
        var last = lastTimestamp.GetValue(idGenerator);
        var sequence = idGenerator.Sequence;

        _ = Assert.Throws<ArgumentOutOfRangeException>(() => idGenerator.NextIdAlphanumeric(future));

        Assert.Equal(last, lastTimestamp.GetValue(idGenerator));
        Assert.Equal(sequence, idGenerator.Sequence);
    }

    [Theory]
    [InlineData("HLHXCZMXSYUMQP", "3W5E11264SGSF")]
    public void ExtractIdComponents_NegativeIdStrings_ReadTheSameId(string alphabetic, string alphanumeric)
    {
        // the largest strings stand for the unsigned 64-bit value of -1, the encoding of a negative ID
        // Act
        var expected = IdGenerator.ExtractIdComponents(-1);
        var fromAlphabetic = IdGenerator.ExtractIdAlphabeticComponents(alphabetic);
        var fromAlphanumeric = IdGenerator.ExtractIdAlphanumericComponents(alphanumeric);

        // Assert
        Assert.Equal(expected, fromAlphabetic);
        Assert.Equal(expected, fromAlphanumeric);
        Assert.Equal((31L, 31L), (expected.WorkerId, expected.DatacenterId));
    }

    [Theory]
    [InlineData("")]
    [InlineData("abc")]
    [InlineData("AB-C")]
    [InlineData("AB1")]
    [InlineData("ZZZZZZZZZZZZZZZZ")]
    [InlineData("HLHXCZMXSYUMQQ")]
    public void ExtractIdAlphabeticComponents_InvalidId_ThrowsArgumentException(string id)
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => IdGenerator.ExtractIdAlphabeticComponents(id));

        Assert.Equal("id", exception.ParamName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("1z9")]
    [InlineData("1Z 9")]
    [InlineData("ZZZZZZZZZZZZZZ")]
    [InlineData("3W5E11264SGSG")]
    public void ExtractIdAlphanumericComponents_InvalidId_ThrowsArgumentException(string id)
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => IdGenerator.ExtractIdAlphanumericComponents(id));

        Assert.Equal("id", exception.ParamName);
    }

    [Fact]
    public void ExtractIdAlphabeticComponents_NullId_ThrowsArgumentNullException()
        // Arrange & Act & Assert
        => _ = Assert.Throws<ArgumentNullException>(() => IdGenerator.ExtractIdAlphabeticComponents(null!));

    [Fact]
    public void ExtractIdAlphanumericComponents_NullId_ThrowsArgumentNullException()
        // Arrange & Act & Assert
        => _ = Assert.Throws<ArgumentNullException>(() => IdGenerator.ExtractIdAlphanumericComponents(null!));

    [Theory]
    [InlineData("BPNHEBKDMGLCQ")]
    [InlineData("HLHXCZMXSYUMQP")]
    public void ExtractIdAlphabeticComponents_DocumentedAndMaximumIds_DoNotThrow(string id)
    {
        // Arrange & Act
        var exception = Record.Exception(() => IdGenerator.ExtractIdAlphabeticComponents(id));

        // Assert
        Assert.Null(exception);
    }

    [Theory]
    [InlineData("1Z9DHPKW0S")]
    [InlineData("3W5E11264SGSF")]
    public void ExtractIdAlphanumericComponents_DocumentedAndMaximumIds_DoNotThrow(string id)
    {
        // Arrange & Act
        var exception = Record.Exception(() => IdGenerator.ExtractIdAlphanumericComponents(id));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void NextId_ClockMovedBackwards_ThrowsInvalidOperationException()
    {
        // Arrange
        var idGenerator = new IdGenerator(1, 1);
        var lastTimestamp = typeof(IdGenerator).GetField("_lastTimestamp", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

        Assert.NotNull(lastTimestamp);
        lastTimestamp.SetValue(idGenerator, DateTimeOffset.UtcNow.AddDays(1).ToUnixTimeMilliseconds());

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => idGenerator.NextId());

        Assert.Contains("Clock moved backwards", exception.Message);
    }

    #endregion
}
