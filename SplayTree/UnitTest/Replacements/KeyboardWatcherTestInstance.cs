namespace UnitTest.Replacements
{
    using System;
    using SplayTree.Interfaces;
    using SplayTree.KeyboardWatcher;

    public class KeyboardWatcherTestInstance : IKeyboardWatcher
    {
        public event EventHandler<KeyboardWatcherKeyPressedEventArgs> KeyPressed;

        public void Start()
        {
            this.KeyPressed?.Invoke(this, new KeyboardWatcherKeyPressedEventArgs(ConsoleKey.UpArrow));
            this.KeyPressed?.Invoke(this, new KeyboardWatcherKeyPressedEventArgs(ConsoleKey.DownArrow));
            this.KeyPressed?.Invoke(this, new KeyboardWatcherKeyPressedEventArgs(ConsoleKey.Enter));
            this.KeyPressed?.Invoke(this, new KeyboardWatcherKeyPressedEventArgs(ConsoleKey.Escape));
        }
    }
}
