﻿namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Queries;
using Paraminter.Cqs;

internal interface IFixture<in TQuery>
    where TQuery : IQuery
{
    public abstract IQueryHandler<TQuery, bool> Sut { get; }

    public abstract Mock<IQueryHandler<IIsBinaryStateSetQuery, bool>> StateReaderMock { get; }
}
