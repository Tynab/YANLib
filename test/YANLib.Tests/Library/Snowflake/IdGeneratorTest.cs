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
}
