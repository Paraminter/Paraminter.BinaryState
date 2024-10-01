namespace Paraminter.BinaryState.Models;

/// <inheritdoc cref="IResettableBinaryStateAccessor"/>
public sealed class ResettableBinaryStateAccessor
    : IResettableBinaryStateAccessor
{
    private readonly IBinaryStateReader Reader;
    private readonly IBinaryStateSetter Setter;
    private readonly IBinaryStateResetter Resetter;

    /// <summary>Instantiates an accessor of a resettable binary state.</summary>
    public ResettableBinaryStateAccessor()
    {
        var state = new BinaryState();

        Reader = new BinaryStateReader(state);
        Setter = new BinaryStateSetter(state);
        Resetter = new BinaryStateResetter(state);
    }

    IBinaryStateReader IResettableBinaryStateAccessor.Reader => Reader;
    IBinaryStateSetter IResettableBinaryStateAccessor.Setter => Setter;
    IBinaryStateResetter IResettableBinaryStateAccessor.Resetter => Resetter;

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

    private sealed class BinaryStateResetter
        : IBinaryStateResetter
    {
        private readonly BinaryState State;

        public BinaryStateResetter(
            BinaryState state)
        {
            State = state;
        }

        void IBinaryStateResetter.Reset()
        {
            State.IsSet = false;
        }
    }
}
