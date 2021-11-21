namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public class IfCommand_V : BaseCommand
    {
        public IfCommand_V(BefungeProgram program) : base("|", "if_vertical", program)
        {
        }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute(BefungeProgram program)
        {
            int boolValue = program.Stack.Pop();

            if (boolValue == 1)
            {
                program.Direction = Direction.Up;
                return;
            }

            program.Direction = Direction.Down;
        }
    }
}
