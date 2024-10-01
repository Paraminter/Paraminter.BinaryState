namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Queries;
using Paraminter.Cqs;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullStateReader_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<IQuery, object>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsHandler()
    {
        var result = Target<IQuery, object>(Mock.Of<IQueryHandler<IIsBinaryStateSetQuery, object>>());

        Assert.NotNull(result);
    }

    private static BinaryStateReadingQueryHandler<TQuery, TResponse> Target<TQuery, TResponse>(
        IQueryHandler<IIsBinaryStateSetQuery, TResponse> stateReader)
        where TQuery : IQuery
    {
        return new BinaryStateReadingQueryHandler<TQuery, TResponse>(stateReader);
    }
}
