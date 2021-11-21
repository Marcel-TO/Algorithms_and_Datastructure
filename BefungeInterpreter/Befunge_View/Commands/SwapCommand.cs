namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public class SwapCommand : BaseCommand
    {
        public SwapCommand(BefungeProgram program) : base("\\", "swap", program)
        {
        }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute(BefungeProgram program)
        {
            int value2 = program.Stack.Pop();
            int value1 = program.Stack.Pop();
            program.ValueList.RemoveAt(program.ValueList.Count - 1);
            program.ValueList.RemoveAt(program.ValueList.Count - 1);

            program.Stack.Push(value2);
            program.ValueList.Add(value2);
            program.Stack.Push(value1);
            program.ValueList.Add(value1);
        }
    }
}
