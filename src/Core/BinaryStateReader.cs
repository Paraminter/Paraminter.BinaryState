namespace Paraminter.BinaryState;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs.Handlers;

using System;

/// <summary>Reads whether a binary state is set.</summary>
public sealed class BinaryStateReader
    : IQueryHandler<IIsBinaryStateSetQuery, bool>
{
    private readonly IQueryHandler<IGetBinaryStateReaderQuery, IBinaryStateReader> StateReaderProvider;

    /// <summary>Instantiates a reader of whether a binary state is set.</summary>
    /// <param name="stateReaderProvider">Provides a reader of the binary state.</param>
    public BinaryStateReader(
        IQueryHandler<IGetBinaryStateReaderQuery, IBinaryStateReader> stateReaderProvider)
    {
        StateReaderProvider = stateReaderProvider ?? throw new ArgumentNullException(nameof(stateReaderProvider));
    }

    bool IQueryHandler<IIsBinaryStateSetQuery, bool>.Handle(
        IIsBinaryStateSetQuery query)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        var stateReader = StateReaderProvider.Handle(GetBinaryStateReaderQuery.Instance);

        return stateReader.IsSet;
    }
}
