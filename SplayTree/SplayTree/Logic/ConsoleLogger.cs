namespace SplayTree.Logic
{
    using System;
    using SplayTree.Commands;
    using SplayTree.Interfaces;

    public class ConsoleLogger : ILogger
    {
        private static int seperatePositiionX = 4;

        private static int startCommandListY = 4;

        private static int centerX = Console.LargestWindowWidth / 2;

        private static int centerY = Console.LargestWindowHeight / 2;

        private static char conLeft = '/';

        private static char conRight = '\\';

        public ConsoleLogger()
        {
            #pragma warning disable CA1416
            try
            {
                Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight / 2);
                this.SetTextColor();
                Console.CursorVisible = false;
            }
            catch (Exception)
            {
                return;
            }
        }

        public void Visit(ClearCommand command)
        {
            this.ShowCurrentCommand(command);
        }

        public void Visit(ContainsCommand command)
        {
            this.ShowCurrentCommand(command);
        }

        public void Visit(CountCommand command)
        {
            this.ShowCurrentCommand(command);
        }

        public void Visit(CountSpecificCommand command)
        {
            this.ShowCurrentCommand(command);
        }

        public void Visit(DisplayCommand command)
        {
            try
            {
                Console.Clear();
                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

                Console.WriteLine($"Executed Command: {command.Name} command");
                int maxLayers = command.Nodes[command.Nodes.Count - 1].Position.Y + 1;

                this.PrintNode(command.Nodes[0], maxLayers);

                Console.WriteLine(string.Empty);
                this.Continue();

                Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight / 2);
                this.SetTextColor();
            }
            catch (Exception)
            {
                return;
            }
        }

        public void Visit(InsertCommand command)
        {
            this.ShowCurrentCommand(command);
        }

        public void Visit(MaxCommand command)
        {
            this.ShowCurrentCommand(command);
        }

        public void Visit(MinCommand command)
        {
            this.ShowCurrentCommand(command);
        }

        public void Visit(RemoveCommand command)
        {
            this.ShowCurrentCommand(command);
        }

        public void Visit(TraverseCommand command)
        {
            this.ShowCurrentCommand(command);

            Console.WriteLine("1. In-Order");
            Console.WriteLine("2. Pre-Order");
            Console.WriteLine("3. Post-Order");
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
                try
                {
                    if (xPos < Console.WindowWidth && yPos < Console.WindowHeight)
                    {
                        Console.SetCursorPosition(xPos, yPos++);
                        Console.Write($"| {commands[i].Name}");
                    }
                }
                catch (Exception)
                {
                    return;
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
                try
                {
                    Console.SetCursorPosition(xPos, yPos);
                }
                catch (Exception)
                {
                    return;
                }
                
                Console.Write("->");

                // Clears console above arrow.
                try
                {
                    Console.SetCursorPosition(xPos, yPos - 1);
                }
                catch (Exception)
                {
                    return;
                }
                
                Console.Write("  ");

                // Clears console under arrow.
                try
                {
                    Console.SetCursorPosition(xPos, yPos + 1);
                }
                catch (Exception)
                {
                    return;
                }
                
                Console.Write("  ");

                if (yPos == startCommandListY)
                {
                    // Current Arrow position.
                    try
                    {
                        Console.SetCursorPosition(xPos, startCommandListY + lengthOfCommandList);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                    
                    Console.Write("  ");
                }

                if (yPos == startCommandListY + lengthOfCommandList)
                {
                    // Current Arrow position.
                    try
                    {
                        Console.SetCursorPosition(xPos, startCommandListY);
                    }
                    catch (Exception)
                    {
                        return;
                    }

                 
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

                if (isNumber && number >= 0)
                {
                    return number;
                }

                Console.WriteLine("This is not a valid number");
            }
        }

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

        private void ShowCurrentCommand(BaseCommand command)
        {
            Console.Clear();

            Console.WriteLine($"Executed Command: {command.Name} command");
            Console.WriteLine(string.Empty);
        }

        private void PrintNode(Node node, int maxLayer)
        {
            int length = node.Value.ToString().Length;
            int layerSpace = maxLayer - node.Position.Y;

            int currX = centerX - length + node.Position.X;
            int currY = node.Position.Y;

            try
            {
                Console.SetCursorPosition(currX, currY);
            }
            catch (Exception)
            {
                return;
            }
        
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

        private void SetTextColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void SetValueConnectionColor()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
