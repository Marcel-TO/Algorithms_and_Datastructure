namespace BefungeInterpreter.Logic
{
    using System;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Interfaces;

    public class Executioner : ICommandVisitor
    {
        private ILogger logger;

        public Executioner(ILogger logger)
        {
            this.logger = logger;
        }

        public void Visit(AddCommand command)
        {
            throw new NotImplementedException();
        }

        public void Visit(BridgeCommand command)
        {
            throw new NotImplementedException();
        }

        public void Visit(DivideCommand command)
        {
            throw new NotImplementedException();
        }

        public void Visit(DownCommand command)
        {
            throw new NotImplementedException();
        }

        public void Visit(DuplicationCommand command)
        {
            throw new NotImplementedException();
        }

        public void Visit(EndCommand command)
        {
            throw new NotImplementedException();
        }

        public void Visit(GetCommand command)
        {
            throw new NotImplementedException();
        }

        public void Visit(GreaterCommand command)
        {
            throw new NotImplementedException();
        }

        public void Visit(IfCommand_H command)
        {
            throw new NotImplementedException();
        }

        public void Visit(IfCommand_V command)
        {
            throw new NotImplementedException();
        }

        public void Visit(InputCommand_Char command)
        {
            throw new NotImplementedException();
        }

        public void Visit(InputCommand_Int command)
        {
            throw new NotImplementedException();
        }

        public void Visit(LeftCommand command)
        {
            throw new NotImplementedException();
        }

        public void Visit(ModuloCommand command)
        {
            throw new NotImplementedException();
        }

        public void Visit(MultiplyCommand command)
        {
            throw new NotImplementedException();
        }

        public void Visit(NotCommand command)
        {
            throw new NotImplementedException();
        }

        public void Visit(OutCommand_Char command)
        {
            throw new NotImplementedException();
        }

        public void Visit(OutCommand_Int command)
        {
            throw new NotImplementedException();
        }

        public void Visit(PopCommand command)
        {
            throw new NotImplementedException();
        }

        public void Visit(PutCommand command)
        {
            throw new NotImplementedException();
        }

        public void Visit(RandomCommand command)
        {
            throw new NotImplementedException();
        }

        public void Visit(RightCommand command)
        {
            throw new NotImplementedException();
        }

        public void Visit(StringCommand command)
        {
            throw new NotImplementedException();
        }

        public void Visit(SubtractCommand command)
        {
            throw new NotImplementedException();
        }

        public void Visit(SwapCommand command)
        {
            throw new NotImplementedException();
        }

        public void Visit(UpCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
