namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public class BridgeCommand : BaseCommand
    {
        public BridgeCommand(BefungeProgram program) : base("#", "bridge", program)
        {
        }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute(BefungeProgram program, ILogger logger)
        {
            switch (program.Direction)
            {
                case Direction.Up:
                    program.Position.Y--;
                    break;
                case Direction.Right:
                    program.Position.X++;
                    break;
                case Direction.Down:
                    program.Position.Y++;
                    break;
                case Direction.Left:
                    program.Position.X--;
                    break;
            }

            logger.UpdateContent(this.Program, this.Program.ValueList, this.Program.Output);
        }
    }
}
