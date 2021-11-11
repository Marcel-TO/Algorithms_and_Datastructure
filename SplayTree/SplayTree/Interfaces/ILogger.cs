namespace SplayTree.Interfaces
{
    using SplayTree.Commands;
    using System;

    public interface ILogger : ICommandVisitor 
    {
        void WelcomeMessage();

        void ShowCommands(BaseCommand[] commands);

        void ShowCursor(int index, int lengthOfCommandList);

        void Message(string message);

        void Continue();

        void Clear();

        int GetValueFromUser();

        int ChooseTraverseOrder();
    }
}
