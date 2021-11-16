namespace SplayTree.KeyboardWatcher
{
    using SplayTree.Interfaces;
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class KeyboardWatcher : IKeyboardWatcher
    {
        public event EventHandler<KeyboardWatcherKeyPressedEventArgs> KeyPressed;

        public void Start()
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);
            this.FireKeyPressed(cki.Key);
        }

        private void FireKeyPressed(ConsoleKey key)
        {
            this.KeyPressed?.Invoke(this, new KeyboardWatcherKeyPressedEventArgs(key));
        }
    }
}
