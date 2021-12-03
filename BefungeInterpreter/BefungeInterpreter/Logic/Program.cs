namespace BefungeInterpreter.Logic
{
    using System;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.KeyboardWatcher;

    public class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            IKeyboardWatcher keyboardWatcher = new KeyboardWatcher();

            ApplicationLogic logic = new ApplicationLogic(logger, keyboardWatcher);
            logic.Start();
        }
    }
}
