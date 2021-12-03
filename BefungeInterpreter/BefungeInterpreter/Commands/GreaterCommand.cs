namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public class GreaterCommand : BaseCommand
    {
        public GreaterCommand(BefungeProgram program) : base("`", "greater", program)
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

            if (value1 > value2)
            {
                program.StackPush(1);
                return;
            }

            program.StackPush(0);
        }
    }
}
