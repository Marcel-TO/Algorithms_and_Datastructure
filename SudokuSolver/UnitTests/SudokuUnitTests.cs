//-----------------------------------------------------------------------
// <copyright file="SudokuUnitTests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the unit test of the sudoku game.</summary>
//-----------------------------------------------------------------------
namespace UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Sudoku_Model;
    using Sudoku_Model.EventArgs;
    using Sudoku_Model.Exceptions;

    /// <summary>
    /// Represents the unit tests of the sudoku application.
    /// </summary>
    [TestClass]
    public class SudokuUnitTests
    {
        /// <summary>
        /// Represents the amount of fields from the board.
        /// </summary>
        private int amount;

        /// <summary>
        /// Initializes a new instance of the <see cref="SudokuUnitTests"/> class.
        /// </summary>
        public SudokuUnitTests()
        {
            this.amount = 81;
        }

        /// <summary>
        /// Represents the method for testing if the file reader fires the correct event if the file was correct.
        /// </summary>
        [TestMethod]
        public void FileReader_Correct_Test()
        {
            FileReader reader = new FileReader();
            string contentEvent = null;

            reader.FileRead += delegate(object sender, FileEventArgs e)
            {
                contentEvent = e.Content;
            };

            reader.ReadFile(@"M:\Visual_Studio\Semester_3\SudokuSolver\Lvls\Empty.txt");

            Assert.IsNotNull(contentEvent);
        }

        /// <summary>
        /// Represents the method for testing if the file reader reacts properly to wrong inputs.
        /// </summary>
        [TestMethod]
        public void FileReader_Wrong_Test()
        {
            FileReader reader = new FileReader();
            string contentEvent = null;

            reader.FileRead += delegate(object sender, FileEventArgs e)
            {
                contentEvent = e.Content;
            };

            reader.ReadFile(@"M:\Visual_Studio\Semester_3\SudokuSolver\Lvls\doesntExist.txt");

            Assert.IsNull(contentEvent);
        }

        /// <summary>
        /// Represents the method for testing if the loading sequence creates a board.
        /// </summary>
        [TestMethod]
        public void CreateBoard_Correct_Test()
        {
            LevelFactory factory = new LevelFactory(this.amount);
            Board board = factory.LoadLevel(@"M:\Visual_Studio\Semester_3\SudokuSolver\Lvls\Lvl_1.txt");

            Assert.IsNotNull(board);
        }

        /// <summary>
        /// Represents the method for testing if the loading sequence throws the correct exception when the input is not valid.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BoardNotPossibleException))]
        public void CreateBoard_Wrong_Test()
        {
            LevelFactory factory = new LevelFactory(this.amount);
            Board board = factory.LoadLevel(@"M:\Visual_Studio\Semester_3\SudokuSolver\Lvls\doesntExist.txt");
        }

        /// <summary>
        /// Represents the method for testing the solving sequence of a sudoku level.
        /// </summary>
        [TestMethod]
        public void SolvingSequence_Correct_Test()
        {
            LevelFactory factory = new LevelFactory(this.amount);

            Board board = factory.LoadLevel(@"M:\Visual_Studio\Semester_3\SudokuSolver\Lvls\Lvl_1.txt");

            BacktrackingSolver solver = new BacktrackingSolver(board.Fields);
            solver.InitializeSolvingSequence();

            Board solved = factory.LoadLevel(@"M:\Visual_Studio\Semester_3\SudokuSolver\Lvls_Solved\Lvl_1_Solved.txt");

            for (int i = 0; i < board.Fields.Count; i++)
            {
                Assert.AreEqual(board.Fields[i].Number, solved.Fields[i].Number);
            }
        }

        /// <summary>
        /// Represents the method for testing the solving sequence and if it fires the correct event when the input data is not valid.
        /// </summary>
        [TestMethod]
        public void SolvingSequence_Wrong_Test()
        {
            LevelFactory factory = new LevelFactory(this.amount);

            Board board = factory.LoadLevel(@"M:\Visual_Studio\Semester_3\SudokuSolver\Lvls\Unsolvable.txt");

            BacktrackingSolver solver = new BacktrackingSolver(board.Fields);

            bool unsolveableEvent = true;

            solver.Unsolvable += delegate(object sender, UnsolvableEventArgs e)
            {
                unsolveableEvent = e.IsSolveable;
            };

            solver.InitializeSolvingSequence();

            Assert.IsFalse(unsolveableEvent);
        }
    }
}
