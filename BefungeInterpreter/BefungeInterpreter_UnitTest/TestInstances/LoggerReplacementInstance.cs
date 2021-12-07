namespace BefungeInterpreter_UnitTests.TestInstances
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;

    public class LoggerReplacementInstance : ILogger
    {
        public void Log(string message)
        {
            return;
        }

        public void ShowBefungePrograms(string[] befungeProgramPaths)
        {
            return;
        }

        public void ShowCursor(int yPosition, int lengthOfBefungePrograms)
        {
            return;
        }

        public void ShowProgramContent(string[] content, Position position, List<int> values, List<int> output)
        {
            return;
        }

        public void Finished()
        {
            return;
        }

        public void UpdateContent(BefungeProgram program, List<int> stackValues, List<string> output)
        {
            return;
        }

        public void Clear()
        {
            return;
        }

        public void Continue(string message)
        {
            return;
        }

        public void CursorOutOfRange()
        {
            return;
        }

        public void ShowProgramContent(string[] content, Position position, List<int> values, List<string> output)
        {
            throw new NotImplementedException();
        }

        public void Continue()
        {
            throw new NotImplementedException();
        }

        public char GetUserCharInput()
        {
            throw new NotImplementedException();
        }

        public int GetUserIntInput()
        {
            throw new NotImplementedException();
        }
    }
}