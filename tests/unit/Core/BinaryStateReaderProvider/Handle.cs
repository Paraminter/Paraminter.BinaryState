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
        var stateReader = Mock.Of<IBinaryStateReader>();

        Mock<IBinaryState> stateMock = new();

        stateMock.Setup(static (state) => state.Reader).Returns(stateReader);

        Fixture.StateProviderMock.Setup(static (provider) => provider.Handle(It.IsAny<IGetBinaryStateQuery>())).Returns(stateMock.Object);

        var result = Target(Mock.Of<IGetBinaryStateReaderQuery>());

        Assert.Same(stateReader, result);
    }

    private IBinaryStateReader Target(
        IGetBinaryStateReaderQuery query)
    {
        return Fixture.Sut.Handle(query);
    }
}
