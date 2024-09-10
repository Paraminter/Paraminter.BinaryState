namespace Paraminter.BinaryState;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs;

using System;

/// <summary>Provides a setter of a binary state.</summary>
public sealed class BinaryStateSetterProvider
    : IQueryHandler<IGetBinaryStateSetterQuery, IBinaryStateSetter>
{
    private readonly IBinaryStateSetter StateSetter;

    /// <summary>Instantiates a provider of a setter of a binary state.</summary>
    /// <param name="stateSetter">Sets the binary state.</param>
    public BinaryStateSetterProvider(
        IBinaryStateSetter stateSetter)
    {
        StateSetter = stateSetter ?? throw new ArgumentNullException(nameof(stateSetter));
    }

    IBinaryStateSetter IQueryHandler<IGetBinaryStateSetterQuery, IBinaryStateSetter>.Handle(
        IGetBinaryStateSetterQuery query)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        return StateSetter;
    }
}
