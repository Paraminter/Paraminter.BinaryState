namespace Paraminter.BinaryState;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs;

using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>Reads whether a binary state is set.</summary>
public sealed class BinaryStateReader
    : IQueryHandler<IIsBinaryStateSetQuery, bool>
{
    private readonly IBinaryStateReader Model;

    /// <summary>Instantiates a reader of whether a binary state is set.</summary>
    /// <param name="model">The model-component reading the binary state.</param>
    public BinaryStateReader(
        IBinaryStateReader model)
    {
        Model = model ?? throw new ArgumentNullException(nameof(model));
    }

    async Task<bool> IQueryHandler<IIsBinaryStateSetQuery, bool>.Handle(
        IIsBinaryStateSetQuery query,
        CancellationToken cancellationToken)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        return await Task.FromResult(Model.IsSet);
    }
}
