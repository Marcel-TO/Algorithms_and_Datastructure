//-----------------------------------------------------------------------
// <copyright file="ConsoleLogger.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines a console logger for the application.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.Logic
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using SplayTree.Commands;
    using SplayTree.Interfaces;

    /// <summary>
    /// Represents the console logger of the application.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ConsoleLogger : ILogger
    {
        /// <summary>
        /// Represents the seperator between the cursor and the commands.
        /// </summary>
        private static int seperatePositiionX = 4;

        /// <summary>
        /// Represents the y start position of the command list.
        /// </summary>
        private static int startCommandListY = 4;

        /// <summary>
        /// Represents the center of the x-coordinate.
        /// </summary>
        private static int centerX = Console.LargestWindowWidth / 2;

        /// <summary>
        /// Represents the connection character for the lesser child node.
        /// </summary>
        private static char conLeft = '/';

        /// <summary>
        /// Represents the connection character for the bigger child node.
        /// </summary>
        private static char conRight = '\\';

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleLogger"/> class.
        /// </summary>
        public ConsoleLogger()
        {
            // Disabled the warning that it is only supported by windows.
            #pragma warning disable CA1416

            // Sets the base window size of the console.
            try
            {
                Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight / 2);
            }
            catch (Exception)
            {
            }
            
            this.SetTextColor();
            Console.CursorVisible = false;
        }

        /// <summary>
        /// Represents the visitor pattern of the clear command.
        /// </summary>
        /// <param name="command">Represents the clear command of the splay tree.</param>
        public void Visit(ClearCommand command)
        {
            this.ShowCurrentCommand(command);
        }

        /// <summary>
        /// Represents the visitor pattern of the contains command.
        /// </summary>
        /// <param name="command">Represents the contains command of the splay tree.</param>
        public void Visit(ContainsCommand command)
        {
            this.ShowCurrentCommand(command);
        }

        /// <summary>
        /// Represents the visitor pattern of the count command.
        /// </summary>
        /// <param name="command">Represents the count command of the splay tree.</param>
        public void Visit(CountCommand command)
        {
            this.ShowCurrentCommand(command);
        }

        /// <summary>
        /// Represents the visitor pattern of the count specific command.
        /// </summary>
        /// <param name="command">Represents the count specific command of the splay tree.</param>
        public void Visit(CountSpecificCommand command)
        {
            this.ShowCurrentCommand(command);
        }

        /// <summary>
        /// Represents the visitor pattern of the display command.
        /// </summary>
        /// <param name="command">Represents the display command of the splay tree.</param>
        public void Visit(DisplayCommand command)
        {
            Console.Clear();
            try
            {
                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            }
            catch (Exception)
            {
            }
            

            Console.WriteLine($"Executed Command: {command.Name} command");
            int maxLayers = command.Nodes[command.Nodes.Count - 1].Position.Y + 1;

            this.PrintNode(command.Nodes[0], maxLayers);

            Console.SetCursorPosition(0, 1);
            this.SetTextColor();
            Console.WriteLine(string.Empty);
            this.Continue();

            try
            {
                Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight / 2);
            }
            catch (Exception)
            {
            }
           
            this.SetTextColor();
        }

        /// <summary>
        /// Represents the visitor pattern of the insert command.
        /// </summary>
        /// <param name="command">Represents the insert command of the splay tree.</param>
        public void Visit(InsertCommand command)
        {
            this.ShowCurrentCommand(command);
        }

        /// <summary>
        /// Represents the visitor pattern of the maximum command.
        /// </summary>
        /// <param name="command">Represents the maximum command of the splay tree.</param>
        public void Visit(MaxCommand command)
        {
            this.ShowCurrentCommand(command);
        }

        /// <summary>
        /// Represents the visitor pattern of the minimum command.
        /// </summary>
        /// <param name="command">Represents the minimum command of the splay tree.</param>
        public void Visit(MinCommand command)
        {
            this.ShowCurrentCommand(command);
        }

        /// <summary>
        /// Represents the visitor pattern of the remove command.
        /// </summary>
        /// <param name="command">Represents the remove command of the splay tree.</param>
        public void Visit(RemoveCommand command)
        {
            this.ShowCurrentCommand(command);
        }

        /// <summary>
        /// Represents the visitor pattern of the traverse command.
        /// </summary>
        /// <param name="command">Represents the traverse command of the splay tree.</param>
        public void Visit(TraverseCommand command)
        {
            this.ShowCurrentCommand(command);

            Console.WriteLine("1. In-Order");
            Console.WriteLine("2. Pre-Order");
            Console.WriteLine("3. Post-Order");
        }

        /// <summary>
        /// Represents the welcome logging.
        /// </summary>
        public void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the amazing Splay-Tree algortihm showcase.");
            Console.WriteLine(string.Empty);
        }

        /// <summary>
        /// Represents the showcase of all supported commands.
        /// </summary>
        /// <param name="commands">Represents the list of all supported commands.</param>
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

        /// <summary>
        /// Represents the visualization of the cursor.
        /// </summary>
        /// <param name="index">Represents the index of the commands list.</param>
        /// <param name="lengthOfCommandList">Represents the amount of the supported commands.</param>
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

        /// <summary>
        /// Represents the method for logging a message.
        /// </summary>
        /// <param name="message">Represents the message for the user.</param>
        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Represents the method for awaiting user input to continue.
        /// </summary>
        public void Continue()
        {
            Console.WriteLine("Please press any key to continue.");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Represents the method for clearing the console.
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Represents the method for getting a value from user.
        /// </summary>
        public int GetValueFromUser()
        {
            Console.WriteLine("Please enter a value.");

            while (true)
            {
                int number;

                bool isNumber = int.TryParse(Console.ReadLine(), out number);

                if (isNumber && number >= 0)
                {
                    return number;
                }

                Console.WriteLine("This is not a valid number");
            }
        }

        /// <summary>
        /// Represents the method for getting value from user to choose the traversal order of the tree.
        /// </summary>
        public int ChooseTraverseOrder()
        {
            Console.WriteLine("Please enter a value.");

            while (true)
            {
                int number;

                bool isNumber = int.TryParse(Console.ReadLine(), out number);

                if (isNumber && number >= 1 && number <= 3)
                {
                    return number;
                }

                Console.WriteLine("This is not a number");
            }
        }

        /// <summary>
        /// Represents the visualization of the current command.
        /// </summary>
        /// <param name="command">Represents the current command of the splay tree.</param>
        private void ShowCurrentCommand(BaseCommand command)
        {
            Console.Clear();

            Console.WriteLine($"Executed Command: {command.Name} command");
            Console.WriteLine(string.Empty);
        }

        /// <summary>
        /// Represents the method for logging the current node.
        /// </summary>
        /// <param name="node">Represents the current node of the splay tree.</param>
        /// <param name="maxLayer">Represents the amount of layers from the splay tree.</param>
        private void PrintNode(Node node, int maxLayer)
        {
            int length = node.Value.ToString().Length;
            int layerSpace = maxLayer - node.Position.Y;

            int currX = centerX - length + node.Position.X;
            int currY = node.Position.Y;

            Console.SetCursorPosition(currX, currY);

            this.SetTextColor();
            Console.Write(node.Value);

            if (node.LesserNode != null)
            {
                this.PrintChildNode(node, node.LesserNode, maxLayer, conLeft, false, currX, currY);
            }

            if (node.BiggerNode != null)
            {
                this.PrintChildNode(node, node.BiggerNode, maxLayer, conRight, true, currX, currY);
            }
        }

        /// <summary>
        /// Represents the method for printing the child node.
        /// </summary>
        /// <param name="parent">Represents the parent node of the current node.</param>
        /// <param name="child">Represents the current node of the splay tree.</param>
        /// <param name="maxLayer">Represents the amount of layers of the splay tree.</param>
        /// <param name="connection">Represents the connection visualization of the nodes.</param>
        /// <param name="isBigger">Represents a value indicating whether the child bigger than the parent node, otherwise false.</param>
        /// <param name="x">Represents the x position of the parent node.</param>
        /// <param name="y">Represents the y position of the parent tree.</param>
        private void PrintChildNode(Node parent, Node child, int maxLayer, char connection, bool isBigger, int x, int y)
        {
            int length = child.Value.ToString().Length;
            int layerSpace = maxLayer - child.Position.Y;

            int tempX = x;
            int tempY = y;

            for (int i = 0; i < layerSpace; i++)
            {
                if (isBigger)
                {
                    tempX += 1;
                }
                else
                {
                    tempX -= 1;
                }

                tempY++;

                try
                {
                    Console.SetCursorPosition(tempX, tempY);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.SetCursorPosition(0, 1);
                    this.SetTextColor();
                    Console.WriteLine("It appears the tree is bigger than the supported window size.");
                    Console.WriteLine("If you want to see, whats cut off, I would suggest to traverse the tree.");
                    return;
                }
           
                this.SetValueConnectionColor();
                Console.Write(connection);
            }

            int currX = tempY;
            int currY = tempY;

            if (isBigger)
            {
                currX = tempX + 1;
                currY = tempY + 1;
            }
            else
            {
                currX = tempX - 1;
                currY = tempY + 1;
            }

            try
            {
                Console.SetCursorPosition(currX, currY);
            }
            catch (Exception)
            {
                return;
            }
          
            this.SetTextColor();
            Console.Write(child.Value);

            if (child.LesserNode != null)
            {
                this.PrintChildNode(child, child.LesserNode, maxLayer, conLeft, false, currX, currY);
            }

            if (child.BiggerNode != null)
            {
                this.PrintChildNode(child, child.BiggerNode, maxLayer, conRight, true, currX, currY);
            }
        }

        /// <summary>
        /// Represents the visitor pattern of the clear command.
        /// </summary>
        /// <param name="message">Represents the message of the application.</param>
        /// <param name="commands">Represents the list of commands.</param>
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
            for (int i = 0; i < seperatePositiionX + longestName; i++)
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
            for (int i = 1; i < commands.Length + 5; i++)
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
            for (int i = 0; i < seperatePositiionX + longestName; i++)
            {
                try
                {
                    Console.SetCursorPosition(i, commands.Length + 5);
                }
                catch (Exception)
                {
                    return;
                }
           
                Console.WriteLine("-");
            }

            // Right Border
            for (int i = 1; i < commands.Length + 5; i++)
            {
                try
                {
                    Console.SetCursorPosition(seperatePositiionX + longestName, i);
                }
                catch (Exception)
                {
                    return;
                }
             
                Console.WriteLine("|");
            }
        }

        /// <summary>
        /// Represents the method for changing the color of the text.
        /// </summary>
        private void SetTextColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Represents the method for changing the color of the connection lines.
        /// </summary>
        private void SetValueConnectionColor()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
