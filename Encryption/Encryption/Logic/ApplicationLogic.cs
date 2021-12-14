//-----------------------------------------------------------------------
// <copyright file="ApplicationLogic.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the logic of the application.</summary>
//-----------------------------------------------------------------------
namespace Encryption.Logic
{
    using System;
    using System.Collections.Generic;
    using Encryption.EventArgs;
    using Encryption.Interfaces;

    /// <summary>
    /// Represents the logic of the application.
    /// </summary>
    public class ApplicationLogic
    {
        /// <summary>
        /// Represents the logger of the application.
        /// </summary>
        private ILogger logger;

        /// <summary>
        /// Represents the keyboard watcher for user input purpose.
        /// </summary>
        private IKeyboardWatcher keyboardWatcher;

        /// <summary>
        /// Represents the list of all cipher encryptions supported in this application.
        /// </summary>
        private List<BaseCipher> ciphers;

        /// <summary>
        /// Represents the index of the current cipher encryption.
        /// </summary>
        private int index;

        /// <summary>
        /// Represents the loop for the navigation menu.
        /// </summary>
        private bool navLoop;

        /// <summary>
        /// Represents the loop for the current selected cipher encryption.
        /// </summary>
        private bool cipherLoop;

        /// <summary>
        /// Represents the current message.
        /// </summary>
        private string currentMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationLogic"/> class.
        /// </summary>
        /// <param name="logger">The current console logger of the application.</param>
        /// <param name="watcher">The current keyboard watcher of the application.</param>
        public ApplicationLogic(ILogger logger, IKeyboardWatcher watcher)
        {
            this.Logger = logger;
            this.KeyboardWatcher = watcher;
            this.KeyboardWatcher.MenuNavigation += this.MenuNavigation;
            this.KeyboardWatcher.KeyPressed += this.KeyPressed;
            this.navLoop = true;
            this.cipherLoop = true;
            this.currentMessage = string.Empty;

            this.ciphers = new List<BaseCipher>();
            this.Ciphers.Add(new AutokeyCipher("king"));
            this.Ciphers.Add(new ChaoCipher("HXUCZVAMDSLKPEFJRIGTWOBNYQ", "PTLNBQDEOYSFAVZKGJRIHWXUMC"));
        }

        /// <summary>
        /// Gets the logger for the application.
        /// </summary>
        /// <value>The logger for the application.</value>
        public ILogger Logger
        {
            get
            {
                return this.logger;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.logger)} must not be null.");
                }

