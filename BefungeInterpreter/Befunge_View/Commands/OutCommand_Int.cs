namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;
    using System.Text;

    public class OutCommand_Int : BaseCommand
    {
        public OutCommand_Int(BefungeProgram program) : base(".", "output int", program)
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

            program.Output.Add(value.ToString());
        }
    }
}
