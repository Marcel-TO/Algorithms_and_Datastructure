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
                program.Stack.Push(0);
                program.ValueList.Add(0);
            }

            int value = program.Stack.Peek();
            program.Stack.Push(value);
            program.ValueList.Add(value);
        }
    }
}