                this.logger = value;
            }
        }

        /// <summary>
        /// Gets the keyboard watcher of the application.
        /// </summary>
        /// <value>The keyboard watcher for user input.</value>
        public IKeyboardWatcher KeyboardWatcher
        {
            get
            {
                return this.keyboardWatcher;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.keyboardWatcher)} must not be null.");
                }

                this.keyboardWatcher = value;
            }
        }

        /// <summary>
        /// Gets the list of all supported encrypted ciphers.
        /// </summary>
        /// <value>The list of all ciphers supported.</value>
        public List<BaseCipher> Ciphers
        {
            get
            {
                return this.ciphers;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.ciphers)} must not be null.");
                }

                this.ciphers = value;
            }
        }

        /// <summary>
        /// Gets the index of the current command list.
        /// </summary>
        /// <value>The index of the current command list.</value>
        public int Index
        {
            get
            {
                return this.index;
            }

            private set
            {
                if (value < 0)
                {
                    this.index = this.ciphers.Count - 1;
                }
                else if (value > this.ciphers.Count - 1)
                {
                    this.index = 0;
                }
                else
                {
                    this.index = value;
                }
            }
        }

        /// <summary>
        /// Represents the method for starting the encryption application.
        /// </summary>
        public void Run()
        {
            this.Logger.ShowCiphers(this.Ciphers, this.Index);
            this.Logger.ShowCursor(this.Index, this.Ciphers.Count);

            while (this.navLoop)
            {
                this.KeyboardWatcher.StartNav();
                this.Logger.ShowCursor(this.Index, this.Ciphers.Count);
            }

            this.Logger.Clear();
        }

        /// <summary>
        /// Occurs if the user pressed a key to navigate through the menu.
        /// </summary>
        /// <param name="sender">Represents the sender of the event.</param>
        /// <param name="e">Represents the arguments of the event.</param>
        protected void MenuNavigation(object sender, KeyboardWatcherEventArgs e)
        {
            switch (e.Key)
            {
                case ConsoleKey.Escape:
                    this.navLoop = false;
                    break;
                case ConsoleKey.Enter:
                    this.ExecuteCipher(this.ciphers, this.Index);
                    break;
                case ConsoleKey.UpArrow:
                    this.Index--;
                    break;
                case ConsoleKey.DownArrow:
                    this.Index++;
                    break;
            }
        }

        /// <summary>
        /// Occurs if the user pressed a key to select the encryption options.
        /// </summary>
        /// <param name="sender">Represents the sender of the event.</param>
        /// <param name="e">Represents the arguments of the event.</param>
        protected void KeyPressed(object sender, KeyboardCipherEventArgs e)
        {
            switch (e.Key)
            {
                case ConsoleKey.Escape:
                    this.cipherLoop = false;
                    break;
                case ConsoleKey.E:
                    this.Encrypt(e.Cipher);
                    break;
                case ConsoleKey.D:
                    this.Decrypt(e.Cipher);
                    break;
            }
        }

        /// <summary>
        /// Represents a method for executing the current cipher encryption.
        /// </summary>
        /// <param name="ciphers">The list of all supported cipher encryption.</param>
        /// <param name="index">The index of the selected cipher encryption.</param>
        private void ExecuteCipher(List<BaseCipher> ciphers, int index)
        {
            while (this.cipherLoop)
            {
                this.Logger.ChooseMethod();
                this.KeyboardWatcher.StartKey(ciphers[index]);
            }

            this.Reset();
        }

        /// <summary>
        /// Represents a method for encrypting with the current cipher.
        /// </summary>
        /// <param name="cipher">The current selected cipher.</param>
        private void Encrypt(BaseCipher cipher)
        {
            this.Logger.AskUserForMessage();
            this.currentMessage = this.GetMessage();

            this.currentMessage = cipher.Encrypt(this.currentMessage);
            this.Logger.Log("The encrypted message is:");
            this.Logger.Log($"{this.currentMessage}");
            this.Logger.Continue();
            this.KeyboardWatcher.Continue();
        }

        /// <summary>
        /// Represents a method for decrypting with the current cipher.
        /// </summary>
        /// <param name="cipher">The current selected cipher.</param>
        private void Decrypt(BaseCipher cipher)
        {
            this.currentMessage = cipher.Decrypt(this.currentMessage);
            this.Logger.Log("The decrypted message is:");
            this.Logger.Log($"{this.currentMessage}");
            this.Logger.Continue();
            this.KeyboardWatcher.Continue();
        }

        /// <summary>
        /// Represents a method for resetting the loops to keep going on.
        /// </summary>
        private void Reset()
        {
            this.cipherLoop = true;
            this.Logger.ShowCiphers(this.Ciphers, this.Index);
            this.Logger.ShowCursor(this.Index, this.Ciphers.Count);
        }

        /// <summary>
        /// Represents a method for getting the too be encrypted message.
        /// </summary>
        /// <returns>The new message from user.</returns>
        private string GetMessage()
        {
            while (true)
            {
                bool isValid = true;

                string message = this.KeyboardWatcher.ReadLine();

                for (int i = 0; i < message.Length; i++)
                {
                    if (!char.IsLetter(message[i]))
                    {
                        isValid = false;
                    }
                }

                if (isValid)
                {
                    return message;
                }

                this.Logger.Log("This message is not valid. Please keep in mind there are only letters allowed.");
            }
        }
    }
}
