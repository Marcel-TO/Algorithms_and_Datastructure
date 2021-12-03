namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public class NotCommand : BaseCommand
    {
        public NotCommand(BefungeProgram program) : base("!", "not", program)
        {
        }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute(BefungeProgram program)
        {
            int value = program.StackPop();

            if (value != 0)
            {
                program.StackPush(0);
                return;
            }

            program.StackPush(1);
            return;
        }
    }
}
