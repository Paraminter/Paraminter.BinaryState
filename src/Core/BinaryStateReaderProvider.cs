namespace Paraminter.BinaryState;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs.Handlers;

using System;

/// <summary>Provides a reader of a binary state.</summary>
public sealed class BinaryStateReaderProvider
    : IQueryHandler<IGetBinaryStateReaderQuery, IBinaryStateReader>
{
    private readonly IQueryHandler<IGetBinaryStateQuery, IBinaryState> StateProvider;

    /// <summary>Instantiates a provider of a reader of a binary state.</summary>
    /// <param name="stateProvider">Provides the binary state.</param>
    public BinaryStateReaderProvider(
        IQueryHandler<IGetBinaryStateQuery, IBinaryState> stateProvider)
    {
        StateProvider = stateProvider ?? throw new ArgumentNullException(nameof(stateProvider));
    }

    IBinaryStateReader IQueryHandler<IGetBinaryStateReaderQuery, IBinaryStateReader>.Handle(
        IGetBinaryStateReaderQuery query)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        var state = StateProvider.Handle(GetBinaryStateQuery.Instance);

        return state.Reader;
    }
}
