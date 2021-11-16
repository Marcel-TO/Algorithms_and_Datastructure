namespace SplayTree.Interfaces
{
    using System;
    using SplayTree.KeyboardWatcher;

    public interface IKeyboardWatcher
    {
        public event EventHandler<KeyboardWatcherKeyPressedEventArgs> KeyPressed;

        void Start();
    }
}
