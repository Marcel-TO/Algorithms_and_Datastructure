namespace BefungeInterpreter.Execptions
{
    using System;

    public class BefungeProgramNotPossible : Exception
    {
        public BefungeProgramNotPossible(string message) : base(message)
        {
        }
    }
}
