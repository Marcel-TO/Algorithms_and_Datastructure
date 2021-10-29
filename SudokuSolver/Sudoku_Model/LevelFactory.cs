//-----------------------------------------------------------------------
// <copyright file="LevelFactory.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the level factory creator.</summary>
//-----------------------------------------------------------------------
namespace Sudoku_Model
{
    using System;
    using System.Collections.Generic;
    using Sudoku_Model.EventArgs;
    using Sudoku_Model.Exceptions;

    /// <summary>
    /// Represents the level factory class.
    /// </summary>
    public class LevelFactory
    {
        /// <summary>
        /// Represents the amount of fields of the sudoku board.
        /// </summary>
        private int amount;

        /// <summary>
        /// Represents the file reader.
        /// </summary>
        private FileReader fileReader;

        /// <summary>
        /// The content of the current sudoku file.
        /// </summary>
        private string content;

        /// <summary>
        /// Initializes a new instance of the <see cref="LevelFactory"/> class.
        /// </summary>
        /// <param name="amount">The amount of fields of the sudoku board.</param>
        public LevelFactory(int amount)
        {
            this.amount = amount;
            this.fileReader = new FileReader();
            this.fileReader.FileRead += this.ContentExtractedFromFile;
        }

        /// <summary>
        /// Represents opening a file and extracting the path.
        /// </summary>
        /// <param name="path">The path of the current level file.</param>
        /// <returns>The created sudoku game board.</returns>
        public Board LoadLevel(string path)
        {
            this.content = string.Empty;
            this.fileReader.ReadFile(path);

            if (this.content == string.Empty)
            {
                throw new BoardNotPossibleException($"The content of the file {path} is not readable, therefore the creation of the board is not possible.");
            }

            return this.CreateBoard(this.content);
        }

        /// <summary>
        /// Represents the content extraction of the current file.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        protected void ContentExtractedFromFile(object sender, FileEventArgs e)
        {
            this.content = e.Content;
        }

        /// <summary>
        /// Represents the method for creating the current game board.
        /// </summary>
        /// <param name="content">The content of the current sudoku file.</param>
        /// <returns>The new created game board.</returns>
        private Board CreateBoard(string content)
        {
            string numberString = this.RemoveUnwantedCharacters(content);
            int[] numbers = new int[this.amount];

            int count = 0;

            for (int i = 0; i < numberString.Length; i++)
            {
                if (numberString.Length > this.amount)
                {
                    throw new BoardNotPossibleException($"The content of the current file is not valid, please only use supported files.");
                }

                int number;

                bool isNumber = int.TryParse(numberString[i].ToString(), out number);

                if (!isNumber || number < 0 || number > 9)
                {
                    throw new BoardNotPossibleException($"The content of the current file is not valid, please only use supported files.");
                }

                numbers[count++] = number;
            }

            List<Field> fields = this.SetFields(numbers);

            return new Board(fields);
        }

        /// <summary>
        /// Removes the unwanted characters of the file content.
        /// </summary>
        /// <param name="content">The content of the current file.</param>
        /// <returns>A string with all numbers for the fields.</returns>
        private string RemoveUnwantedCharacters(string content)
        {
            string removed = string.Empty;
            string[] removedR = content.Split('\r');
            removed += this.ArraysToString(removedR);
            string[] removedN = removed.Split('\n');
            removed = this.ArraysToString(removedN);
            string[] removedComma = removed.Split(',');
            removed = this.ArraysToString(removedComma);

            return removed;
        }

        /// <summary>
        /// Converts the array into a string.
        /// </summary>
        /// <param name="array">The array of the numbers being split.</param>
        /// <returns>A string combined from the array.</returns>
        private string ArraysToString(string[] array)
        {
            string content = string.Empty;

            foreach (string text in array)
            {
                content += text;
            }

            return content;
        }

        /// <summary>
        /// Creates the field list of the sudoku game board.
        /// </summary>
        /// <param name="numbers">The numbers for the field list.</param>
        /// <returns>The list of fields for the new game board.</returns>
        private List<Field> SetFields(int[] numbers)
        {
            List<Field> fields = new List<Field>();
            int block = 1;
            int counter = 0;
            int columnCounter = 1;
            int rowCounter = 1;

            for (int i = 0; i < this.amount; i++)
            {
                if (counter == 3)
                {
                    block++;
                    counter = 0;
                }

                if (numbers[i] > 0)
                {
                    Field field = new Field(numbers[i], false, block, rowCounter, columnCounter);
                    fields.Add(field);
                }

                if (numbers[i] == 0)
                {
                    Field field = new Field(numbers[i], true, block, rowCounter, columnCounter);
                    fields.Add(field);
                }

                counter++;
                rowCounter++;

                if (rowCounter > 9)
                {
                    columnCounter++;
                    rowCounter = 1;
                    counter = 0;

                    if (columnCounter < 4)
                    {
                        block = 1;
                    }

                    if (columnCounter >= 4 && columnCounter <= 6)
                    {
                        block = 4;
                    }

                    if (columnCounter > 6)
                    {
                        block = 7;
                    }
                }
            }

            return fields;
        }
    }
}
