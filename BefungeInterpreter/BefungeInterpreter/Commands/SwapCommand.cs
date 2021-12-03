namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public class SwapCommand : BaseCommand
    {
        public SwapCommand(BefungeProgram program) : base("\\", "swap", program)
        {
        }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute(BefungeProgram program)
        {
            int value2 = program.StackPop();
            int value1 = program.StackPop();

            program.StackPush(value2);
            program.StackPush(value1);
        }
    }
}
