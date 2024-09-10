namespace Paraminter.BinaryState.Models;

/// <summary>Provides access to a resettable binary state.</summary>
public interface IResettableBinaryStateAccessor
    : IBinaryStateReader,
    IBinaryStateSetter,
    IBinaryStateResetter
{ }
