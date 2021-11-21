namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public class GetCommand : BaseCommand
    {
        public GetCommand(BefungeProgram program) : base("g", "get", program)
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
            program.ValueList.RemoveAt(program.ValueList.Count - 1);
            program.ValueList.RemoveAt(program.ValueList.Count - 1);

            bool isNumber = int.TryParse(program.Content[y][x].ToString(), out int number);

            if (isNumber)
            {
                program.Stack.Push(number);
                program.ValueList.Add(number);
            }
        }
    }
}
