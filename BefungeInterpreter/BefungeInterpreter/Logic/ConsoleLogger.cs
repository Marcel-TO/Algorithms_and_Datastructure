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

        private int stackDisplayX;

        private int stackDisplayY;

        private int stackCounter;

        private int outDisplayX;

        private int outDisplayY;

        private int outCounter;

        public ConsoleLogger()
        {
            #pragma warning disable CA1416

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;

            this.stackCounter = 0;
            this.outCounter = 0;
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

        public void UpdateContent(BefungeProgram program ,List<int> stackValues, List<string> output)
        {
            this.UpdateCursor(program.Content, program.Position, program.Direction);

            this.ShowStack(stackValues, this.stackDisplayX, this.stackDisplayY);
            this.ShowOutput(output, this.outDisplayX, this.outDisplayY);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Continue()
        {
            Console.ReadKey(true);
        }

        public char GetUserCharInput()
        {
            this.Clear();
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Please enter a character.");

            while (true)
            {
                char character = Console.ReadKey().KeyChar;
                
                // The range from 33 to 126 defines the supported ascii values for character inputs.
                if (character > 32 && character < 127)
                {
                    return character;
                }

                Console.WriteLine(string.Empty);
                Console.WriteLine("This is not a valid character.");
            }
        }

        public int GetUserIntInput()
        {
            this.Clear();
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Please enter a character.");

            while (true)
            {
                char character = Console.ReadKey().KeyChar;

                if (char.IsDigit(character))
                {
                    return int.Parse(character.ToString());
                }

                Console.WriteLine(string.Empty);
                Console.WriteLine("This is not a valid character.");
            }
        }

        private void UpdateCursor(string[] content, Position position, Direction direction)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(position.X + 1, position.Y + startNameListY);
            Console.Write(content[position.Y][position.X]);
            Console.BackgroundColor = ConsoleColor.Black;

            switch (direction)
            {
                case Direction.Up:
                    this.PrintChar(content, position.X, position.Y + 1, 1, startNameListY);
                    break;
                case Direction.Right:
                    this.PrintChar(content, position.X - 1, position.Y, 1, startNameListY);
                    break;
                case Direction.Down:
                    this.PrintChar(content, position.X, position.Y - 1, 1, startNameListY);
                    break;
                case Direction.Left:
                    this.PrintChar(content, position.X + 1, position.Y, 1, startNameListY);
                    break;
            }
        }

        private void PrintChar(string[] content, int contentX, int contentY, int cursorXOffset, int cursorYOffset)
        {
            if (contentY > content.Length - 1)
            {
                contentY = 0;
            }
            else if (contentY < 0)
            {
                contentY = content.Length - 1;
            }
            else if (contentX > content[contentY].Length - 1)
            {
                contentX = 0;
            }
            else if (contentX < 0)
            {
                contentX = content[contentY].Length - 1;
            }

            Console.SetCursorPosition(contentX + cursorXOffset, contentY + cursorYOffset);
            Console.Write(content[contentY][contentX]);
        }

        private void MoreInformation(int right, int bottom, List<int> values, List<string> output)
        {
            int offset = 2;

            string messageEscape = "Press Escape to go back to the befunge example program list.";
            string messageContinue = "Press any key to to step forward or press enter to run through the program.";

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

            this.StackBorders(this.bottomBorder + 2);
            this.Topic("Current Stack", this.bottomBorder + 3);
            this.stackDisplayX = 1;
            this.stackDisplayY = this.bottomBorder + 4;
            int currY = this.ShowStack(values, this.stackDisplayX, this.stackDisplayY);
            this.StackBorders(++currY);
            this.Topic("Output", ++currY);
            this.outDisplayX = 1;
            this.outDisplayY = ++currY;
            this.ShowOutput(output, this.outDisplayX, this.outDisplayY);
        }

        private void Topic(string name, int y)
        {
            Console.SetCursorPosition(0, y);
            Console.WriteLine(name + ":");
        }

        private int ShowStack(List<int> values, int x, int y)
        {
            int start = 0;

            if (values.Count > this.stackCounter)
            {
                Console.SetCursorPosition(this.stackDisplayX, this.stackDisplayY);
                start = this.stackCounter;
            }
            else
            {
                this.ClearLine(this.stackDisplayY);
                Console.SetCursorPosition(1, this.stackDisplayY);
                this.stackCounter = 0;
            }

            for (int i = start; i < values.Count; i++)
            {
                Console.Write(values[i].ToString() + " ");
                this.stackCounter++;
            }

            this.stackDisplayX = Console.CursorLeft;
            this.stackDisplayY = Console.CursorTop;


            return Console.CursorTop;
        }

        private void ClearLine(int y)
        {
            Console.SetCursorPosition(0, y);

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write(" ");
            }
        }

        private void ShowOutput(List<string> values, int x, int y)
        {
            int start = 0;

            if (values.Count > this.outCounter)
            {
                Console.SetCursorPosition(this.outDisplayX, this.outDisplayY);
                start = this.outCounter;
            }
            else
            {
                this.ClearLine(this.outDisplayY);
                Console.SetCursorPosition(1, this.stackDisplayY + 3);
                this.outCounter = 0;
            }

            for (int i = start; i < values.Count; i++)
            {
                Console.Write(values[i].ToString());
                this.outCounter++;
            }

            this.outDisplayX = Console.CursorLeft;
            this.outDisplayY = Console.CursorTop;
        }

        private void StackBorders(int y)
        {
            Console.SetCursorPosition(0, y);

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }
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

        public void CursorOutOfRange()
        {
            throw new NotImplementedException();
        }
    }
}
