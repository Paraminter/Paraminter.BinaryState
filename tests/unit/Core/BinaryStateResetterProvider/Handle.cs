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
    public void ValidQuery_ReturnsResetter()
    {
        var stateResetter = Mock.Of<IBinaryStateResetter>();

        Mock<IBinaryState> stateMock = new();

        stateMock.Setup(static (state) => state.Resetter).Returns(stateResetter);

        Fixture.StateProviderMock.Setup(static (provider) => provider.Handle(It.IsAny<IGetBinaryStateQuery>())).Returns(stateMock.Object);

        var result = Target(Mock.Of<IGetBinaryStateResetterQuery>());

        Assert.Same(stateResetter, result);
    }

    private IBinaryStateResetter Target(
        IGetBinaryStateResetterQuery query)
    {
        return Fixture.Sut.Handle(query);
    }
}
