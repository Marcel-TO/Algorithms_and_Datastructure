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
            int y = program.StackPop();
            int x = program.StackPop();
            int value = program.StackPop();

            if (y > program.Content.Length - 1)
            {
                throw new ArgumentOutOfRangeException($"The {y} position is out of range.");
            }
            else if (x > program.Content[y].Length)
            {
                throw new ArgumentOutOfRangeException($"The {x} position is out of range.");
            }

            var valueChars = Encoding.ASCII.GetChars(new byte[] { Convert.ToByte(value) }); // Für Ascii passt
                                                                                            // Dürfen Zahlen auch?

            char[] lineChars = program.Content[y].ToCharArray();
            lineChars[x] = valueChars[0];
            program.Content[y] = new string(lineChars);

            logger.ShowProgramContent(program.Content, program.Position, program.ValueList, program.Output);
        }
    }
}
