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
    public void Set_ReturnsTrue() => ReturnsValue(true);

    [Fact]
    public void NotSet_ReturnsFalse() => ReturnsValue(false);

    private bool Target(
        IIsBinaryStateSetQuery query)
    {
        return Fixture.Sut.Handle(query);
    }

    private void ReturnsValue(bool expected)
    {
        Mock<IBinaryStateReader> stateReaderMock = new();

        stateReaderMock.Setup(static (reader) => reader.IsSet).Returns(expected);

        Fixture.StateReaderProviderMock.Setup(static (provider) => provider.Handle(It.IsAny<IGetBinaryStateReaderQuery>())).Returns(stateReaderMock.Object);

        var result = Target(Mock.Of<IIsBinaryStateSetQuery>());

        Assert.Equal(expected, result);
    }
}
