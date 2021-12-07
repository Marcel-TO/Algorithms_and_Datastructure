namespace BefungeInterpreter_UnitTests.TestInstances
{
    using System;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.KeyboardWatcher;

    public class KeyboardWatcherReplacement : IKeyboardWatcher
    {
        public event EventHandler<KeyboardWatcherKeyPressedEventArgs> KeyPressed;

        public void Start()
        {
            return;
        }
    }
}