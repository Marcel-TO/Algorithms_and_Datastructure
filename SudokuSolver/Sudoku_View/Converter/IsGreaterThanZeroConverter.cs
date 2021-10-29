//-----------------------------------------------------------------------
// <copyright file="IsGreaterThanZeroConverter.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the converter that checks if the value is greater than zero.</summary>
//-----------------------------------------------------------------------
namespace Sudoku_View.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// Represents the converter which checks if the value is greater than zero.
    /// </summary>
    public class IsGreaterThanZeroConverter : IValueConverter
    {
        /// <summary>
        /// Represents the method that checks if the value is greater than zero.
        /// </summary>
        /// <param name="value">The value indicating whether the field is useable.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>Returns the value if the field is greater than zero, otherwise empty string.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                if ((int)value > 0)
                {
                    return value;
                }
            }

            return " ";
        }

        /// <summary>
        /// Represents the method that converts back.
        /// </summary>
        /// <param name="value">The value indicating whether the field is useable.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>Returns the not implemented exception, because it is not implemented yet.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
