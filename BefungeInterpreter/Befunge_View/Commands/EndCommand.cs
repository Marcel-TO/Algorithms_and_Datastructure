namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public class EndCommand : BaseCommand
    {
        public EndCommand(BefungeProgram program) : base("@", "end", program)
        {
        }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute(BefungeProgram program)
        {
            program.IsInterpreted = true;
        }
    }
}
