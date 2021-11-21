namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public class PutCommand : BaseCommand
    {
        public PutCommand(BefungeProgram program) : base("p", "put", program)
        {
        }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute(BefungeProgram program)
        {
            int y = program.Stack.Pop();
            int x = program.Stack.Pop();
            int value = program.Stack.Pop();
            program.ValueList.RemoveRange(program.ValueList.Count - 3, 3);

            //?
        }
    }
}
