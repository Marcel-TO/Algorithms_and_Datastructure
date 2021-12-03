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

        void ShowProgramContent(string[] content, Position position, List<int> values, List<string> output);

        void UpdateContent(BefungeProgram program, List<int> values, List<string> output);

        void Clear();

        void Continue();

        void CursorOutOfRange();

        void Finished();

        char GetUserCharInput();

        int GetUserIntInput();
    }
}
