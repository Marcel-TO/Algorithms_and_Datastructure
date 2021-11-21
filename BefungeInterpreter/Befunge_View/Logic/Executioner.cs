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
            command.Execute(command.Program);
        }

        public void Visit(BridgeCommand command)
        {
            command.Execute(command.Program);
        }

        public void Visit(DivideCommand command)
        {
            command.Execute(command.Program);
        }

        public void Visit(DownCommand command)
        {
            command.Execute(command.Program);
        }

        public void Visit(DuplicationCommand command)
        {
            command.Execute(command.Program);
        }

        public void Visit(EndCommand command)
        {
            command.Execute(command.Program);
        }

        public void Visit(GetCommand command)
        {
            command.Execute(command.Program);
        }

        public void Visit(GreaterCommand command)
        {
            command.Execute(command.Program);
        }

        public void Visit(IfCommand_H command)
        {
            command.Execute(command.Program);
        }

        public void Visit(IfCommand_V command)
        {
            command.Execute(command.Program);
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
            command.Execute(command.Program);
        }

        public void Visit(ModuloCommand command)
        {
            command.Execute(command.Program);
        }

        public void Visit(MultiplyCommand command)
        {
            command.Execute(command.Program);
        }

        public void Visit(NotCommand command)
        {
            command.Execute(command.Program);
        }

        public void Visit(OutCommand_Char command)
        {
            command.Execute(command.Program);
        }

        public void Visit(OutCommand_Int command)
        {
            command.Execute(command.Program);
        }

        public void Visit(PopCommand command)
        {
            command.Execute(command.Program);
        }

        public void Visit(PutCommand command)
        {
            throw new NotImplementedException();
        }

        public void Visit(RandomCommand command)
        {
            command.Execute(command.Program);
        }

        public void Visit(RightCommand command)
        {
            command.Execute(command.Program);
        }

        public void Visit(StringCommand command)
        {
            command.Execute(command.Program);
        }

        public void Visit(SubtractCommand command)
        {
            command.Execute(command.Program);
        }

        public void Visit(SwapCommand command)
        {
            command.Execute(command.Program);
        }

        public void Visit(UpCommand command)
        {
            command.Execute(command.Program);
        }
    }
}
