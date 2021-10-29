//-----------------------------------------------------------------------
// <copyright file="FieldVM.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the view model field of the respective field model.</summary>
//-----------------------------------------------------------------------
namespace Sudoku_ViewModel
{
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using Sudoku_Model;

    /// <summary>
    /// Represents the view model of the field.
    /// </summary>
    public class FieldVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Represents its respective field model.
        /// </summary>
        private Field field;

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldVM"/> class.
        /// </summary>
        /// <param name="field">The field model.</param>
        public FieldVM(Field field)
        {
            this.Field = field;
            this.IsAllowed = true;
        }

        /// <summary>
        /// Occurs if one of the properties gets changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the field model.
        /// </summary>
        /// <value>The field model.</value>
        public Field Field
        {
            get
            {
                return this.field;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(value)} must not be null!");
                }

                this.field = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Field)));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the number of the field model is allowed or not.
        /// </summary>
        /// <value>True if the number of the field is allowed, otherwise false.</value>
        public bool IsAllowed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the command which changes the number of the field.
        /// </summary>
        /// <value>The command which changes the number of the field model.</value>
        public ICommand ChangeNumber
        {
            get
            {
                return new GenericCommand(obj =>
                {
                    if (this.Field.IsAccessable)
                    {
                        int number;
                        int.TryParse(obj as string, out number);

                        if (number >= 1 && number <= 9)
                        {
                            this.Field.Number = number;
                            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Field)));
                        }
                    }
                });
            }
        }
    }
}
