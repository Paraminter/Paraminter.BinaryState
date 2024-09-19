namespace Paraminter.BinaryState;

using Paraminter.BinaryState.Commands;
using Paraminter.BinaryState.Models;
using Paraminter.Cqs;

using System;

/// <summary>Sets a binary state.</summary>
public sealed class BinaryStateSetter
    : ICommandHandler<ISetBinaryStateCommand>
{
    private readonly IBinaryStateSetter Model;

    /// <summary>Instantiates a setter of a binary state.</summary>
    /// <param name="model">The model-component setting the binary state.</param>
    public BinaryStateSetter(
        IBinaryStateSetter model)
    {
        Model = model ?? throw new ArgumentNullException(nameof(model));
    }

    void ICommandHandler<ISetBinaryStateCommand>.Handle(
        ISetBinaryStateCommand command)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        Model.Set();
    }
}
