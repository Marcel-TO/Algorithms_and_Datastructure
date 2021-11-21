namespace BefungeInterpreter.Logic
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using BefungeInterpreter.Interfaces;

    public class ConsoleLogger : ILogger
    {
        /// <summary>
        /// Represents the separator between the cursor and the commands.
        /// </summary>
        private static int separatePositiionX = 4;

        /// <summary>
        /// Represents the y start position of the command list.
        /// </summary>
        private static int startNameListY = 4;

        private int rightBorder;

        private int bottomBorder;

        public ConsoleLogger()
        {
            #pragma warning disable CA1416

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
        }

        public void Log(string message)
        {
            throw new NotImplementedException();
        }

        public void ShowBefungePrograms(string[] befungeProgramPaths)
        {
            Console.CursorVisible = false;
            this.Borders("Provided Befunge example programs.", befungeProgramPaths);

            int xPos = separatePositiionX;
            int yPos = startNameListY;

            for (int i = 0; i < befungeProgramPaths.Length; i++)
            {
                if (xPos < Console.WindowWidth && yPos < Console.WindowHeight)
                {
                    Console.SetCursorPosition(xPos, yPos++);
                    Console.Write($"| {Path.GetFileNameWithoutExtension(befungeProgramPaths[i])}");
                }
            }
        }

        public void ShowCursor(int yPosition, int lengthOfBefungePrograms)
        {
            int xPos = 1;
            int yPos = startNameListY + yPosition;

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

                if (yPos == startNameListY)
                {
                    // Current Arrow position.
                    Console.SetCursorPosition(xPos, startNameListY + lengthOfBefungePrograms);
                    Console.Write("  ");
                }

                if (yPos == startNameListY + lengthOfBefungePrograms)
                {
                    // Current Arrow position.
                    Console.SetCursorPosition(xPos, startNameListY);
                    Console.Write("  ");
                }
            }
        }

        public void ShowProgramContent(string[] content, Position position, List<int> values, List<string> output)
        {
            Console.CursorVisible = false;
            this.Clear();

            this.Borders("The selected befunge program.", content);

            for (int y = 0; y < content.Length; y++)
            {
                for (int x = 0; x < content[y].Length; x++)
                {
                    if (x == position.X && y == position.Y)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.SetCursorPosition(x + 1, y + startNameListY);
                        Console.Write(content[y][x]);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.SetCursorPosition(x + 1, y + startNameListY);
                        Console.Write(content[y][x]);
                    }
                }
            }

            this.MoreInformation(this.rightBorder, this.bottomBorder, values, output);
        }

        public void CursorOutOfRange()
        {
            int offset = 2;

            string message = "It appears the cursor is out of range. Please press any key to continue";

            int width = this.rightBorder + message.Length + offset + offset;
            int w = Console.WindowWidth;
            int l = Console.LargestWindowWidth;

            if (width > Console.WindowWidth && width < Console.LargestWindowWidth)
            {
                Console.SetWindowSize(width, Console.WindowHeight);
            }

            Console.SetCursorPosition(this.rightBorder + offset, 2);
            Console.WriteLine(message);

            this.Continue();
        }

        public void Finished()
        {
            int offset = 2;

            string message = "It appears the program is finished.";

            int width = this.rightBorder + message.Length + offset + offset;
            int w = Console.WindowWidth;
            int l = Console.LargestWindowWidth;

            if (width > Console.WindowWidth && width < Console.LargestWindowWidth)
            {
                Console.SetWindowSize(width, Console.WindowHeight);
            }

            Console.SetCursorPosition(this.rightBorder + offset, 2);

            for (int i = 0; i < Console.WindowWidth - this.rightBorder - offset; i++)
            {
                Console.Write(" ");
            }

            Console.SetCursorPosition(this.rightBorder + offset, 3);

            for (int i = 0; i < Console.WindowWidth - this.rightBorder - offset; i++)
            {
                Console.Write(" ");
            }

            Console.SetCursorPosition(this.rightBorder + offset, 2);
            Console.WriteLine(message);

            this.Continue();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Continue()
        {
            Console.ReadKey(true);
        }

        private void MoreInformation(int right, int bottom, List<int> values, List<string> output)
        {
            int offset = 2;

            string messageEscape = "Press Escape to go back to the befunge example program list.";
            string messageContinue = "Press any key to to step forward or press enter to skip to the end.";

            int width = right + messageContinue.Length + offset + offset;
            int w = Console.WindowWidth;
            int l = Console.LargestWindowWidth;

            if (width > Console.WindowWidth && width < Console.LargestWindowWidth)
            {
                Console.SetWindowSize(width, Console.WindowHeight);
            }

            Console.SetCursorPosition(right + offset, 2);
            Console.WriteLine(messageEscape);
            Console.SetCursorPosition(right + offset, 3);
            Console.WriteLine(messageContinue);

            int currY = this.ShowStack(values, "Current Stack", this.bottomBorder + 2);
            this.ShowOutput(output, "Output", currY + 1);
        }

        private int ShowStack(List<int> values, string Name, int y)
        {
            Console.SetCursorPosition(0, y);

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine(Name + ":");

            Console.WriteLine(string.Empty);

            for (int i = 0; i < values.Count; i++)
            {
                Console.Write(values[i].ToString() + " ");
            }

            return Console.CursorTop;
        }

        private int ShowOutput(List<string> values, string Name, int y)
        {
            Console.SetCursorPosition(0, y);

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine(Name + ":");

            Console.WriteLine(string.Empty);

            for (int i = 0; i < values.Count; i++)
            {
                Console.Write(values[i].ToString() + " ");
            }

            return Console.CursorTop;
        }

        /// <summary>
        /// Represents the visitor pattern of the clear command.
        /// </summary>
        /// <param name="message">Represents the message of the application.</param>
        /// <param name="commands">Represents the list of commands.</param>
        private void Borders(string message, string[] paths)
        {
            int longestName = message.Length;

            for (int i = 0; i < paths.Length; i++)
            {
                string name = Path.GetFileNameWithoutExtension(paths[i]);

                if (name.Length + separatePositiionX > longestName)
                {
                    longestName = name.Length;
                }
            }

            if (separatePositiionX + longestName > Console.WindowWidth)
            {
                Console.SetWindowSize(separatePositiionX + longestName + 6, paths.Length + 6);
            }

            // Top Border
            for (int i = 0; i < separatePositiionX + longestName; i++)
            {
                try
                {
                    Console.SetCursorPosition(i, 0);
                }
                catch (Exception)
                {
                    return;
                }

                Console.WriteLine("-");
            }

            // Topic
            try
            {
                Console.SetCursorPosition(1, 1);
            }
            catch (Exception)
            {
                return;
            }

            Console.WriteLine(message);

            // Topic Border
            for (int i = 0; i < separatePositiionX + longestName; i++)
            {
                try
                {
                    Console.SetCursorPosition(i, 2);
                }
                catch (Exception)
                {
                    return;
                }

                Console.WriteLine("-");
            }

            // Left Border
            for (int i = 1; i < paths.Length + 5; i++)
            {
                try
                {
                    Console.SetCursorPosition(0, i);
                }
                catch (Exception)
                {
                    return;
                }

                Console.WriteLine("|");
            }

            // Bottom Border
            for (int i = 0; i < separatePositiionX + longestName; i++)
            {
                this.bottomBorder = paths.Length + 5;

                try
                {
                    Console.SetCursorPosition(i, this.bottomBorder);
                }
                catch (Exception)
                {
                    return;
                }

                Console.WriteLine("-");
            }

            // Right Border
            for (int i = 1; i < paths.Length + 5; i++)
            {
                this.rightBorder = separatePositiionX + longestName;

                try
                {
                    Console.SetCursorPosition(this.rightBorder, i);
                }
                catch (Exception)
                {
                    return;
                }

                Console.WriteLine("|");
            }
        }
    }
}
