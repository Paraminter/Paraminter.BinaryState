namespace Paraminter.BinaryState.Models;

/// <inheritdoc cref="IUnresettableBinaryStateAccessor"/>
public sealed class UnresettableBinaryStateAccessor
    : IUnresettableBinaryStateAccessor
{
    private readonly IBinaryStateReader Reader;
    private readonly IBinaryStateSetter Setter;

    /// <summary>Instantiates an accessor of an unresettable binary state.</summary>
    public UnresettableBinaryStateAccessor()
    {
        var state = new BinaryState();

        Reader = new BinaryStateReader(state);
        Setter = new BinaryStateSetter(state);
    }

    IBinaryStateReader IUnresettableBinaryStateAccessor.Reader => Reader;
    IBinaryStateSetter IUnresettableBinaryStateAccessor.Setter => Setter;

    private sealed class BinaryState
    {
        public bool IsSet { get; set; }
    }

    private sealed class BinaryStateReader
        : IBinaryStateReader
    {
        private readonly BinaryState State;

        public BinaryStateReader(
            BinaryState state)
        {
            State = state;
        }

        bool IBinaryStateReader.IsSet => State.IsSet;
    }

    private sealed class BinaryStateSetter
        : IBinaryStateSetter
    {
        private readonly BinaryState State;

        public BinaryStateSetter(
            BinaryState state)
        {
            State = state;
        }

        void IBinaryStateSetter.Set()
        {
            State.IsSet = true;
        }
    }
}
