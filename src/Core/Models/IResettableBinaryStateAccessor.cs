namespace Paraminter.BinaryState.Models;

/// <summary>Provides access to a resettable binary state.</summary>
public interface IResettableBinaryStateAccessor
{
    /// <summary>Reads the binary state.</summary>
    public abstract IBinaryStateReader Reader { get; }

    /// <summary>Sets the binary state.</summary>
    public abstract IBinaryStateSetter Setter { get; }

    /// <summary>Resets the binary state.</summary>
    public abstract IBinaryStateResetter Resetter { get; }
}
