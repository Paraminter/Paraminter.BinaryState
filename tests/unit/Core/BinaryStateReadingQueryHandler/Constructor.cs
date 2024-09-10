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
        var result = Record.Exception(() => Target<IQuery>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsProvider()
    {
        var result = Target<IQuery>(Mock.Of<IQueryHandler<IIsBinaryStateSetQuery, bool>>());

        Assert.NotNull(result);
    }

    private static BinaryStateReadingQueryHandler<TQuery> Target<TQuery>(
        IQueryHandler<IIsBinaryStateSetQuery, bool> stateReader)
        where TQuery : IQuery
    {
        return new BinaryStateReadingQueryHandler<TQuery>(stateReader);
    }
}
