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
            int y = program.StackPop();
            int x = program.StackPop();

            bool isNumber = int.TryParse(program.Content[y][x].ToString(), out int number);

            if (isNumber)
            {
                program.StackPush(number);
            }
        }
    }
}
