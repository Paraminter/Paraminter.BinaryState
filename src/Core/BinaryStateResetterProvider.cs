namespace Paraminter.BinaryState;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs.Handlers;

using System;

/// <summary>Provides a resetter of a binary state.</summary>
public sealed class BinaryStateResetterProvider
    : IQueryHandler<IGetBinaryStateResetterQuery, IBinaryStateResetter>
{
    private readonly IQueryHandler<IGetBinaryStateQuery, IBinaryState> StateProvider;

    /// <summary>Instantiates a provider of a resetter of a binary state.</summary>
    /// <param name="stateProvider">Provides the binary state.</param>
    public BinaryStateResetterProvider(
        IQueryHandler<IGetBinaryStateQuery, IBinaryState> stateProvider)
    {
        StateProvider = stateProvider ?? throw new ArgumentNullException(nameof(stateProvider));
    }

    IBinaryStateResetter IQueryHandler<IGetBinaryStateResetterQuery, IBinaryStateResetter>.Handle(
        IGetBinaryStateResetterQuery query)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        var state = StateProvider.Handle(GetBinaryStateQuery.Instance);

        return state.Resetter;
    }
}
