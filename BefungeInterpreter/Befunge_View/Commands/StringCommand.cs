namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public class StringCommand : BaseCommand
    {
        public StringCommand(BefungeProgram program) : base("\"", "string", program)
        {
        }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute(BefungeProgram program)
        {
            if (program.IsStringFormat)
            {
                program.IsStringFormat = false;
                return;
            }

            program.IsStringFormat = true;
        }
    }
}
