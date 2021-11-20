namespace BefungeInterpreter.Interfaces
{
    using BefungeInterpreter.Logic;
    using System;
    using System.Collections.Generic;

    public interface ILogger
    {
        void Log(string message);

        void ShowCursor(int yPosition, int lengthOfBefungePrograms);

        void ShowBefungePrograms(string[] befungeProgramPaths);

        void ShowProgramContent(string[] content, Position position);

        void Clear();
    }
}
