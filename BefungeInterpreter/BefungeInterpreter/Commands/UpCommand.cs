namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public class UpCommand : BaseCommand
    {
        public UpCommand(BefungeProgram program) : base("^", "up", program)
        {
        }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute(BefungeProgram program)
        {
            program.Direction = Direction.Up;
        }
    }
}
