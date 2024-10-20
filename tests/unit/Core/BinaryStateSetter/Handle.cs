namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Commands;

using System;
using System.Threading;

using Xunit;

public sealed class Handle
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NullCommand_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!, CancellationToken.None));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_Sets()
    {
        Target(Mock.Of<ISetBinaryStateCommand>(), CancellationToken.None);

        Fixture.ModelMock.Verify(static (model) => model.Set(), Times.Once);
    }

    private void Target(
        ISetBinaryStateCommand command,
        CancellationToken cancellationToken)
    {
        Fixture.Sut.Handle(command, cancellationToken);
    }
}
