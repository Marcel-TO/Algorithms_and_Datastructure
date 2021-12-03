namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;
    using System.Text;

    public class PutCommand : BaseCommand
    {
        public PutCommand(BefungeProgram program) : base("p", "put", program)
        {
        }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute(BefungeProgram program, ILogger logger)
        {
            int y = program.Stack.Pop();
            int x = program.Stack.Pop();
            int value = program.Stack.Pop();
            program.ValueList.RemoveRange(program.ValueList.Count - 3, 3);

            if (y > program.Content.Length)
            {
                throw new ArgumentOutOfRangeException($"The {y} position is out of range.");
            }
            else if (x > program.Content[y].Length)
            {
                throw new ArgumentOutOfRangeException($"The {x} position is out of range.");
            }

            char[] lineChars = program.Content[y].ToCharArray();
            lineChars[x] = Convert.ToChar(value.ToString());
            program.Content[y] = new string(lineChars);

            logger.ShowProgramContent(program.Content, program.Position, program.ValueList, program.Output);
        }
    }
}
