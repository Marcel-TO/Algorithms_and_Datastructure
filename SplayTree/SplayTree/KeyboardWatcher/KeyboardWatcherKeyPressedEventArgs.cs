namespace SplayTree.KeyboardWatcher
{
    using System;

    /// <summary>
    /// This Class holds the KeyboardWatcher Data.
    /// </summary>
    public class KeyboardWatcherKeyPressedEventArgs : EventArgs
    {
        /// <summary>
        /// This Class holds the Person Data.
        /// </summary>
        private ConsoleKeyInfo cki;

        /// <summary>
        /// Initializes a new instance of the KeyboardWatcherKeyPressedEventArgs class.
        /// </summary>
        /// <param name="cki"> The pressed Key.</param>
        public KeyboardWatcherKeyPressedEventArgs(ConsoleKeyInfo cki)
        {
            this.cki = cki;
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value> The pressed key.</value>
        public ConsoleKey Key
        {
            get
            {
                return this.cki.Key;
            }
        }

        /// <summary>
        /// Gets the key character.
        /// </summary>
        /// <value> The pressed key character.</value>
        public char KeyChar
        {
            get
            {
                return this.cki.KeyChar;
            }
        }

        /// <summary>
        /// Gets the modifiers.
        /// </summary>
        /// <value> The pressed key modifiers.</value>
        public ConsoleModifiers Modifiers
        {
            get
            {
                return this.cki.Modifiers;
            }
        }
    }
}
