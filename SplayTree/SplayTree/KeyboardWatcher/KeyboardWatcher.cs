namespace SplayTree.KeyboardWatcher
{
    using System;

    public class KeyboardWatcher
    {
        public event EventHandler<KeyboardWatcherKeyPressedEventArgs> KeyPressed;

        public void Start()
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);
            this.FireKeyPressed(cki);
        }

        private void FireKeyPressed(ConsoleKeyInfo cki)
        {
            this.KeyPressed?.Invoke(this, new KeyboardWatcherKeyPressedEventArgs(cki));
        }
    }
}
