namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public class IfCommand_H : BaseCommand
    {
        public IfCommand_H(BefungeProgram program) : base("_", "if_horizontal", program)
        {
        }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute(BefungeProgram program)
        {
            int boolValue = program.Stack.Pop();
            program.ValueList.RemoveAt(program.ValueList.Count - 1);

            if (boolValue != 0)
            {
                program.Direction = Direction.Left;
                return;
            }

            program.Direction = Direction.Right;
        }
    }
}
