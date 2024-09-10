namespace Paraminter.BinaryState.Models;

/// <inheritdoc cref="IResettableBinaryStateAccessor"/>
public sealed class ResettableBinaryStateAccessor
    : IResettableBinaryStateAccessor
{
    private bool IsSet;

    /// <summary>Instantiates an accessor of a resettable binary state.</summary>
    public ResettableBinaryStateAccessor() { }

    bool IBinaryStateReader.IsSet => IsSet;

    void IBinaryStateSetter.Set()
    {
        IsSet = true;
    }

    void IBinaryStateResetter.Reset()
    {
        IsSet = false;
    }
}
