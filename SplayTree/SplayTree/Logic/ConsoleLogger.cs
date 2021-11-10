namespace SplayTree.Logic
{
    using System;
    using SplayTree.Commands;
    using SplayTree.Interfaces;

    public class ConsoleLogger : ILogger
    {
        private static int seperatePositiionX = 4;

        private static int startCommandListY = 4;

        public ConsoleLogger()
        {
            #pragma warning disable CA1416
            Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight / 2);
            Console.CursorVisible = false;
        }

        public void Visit(InsertCommand command)
        {
            Console.Clear();

            Console.WriteLine($"Executed Command: {command.Name} command");
            Console.WriteLine(string.Empty);
        }

        public void Visit(RemoveCommand command)
        {
            Console.Clear();

            Console.WriteLine($"Executed Command: {command.Name} command");
            Console.WriteLine(string.Empty);
        }

        public void Visit(ClearCommand command)
        {
            Console.Clear();

            Console.WriteLine($"Executed Command: {command.Name} command");
            Console.WriteLine(string.Empty);
        }

        public void Visit(CountCommand command)
        {
            Console.Clear();

            Console.WriteLine($"Executed Command: {command.Name} command");
            Console.WriteLine(string.Empty);
        }

        public void Visit(CountSpecificCommand command)
        {
            Console.Clear();

            Console.WriteLine($"Executed Command: {command.Name} command");
            Console.WriteLine(string.Empty);
        }

        public void Visit(MinCommand command)
        {
             Console.Clear();

            Console.WriteLine($"Executed Command: {command.Name} command");
            Console.WriteLine(string.Empty);
        }

        public void Visit(MaxCommand command)
        {
             Console.Clear();

            Console.WriteLine($"Executed Command: {command.Name} command");
            Console.WriteLine(string.Empty);
        }

        public void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the amazing Splay-Tree algortihm showcase.");
            Console.WriteLine(string.Empty);
        }

        public void ShowCommands(BaseCommand[] commands)
        {
            this.Borders("Supported commands for the splay tree implementation.", commands);

            int xPos = seperatePositiionX;
            int yPos = startCommandListY;

            for (int i = 0; i < commands.Length; i++)
            {
                if (xPos < Console.WindowWidth && yPos < Console.WindowHeight)
                {
                    Console.SetCursorPosition(xPos, yPos++);
                    Console.Write($"| {commands[i].Name}");
                }
            }
        }

        public void ShowCursor(int index, int lengthOfCommandList)
        {
            int xPos = 1;
            int yPos = startCommandListY + index;

            if (xPos < Console.WindowWidth && yPos < Console.WindowHeight)
            {
                // Current Arrow position.
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("->");

                // Clears console above arrow.
                Console.SetCursorPosition(xPos, yPos - 1);
                Console.Write("  ");

                // Clears console under arrow.
                Console.SetCursorPosition(xPos, yPos + 1);
                Console.Write("  ");

                if (yPos == startCommandListY)
                {
                    // Current Arrow position.
                    Console.SetCursorPosition(xPos, startCommandListY + lengthOfCommandList);
                    Console.Write("  ");
                }

                if (yPos == startCommandListY + lengthOfCommandList)
                {
                    // Current Arrow position.
                    Console.SetCursorPosition(xPos, startCommandListY);
                    Console.Write("  ");
                }
            }
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public void Continue()
        {
            Console.WriteLine("Please press any key to continue.");
            Console.ReadKey(true);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public int GetValueFromUser()
        {
            Console.WriteLine("Please enter a value.");

            while (true)
            {
                int number;

                bool isNumber = int.TryParse(Console.ReadLine(), out number);

                if (isNumber)
                {
                    return number;
                }

                Console.WriteLine("This is not a number");
            }
        }

        private void Borders(string message, BaseCommand[] commands)
        {
            int longestName = message.Length;

            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i].Name.Length + seperatePositiionX > longestName)
                {
                    longestName = commands[i].Name.Length;
                }
            }

            // Top Border
            for (int i = 0; i < seperatePositiionX + longestName; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.WriteLine("-");
            }

            // Topic
            Console.SetCursorPosition(1, 1);
            Console.WriteLine(message);

            // Topic Border
            for (int i = 0; i < seperatePositiionX + longestName; i++)
            {
                Console.SetCursorPosition(i, 2);
                Console.WriteLine("-");
            }

            // Left Border
            for (int i = 1; i < commands.Length + 5; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine("|");
            }

            // Bottom Border
            for (int i = 0; i < seperatePositiionX + longestName; i++)
            {
                Console.SetCursorPosition(i, commands.Length + 5);
                Console.WriteLine("-");
            }

            // Right Border
            for (int i = 1; i < commands.Length + 5; i++)
            {
                Console.SetCursorPosition(seperatePositiionX + longestName, i);
                Console.WriteLine("|");
            }
        }
    }
}
