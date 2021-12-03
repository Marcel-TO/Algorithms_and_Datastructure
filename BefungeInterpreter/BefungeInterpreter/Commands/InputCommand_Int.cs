namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public class InputCommand_Int : BaseCommand
    {
        public InputCommand_Int(BefungeProgram program) : base("&", "input int", program)
        {
        }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute(BefungeProgram program, int number, ILogger logger)
        {
            if (number < 0 || number > 9)
            {
                throw new ArgumentNullException("The number must be between the range of 0 and 9.");
            }

            program.StackPush(number);

            logger.ShowProgramContent(program.Content, program.Position, program.ValueList, program.Output);
        }
    }
}
