namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;
    using System.Text;

    public class InputCommand_Char : BaseCommand
    {
        public InputCommand_Char(BefungeProgram program) : base("~", "input char", program)
        {
        }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute(BefungeProgram program, char character, ILogger logger)
        {
            byte[] byteValue = Encoding.ASCII.GetBytes(character.ToString());
            program.StackPush(byteValue[0]);

            logger.ShowProgramContent(program.Content, program.Position, program.ValueList, program.Output);
        }
    }
}
