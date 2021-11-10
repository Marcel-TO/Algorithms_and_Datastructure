namespace SplayTree
{
    using SplayTree.Logic;
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            ApplicationLogic application = new ApplicationLogic(args);
            application.Start();
        }
    }
}
