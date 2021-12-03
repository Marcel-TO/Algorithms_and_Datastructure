namespace BefungeInterpreter.EventArgs
{
    using System;

    public class ExitThreadArguments
    {
        public ExitThreadArguments()
        {
            this.IsExit = false;
        }

        public bool IsExit
        {
            get;
            set;
        }
    }
}
