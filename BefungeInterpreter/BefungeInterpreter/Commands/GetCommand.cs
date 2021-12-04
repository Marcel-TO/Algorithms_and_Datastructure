namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;
    using System.Text;

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

            // Checks if character is a number.
            if (isNumber)
            {
                program.StackPush(number);
            }

            // If its not a number converts the ascii value of the character and pushes.
            byte[] byteValue = Encoding.ASCII.GetBytes(new char[] { program.Content[y][x] });
            program.StackPush(byteValue[0]);
        }
    }
}
