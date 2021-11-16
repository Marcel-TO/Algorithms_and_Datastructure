namespace UnitTest.Replacements
{
    using System;
    using SplayTree.Commands;
    using SplayTree.Interfaces;

    public class ConsoleLoggerTestInstance : ILogger
    {
        public int ChooseTraverseOrder()
        {
            return 1;
        }

        public void Clear()
        {
            return;
        }

        public void Continue()
        {
            return;
        }

        public int GetValueFromUser()
        {
            return 3;
        }

        public void Message(string message)
        {
            return;
        }

        public void ShowCommands(BaseCommand[] commands)
        {
            return;
        }

        public void ShowCursor(int index, int lengthOfCommandList)
        {
            return;
        }

        public void Visit(InsertCommand command)
        {
            return;
        }

        public void Visit(RemoveCommand command)
        {
            return;
        }

        public void Visit(ClearCommand command)
        {
            return;
        }

        public void Visit(CountCommand command)
        {
            return;
        }

        public void Visit(CountSpecificCommand command)
        {
            return;
        }

        public void Visit(MinCommand command)
        {
            return;
        }

        public void Visit(MaxCommand command)
        {
            return;
        }

        public void Visit(ContainsCommand command)
        {
            return;
        }

        public void Visit(TraverseCommand command)
        {
            return;
        }

        public void Visit(DisplayCommand command)
        {
            return;
        }

        public void WelcomeMessage()
        {
            return;
        }
    }
}
