namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs.Handlers;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullStateReaderProvider_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsProvider()
    {
        var result = Target(Mock.Of<IQueryHandler<IGetBinaryStateReaderQuery, IBinaryStateReader>>());

        Assert.NotNull(result);
    }

    private static BinaryStateReader Target(
        IQueryHandler<IGetBinaryStateReaderQuery, IBinaryStateReader> stateReaderProvider)
    {
        return new BinaryStateReader(stateReaderProvider);
    }
}
