namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;

using System;

using Xunit;

public sealed class Handle
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NullQuery_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidQuery_ReturnsReader()
    {
        var result = Target(Mock.Of<IGetBinaryStateReaderQuery>());

        Assert.Same(Fixture.StateReaderMock.Object, result);
    }

    private IBinaryStateReader Target(
        IGetBinaryStateReaderQuery query)
    {
        return Fixture.Sut.Handle(query);
    }
}
