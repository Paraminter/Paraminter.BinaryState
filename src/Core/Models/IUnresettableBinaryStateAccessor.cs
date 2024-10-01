namespace Paraminter.BinaryState.Models;

/// <summary>Provides access to an unresettable binary state.</summary>
public interface IUnresettableBinaryStateAccessor
{
    /// <summary>Reads the binary state.</summary>
    public abstract IBinaryStateReader Reader { get; }

    /// <summary>Sets the binary state.</summary>
    public abstract IBinaryStateSetter Setter { get; }
}
