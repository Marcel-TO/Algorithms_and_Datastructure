namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public class ModuloCommand : BaseCommand
    {
        public ModuloCommand(BefungeProgram program) : base("%", "modulo", program)
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


            int res = value1 % value2;
            program.StackPush(res);
        }
    }
}
