namespace BefungeInterpreter.Logic
{
    using BefungeInterpreter.EventArgs;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.KeyboardWatcher;
    using System;
    using System.Text;
    using System.Threading;

    public class Interpreter
    {
        private ILogger logger;

        private IKeyboardWatcher keyboardWatcher;

        private ICommandVisitor visitor;

        private Thread stopThread;

        private ExitThreadArguments threadArguments;

        private bool loop;

        private bool isInputDesired;

        public Interpreter(ILogger logger, ICommandVisitor visitor)
        {
            this.logger = logger;
            this.keyboardWatcher = new KeyboardWatcher();
            this.keyboardWatcher.KeyPressed += this.KeyPressed;
            this.visitor = visitor;

            this.loop = true;
            this.isInputDesired = true;

            this.threadArguments = new ExitThreadArguments();
        }

        public void RunBefungeProgram(BefungeProgram program)
        {
            this.logger.ShowProgramContent(program.Content, program.Position, program.ValueList, program.Output);

            if (this.stopThread != null && this.stopThread.IsAlive)
            {
                throw new InvalidOperationException($"The {nameof(this.stopThread)} is already running!");
            }

            this.stopThread = new Thread(this.ListenForStop);

            while (true)
            {
                if (this.isInputDesired)
                {
                    this.keyboardWatcher.Start();
                }

                if (!this.loop)
                {
                    this.StopExitThread();
                    return;
                }

                this.GoThroughCode(program);
                this.logger.UpdateContent(program, program.ValueList, program.Output);
            }
        }

        protected void KeyPressed(object sender, KeyboardWatcherKeyPressedEventArgs e)
        {
            switch (e.Key)
            {
                case ConsoleKey.Escape:
                    this.loop = false;
                    break;
                case ConsoleKey.Enter:
                    this.SetUpRun();
                    
                    break;
            }
        }

        private void SetUpRun()
        {
            this.isInputDesired = false;
            this.stopThread = new Thread(this.ListenForStop);
            this.threadArguments.IsExit = false;
            this.stopThread.Start(this.threadArguments);
        }

        private void ListenForStop(object data)
        {
            if (!(data is ExitThreadArguments))
            {
                throw new ArgumentOutOfRangeException(nameof(data), $"The specified arguments must be of the type {nameof(ExitThreadArguments)}");
            }

            ExitThreadArguments args = (ExitThreadArguments)data;

            while (!args.IsExit)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);

                // stops looping the program.
                if (cki.Key == ConsoleKey.Escape)
                {
                    this.loop = false;
                    this.StopExitThread();
                }
                // Stops running the program and waits for user to step further as before.
                else if (cki.Key == ConsoleKey.Enter)
                {
                    this.isInputDesired = true;
                    this.StopExitThread();
                }
            }
        }

        private void StopExitThread()
        {
            this.threadArguments.IsExit = true;
        }

        private void GoThroughCode(BefungeProgram program)
        {
            if (program.Position.Y > program.Content.Length || program.Position.X >= program.Content[program.Position.Y].Length)
            {
                this.logger.CursorOutOfRange();
                this.loop = false;
                return;
            }

            for (int i = 0; i < program.Commands.Length; i++)
            {
                // Checks if the current character is equal to any supported command initializer.
                if (program.Content[program.Position.Y][program.Position.X].ToString() == program.Commands[i].CommandInitializer)
                {
                    if (program.IsStringFormat)
                    {
                        if (program.Content[program.Position.Y][program.Position.X].ToString() == "\"")
                        {
                            program.Commands[i].Accept(this.visitor);
                            this.MovePosition(program);
                            return;
                        }

                        break;
                    }

                    program.Commands[i].Accept(this.visitor);

                    if (program.IsInterpreted)
                    {
                        this.loop = false;
                        this.logger.Finished();
                        return;
                    }

                    this.MovePosition(program);
                    return;
                }
            }

            this.PushNumber(program);
            this.MovePosition(program);
        }

        private void PushNumber(BefungeProgram program)
        {
            if (program.IsStringFormat)
            {
                byte[] byteValue = Encoding.ASCII.GetBytes(program.Content[program.Position.Y][program.Position.X].ToString());
                program.StackPush(byteValue[0]);
            }

            bool isNumber = int.TryParse(program.Content[program.Position.Y][program.Position.X].ToString(), out int number);

            if (isNumber && number >= 0 && number <= 9)
            {
                program.StackPush(number);
            }
        }

        private void MovePosition(BefungeProgram program)
        {
            Position newPosition = new Position(program.Position.X, program.Position.Y);

            switch (program.Direction)
            {
                case Direction.Up:
                    newPosition = new Position(program.Position.X, program.Position.Y - 1);
                    break;
                case Direction.Right:
                    newPosition = new Position(program.Position.X + 1, program.Position.Y);
                    break;
                case Direction.Down:
                    newPosition = new Position(program.Position.X, program.Position.Y + 1);
                    break;
                case Direction.Left:
                    newPosition = new Position(program.Position.X - 1, program.Position.Y);
                    break;
            }

            program.Position = newPosition;
        }
    }
}
