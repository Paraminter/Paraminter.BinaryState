namespace Paraminter.BinaryState.Models;

/// <inheritdoc cref="IUnresettableBinaryStateAccessor"/>
public sealed class UnresettableBinaryStateAccessor
    : IUnresettableBinaryStateAccessor
{
    private bool IsSet;

    /// <summary>Instantiates an accessor of an unresettable binary state.</summary>
    public UnresettableBinaryStateAccessor() { }

    bool IBinaryStateReader.IsSet => IsSet;

    void IBinaryStateSetter.Set()
    {
        IsSet = true;
    }
}
