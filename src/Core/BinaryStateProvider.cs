namespace Paraminter.BinaryState;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs.Handlers;

using System;

/// <summary>Provides a binary state.</summary>
public sealed class BinaryStateProvider
    : IQueryHandler<IGetBinaryStateQuery, IBinaryState>
{
    private readonly IBinaryState State;

    /// <summary>Instantiates a provider of a binary state.</summary>
    /// <param name="state">The binary state.</param>
    public BinaryStateProvider(
        IBinaryState state)
    {
        State = state ?? throw new ArgumentNullException(nameof(state));
    }

    IBinaryState IQueryHandler<IGetBinaryStateQuery, IBinaryState>.Handle(
        IGetBinaryStateQuery query)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        return State;
    }
}
