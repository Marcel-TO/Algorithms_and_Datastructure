namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public class RightCommand : BaseCommand
    {
        public RightCommand(BefungeProgram program) : base(">", "right", program)
        {
        }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute(BefungeProgram program)
        {
            program.Direction = Direction.Right;
        }
    }
}
