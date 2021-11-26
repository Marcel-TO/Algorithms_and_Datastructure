namespace BefungeInterpreter_UnitTests.TestInstances
{
    using System;
    using BefungeInterpreter.KeyboardWatcher;

    public class KeyboardWatcherReplacement : IKeyboardWatcher
    {
        public event EventHandler<KeyboardWatcherKeyPressedEventAr> KeyPressed;

        public void Start()
        {
            return;
        }
    }
}