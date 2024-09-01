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
    public void ValidQuery_ReturnsSetter()
    {
        var stateSetter = Mock.Of<IBinaryStateSetter>();

        Mock<IBinaryState> stateMock = new();

        stateMock.Setup(static (state) => state.Setter).Returns(stateSetter);

        Fixture.StateProviderMock.Setup(static (provider) => provider.Handle(It.IsAny<IGetBinaryStateQuery>())).Returns(stateMock.Object);

        var result = Target(Mock.Of<IGetBinaryStateSetterQuery>());

        Assert.Same(stateSetter, result);
    }

    private IBinaryStateSetter Target(
        IGetBinaryStateSetterQuery query)
    {
        return Fixture.Sut.Handle(query);
    }
}
