namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public class DivideCommand : BaseCommand
    {
        public DivideCommand(BefungeProgram program) : base("/", "divide", program)
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


            int res = value1 / value2;
            program.Stack.Push(res);
            program.ValueList.Add(res);
        }
    }
}
