namespace Paraminter.BinaryState;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs;

using System;

/// <summary>Provides a reader of a binary state.</summary>
public sealed class BinaryStateReaderProvider
    : IQueryHandler<IGetBinaryStateReaderQuery, IBinaryStateReader>
{
    private readonly IBinaryStateReader StateReader;

    /// <summary>Instantiates a provider of a reader of a binary state.</summary>
    /// <param name="stateReader">The reader of the binary state.</param>
    public BinaryStateReaderProvider(
        IBinaryStateReader stateReader)
    {
        StateReader = stateReader ?? throw new ArgumentNullException(nameof(stateReader));
    }

    IBinaryStateReader IQueryHandler<IGetBinaryStateReaderQuery, IBinaryStateReader>.Handle(
        IGetBinaryStateReaderQuery query)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        return StateReader;
    }
}
