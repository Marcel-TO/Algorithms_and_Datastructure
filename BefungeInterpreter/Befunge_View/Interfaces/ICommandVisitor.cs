namespace BefungeInterpreter.Interfaces
{
    using System;
    using BefungeInterpreter.Commands;

    public interface ICommandVisitor
    {
        void Visit(AddCommand command);

        void Visit(BridgeCommand command);

        void Visit(DivideCommand command);

        void Visit(DownCommand command);
        
        void Visit(DuplicationCommand command);

        void Visit(EndCommand command);

        void Visit(GetCommand command);

        void Visit(GreaterCommand command);

        void Visit(IfCommand_H command);

        void Visit(IfCommand_V command);

        void Visit(InputCommand_Char command);

        void Visit(InputCommand_Int command);

        void Visit(LeftCommand command);

        void Visit(ModuloCommand command);

        void Visit(MultiplyCommand command);

        void Visit(NotCommand command);

        void Visit(OutCommand_Char command);

        void Visit(OutCommand_Int command);

        void Visit(PopCommand command);

        void Visit(PutCommand command);

        void Visit(RandomCommand command);

        void Visit(RightCommand command);

        void Visit(StringCommand command);

        void Visit(SubtractCommand command);

        void Visit(SwapCommand command);

        void Visit(UpCommand command);
    }
}
