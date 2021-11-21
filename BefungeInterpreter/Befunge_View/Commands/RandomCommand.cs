namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public class RandomCommand : BaseCommand
    {
        public RandomCommand(BefungeProgram program) : base("?", "random", program)
        {
        }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute(BefungeProgram program)
        {
            Random random = new Random();
            int r = random.Next(0, 4);

            switch (r)
            {
                case 0:
                    program.Direction = Direction.Up;
                    break;
                case 1:
                    program.Direction = Direction.Right;
                    break;
                case 2:
                    program.Direction = Direction.Down;
                    break;
                case 3:
                    program.Direction = Direction.Left;
                    break;
            }
        }
    }
}
