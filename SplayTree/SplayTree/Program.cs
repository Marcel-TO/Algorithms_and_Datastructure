namespace SplayTree
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using SplayTree.Logic;

    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            ApplicationLogic application = new ApplicationLogic(new ConsoleLogger(), new KeyboardWatcher.KeyboardWatcher());
            application.Start();
        }
    }
}
