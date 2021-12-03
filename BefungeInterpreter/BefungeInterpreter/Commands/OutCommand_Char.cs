namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;
    using System.Text;

    public class OutCommand_Char : BaseCommand
    {
        public OutCommand_Char(BefungeProgram program) : base(",", "output char", program)
        {
        }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute(BefungeProgram program)
        {
            int value = program.StackPop();

            byte[] byteValue = new byte[] { Convert.ToByte(value) };
            program.Output.Add(Encoding.ASCII.GetString(byteValue));
        }
    }
}
