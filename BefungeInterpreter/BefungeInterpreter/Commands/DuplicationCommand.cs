namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public class DuplicationCommand : BaseCommand
    {
        public DuplicationCommand(BefungeProgram program) : base(":", "duplication", program)
        {
        }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute(BefungeProgram program)
        {
            if (program.Stack.Count == 0)
            {
                program.StackPush(0);
            }

            int value = program.Stack.Peek();
            program.StackPush(value);
        }
    }
}
