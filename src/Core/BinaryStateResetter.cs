﻿namespace Paraminter.BinaryState;

using Paraminter.BinaryState.Commands;
using Paraminter.BinaryState.Models;
using Paraminter.Cqs;

using System;

/// <summary>Resets a binary state.</summary>
public sealed class BinaryStateResetter
    : ICommandHandler<IResetBinaryStateCommand>
{
    private readonly IBinaryStateResetter Model;

    /// <summary>Instantiates a resetter of a binary state.</summary>
    /// <param name="model">The model-components resetting the binary state.</param>
    public BinaryStateResetter(
        IBinaryStateResetter model)
    {
        Model = model ?? throw new ArgumentNullException(nameof(model));
    }

    void ICommandHandler<IResetBinaryStateCommand>.Handle(
        IResetBinaryStateCommand command)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        Model.Reset();
    }
}
