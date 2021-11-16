namespace SplayTree.KeyboardWatcher
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// This Class holds the KeyboardWatcher Data.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class KeyboardWatcherKeyPressedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the KeyboardWatcherKeyPressedEventArgs class.
        /// </summary>
        /// <param name="key"> The pressed Key.</param>
        public KeyboardWatcherKeyPressedEventArgs(ConsoleKey key)
        {
            this.Key = key;
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value> The pressed key.</value>
        public ConsoleKey Key
        {
            get;
            private set;
        }
    }
}
