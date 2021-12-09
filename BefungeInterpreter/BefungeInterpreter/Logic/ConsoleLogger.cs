//-----------------------------------------------------------------------
// <copyright file="ConsoleLogger.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the console logger of the application.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using BefungeInterpreter.Interfaces;

    /// <summary>
    /// Represents a console logger for the application.
    /// </summary>
    [ExcludeFromCodeCoverage]
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

        /// <summary>
        /// Represents the right border position of the program.
        /// </summary>
        private int rightBorder;

        /// <summary>
        /// Represents the bottom border position of the program.
        /// </summary>
        private int bottomBorder;

        /// <summary>
        /// Represents the starting x position for the stack.
        /// </summary>
        private int stackDisplayX;

        /// <summary>
        /// Represents the starting y position for the stack.
        /// </summary>
        private int stackDisplayY;

        /// <summary>
        /// Represents the starting position of the stack.
        /// </summary>
        private int stackDisplayStart;

        /// <summary>
        /// Represents amount of displayed stack values.
        /// </summary>
        private int stackCounter;

        /// <summary>
        /// Represents the starting x position of the output list.
        /// </summary>
        private int outDisplayX;

        /// <summary>
        /// Represents the starting y position of the output list.
        /// </summary>
        private int outDisplayY;

        /// <summary>
        /// Represents the starting position of the output list.
        /// </summary>
        private int outDisplayStart;

        /// <summary>
        /// Represents the amount of displayed output values.
        /// </summary>
        private int outCounter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleLogger"/> class.
        /// </summary>
        public ConsoleLogger()
        {
            #pragma warning disable CA1416

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;

            this.stackCounter = 0;
            this.outCounter = 0;
        }

        /// <summary>
        /// Represents a method for displaying a message.
        /// </summary>
        /// <param name="message">The current message.</param>
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Represents the method for showing all possible <see cref="BefungeProgram"/>.
        /// </summary>
        /// <param name="befungeProgramPaths">The paths of all programs.</param>
        public void ShowBefungePrograms(string[] befungeProgramPaths)
        {
            Console.CursorVisible = false;
            int[] lengths = this.GetPathLengths(befungeProgramPaths);
            this.Borders("Provided Befunge example programs.", lengths);

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

        /// <summary>
        /// Represents the method for displaying the cursor position.
        /// </summary>
        /// <param name="yPosition">The y position of the cursor.</param>
        /// <param name="lengthOfBefungePrograms">The amount of programs.</param>
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

        /// <summary>
        /// Represents the method for showing the content of the current <see cref="BefungeProgram"/>.
        /// </summary>
        /// <param name="content">The current content of the program.</param>
        /// <param name="position">The current cursor position.</param>
        /// <param name="values">The current values of the stack.</param>
        /// <param name="output">The current output of the program.</param>
        public void ShowProgramContent(string[] content, Position position, List<int> values, List<string> output)
        {
            Console.CursorVisible = false;
            this.Clear();

            int[] lengths = this.GetLength(content);
            this.Borders("The selected befunge program.", lengths);

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

        /// <summary>
        /// Represents the method for indicating that the interpreter is finished.
        /// </summary>
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

        /// <summary>
        /// Represents the method for updating the cursor position, the stack values and the output.
        /// </summary>
        /// <param name="program">The current program.</param>
        /// <param name="stackValues">The current values of the stack.</param>
        /// <param name="output">The current output of the stack.</param>
        public void UpdateContent(BefungeProgram program, List<int> stackValues, List<string> output)
        {
            this.UpdateCursor(program.Content, program.Position, program.Direction);

            int currY = this.ShowStack(stackValues, this.stackDisplayX, this.stackDisplayY);
            this.StackBorders(++currY);
            this.ClearLine(++currY);
            this.Topic("Output", currY);
            this.outDisplayY = ++currY;
            this.outDisplayStart = currY;
            this.ClearLine(currY + 1);
            this.ShowOutput(output, this.outDisplayX, this.outDisplayY);
        }

        /// <summary>
        /// Represents the method for clearing the console.
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Represents the method for waiting for user input to continue.
        /// </summary>
        public void Continue()
        {
            Console.ReadKey(true);
        }

        /// <summary>
        /// Represents the method for getting a character from the user.
        /// </summary>
        /// <returns>The character from the user input.</returns>
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

        /// <summary>
        /// Represents the method for getting a integer value from the user.
        /// </summary>
        /// <returns>The integer from the user input.</returns>
        public int GetUserIntInput()
        {
            this.Clear();
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Please enter a number between 0 and 9.");

            while (true)
            {
                char character = Console.ReadKey().KeyChar;

                if (char.IsDigit(character))
                {
                    return int.Parse(character.ToString());
                }

                Console.WriteLine(string.Empty);
                Console.WriteLine("This is not a valid number.");
            }
        }

        /// <summary>
        /// Represents the method for updating the cursor position.
        /// </summary>
        /// <param name="content">The content of the current program.</param>
        /// <param name="position">The current position of the cursor.</param>
        /// <param name="direction">The current direction of the cursor.</param>
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

        /// <summary>
        /// Represents the method for showing the printed character.
        /// </summary>
        /// <param name="content">The content of the current program.</param>
        /// <param name="contentX">The x position of the current content.</param>
        /// <param name="contentY">The y position of the current content.</param>
        /// <param name="cursorXOffset">The offset of the x position.</param>
        /// <param name="cursorYOffset">The offset of the y position.</param>
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

        /// <summary>
        /// Represents the method for visualizing info's.
        /// </summary>
        /// <param name="right">The position of the right border.</param>
        /// <param name="bottom">The position of the bottom border.</param>
        /// <param name="values">The list of all values on the stack.</param>
        /// <param name="output">The list of all output values.</param>
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
            this.stackDisplayX = 0;
            this.stackDisplayY = this.bottomBorder + 4;
            this.stackDisplayStart = this.bottomBorder + 4;
            int currY = this.ShowStack(values, this.stackDisplayX, this.stackDisplayY);
            this.StackBorders(++currY);
            this.Topic("Output", ++currY);
            this.outDisplayX = 0;
            this.outDisplayY = ++currY;
            this.outDisplayStart = currY;
            this.ShowOutput(output, this.outDisplayX, this.outDisplayY);
        }

        /// <summary>
        /// Represents the method for showcasing the topic of the showcase.
        /// </summary>
        /// <param name="name">The name of the displayed list.</param>
        /// <param name="y">The y position of the cursor.</param>
        private void Topic(string name, int y)
        {
            Console.SetCursorPosition(0, y);
            Console.WriteLine(name + ":");
        }

        /// <summary>
        /// Represents the method for showing the stack information.
        /// </summary>
        /// <param name="values">The values of the current stack.</param>
        /// <param name="x">The x position of the cursor.</param>
        /// <param name="y">The y position of the cursor.</param>
        /// <returns>The y position of the current cursor.</returns>
        private int ShowStack(List<int> values, int x, int y)
        {
            int xPos = x;
            int yPos = y;

            int start = 0;

            if (values.Count >= this.stackCounter)
            {
                start = this.stackCounter;
            }
            else
            {
                for (int i = this.stackDisplayStart; i <= this.stackDisplayY; i++)
                {
                    this.ClearLine(i);
                }
               
                xPos = 0;
                yPos = this.stackDisplayStart;
                start = 0;
                this.stackCounter = 0;
            }

            for (int i = start; i < values.Count; i++)
            {
                if (xPos >= Console.WindowWidth - 1)
                {
                    xPos = 0;
                    yPos++;
                    this.ClearLine(yPos);
                }

                Console.SetCursorPosition(xPos, yPos);
                Console.Write(values[i].ToString() + " ");
                this.stackCounter++;
                xPos = Console.CursorLeft;
            }

            this.stackDisplayX = xPos;
            this.stackDisplayY = yPos;

            return yPos;
        }

        /// <summary>
        /// Represents the method for clearing the line from the console.
        /// </summary>
        /// <param name="y">The y position of the cursor.</param>
        private void ClearLine(int y)
        {
            Console.SetCursorPosition(0, y);

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write(" ");
            }
        }

        /// <summary>
        /// Represents the method for showing the output values.
        /// </summary>
        /// <param name="values">The values of the output list.</param>
        /// <param name="x">The x position of the cursor.</param>
        /// <param name="y">The y position of the cursor.</param>
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
                int number;
                bool isNumber = int.TryParse(values[i], out number);

                if (isNumber)
                {
                    Console.Write(values[i].ToString() + " ");
                }
                else
                {
                    Console.Write(values[i].ToString());
                }

                this.outCounter++;
            }

            this.outDisplayX = Console.CursorLeft;
            this.outDisplayY = Console.CursorTop;
        }

        /// <summary>
        /// Represents the method for displaying the stack of the program.
        /// </summary>
        /// <param name="y">The y position of the cursor.</param>
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
        /// <param name="lengthsOfContents">Represents the list of content lengths.</param>
        private void Borders(string message, int[] lengthsOfContents)
        {
            int longestName = message.Length;

            for (int i = 0; i < lengthsOfContents.Length; i++)
            {
                int length = lengthsOfContents[i];

                if (length + separatePositiionX > longestName)
                {
                    longestName = length;
                }
            }

            if (separatePositiionX + longestName > Console.WindowWidth)
            {
                Console.SetWindowSize(separatePositiionX + longestName + 6, lengthsOfContents.Length + 6);
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
            for (int i = 1; i < lengthsOfContents.Length + 5; i++)
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
                this.bottomBorder = lengthsOfContents.Length + 5;

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
            for (int i = 1; i < lengthsOfContents.Length + 5; i++)
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

        /// <summary>
        /// Represents the method for extracting the length of each content line.
        /// </summary>
        /// <param name="content">The content of the program.</param>
        /// <returns>The length of each content line.</returns>
        private int[] GetLength(string[] content)
        {
            int[] lengths = new int[content.Length];

            for (int i = 0; i < content.Length; i++)
            {
                lengths[i] = content[i].Length;
            }

            return lengths;
        }

        /// <summary>
        /// Represents the method for extracting the length of each file name from the directory.
        /// </summary>
        /// <param name="paths">The list of all possible programs.</param>
        /// <returns>The length of each file name.</returns>
        private int[] GetPathLengths(string[] paths)
        {
            int[] lengths = new int[paths.Length];

            for (int i = 0; i < paths.Length; i++)
            {
                lengths[i] = Path.GetFileNameWithoutExtension(paths[i]).Length;
            }

            return lengths;
        }
    }
}
