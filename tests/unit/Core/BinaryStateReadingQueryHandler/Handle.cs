﻿namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Queries;
using Paraminter.Cqs;

using System;
using System.Threading;
using System.Threading.Tasks;

using Xunit;

public sealed class Handle
{
    [Fact]
    public async Task NullQuery_ThrowsArgumentNullException()
    {
        var fixture = FixtureFactory.Create<IQuery, object>();

        var result = await Record.ExceptionAsync(() => Target(fixture, null!, CancellationToken.None));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public async Task ValidQuery_ReadsState()
    {
        var expected = Mock.Of<object>();

        var fixture = FixtureFactory.Create<IQuery, object>();

        fixture.StateReaderMock.Setup(static (handler) => handler.Handle(It.IsAny<IIsBinaryStateSetQuery>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(expected));

        var result = await Target(fixture, Mock.Of<IQuery>(), CancellationToken.None);

        Assert.Same(expected, result);
    }

    private static async Task<TResponse> Target<TQuery, TResponse>(
        IFixture<TQuery, TResponse> fixture,
        TQuery query,
        CancellationToken cancellationToken)
        where TQuery : IQuery
    {
        return await fixture.Sut.Handle(query, cancellationToken);
    }
}
