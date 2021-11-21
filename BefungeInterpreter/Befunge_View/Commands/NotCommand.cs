namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public class NotCommand : BaseCommand
    {
        public NotCommand(BefungeProgram program) : base("!", "not", program)
        {
        }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute(BefungeProgram program)
        {
            int value = program.Stack.Pop();
            program.ValueList.RemoveAt(program.ValueList.Count - 1);

            if (value != 0)
            {
                program.Stack.Push(0);
                program.ValueList.Add(0);
                return;
            }

            program.Stack.Push(1);
            program.ValueList.Add(1);
            return;
        }
    }
}
