//-----------------------------------------------------------------------
// <copyright file="IsAccessableConverter.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the converter that changes the color of the content.</summary>
//-----------------------------------------------------------------------
namespace Sudoku_View.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// Represents the converter that changes the foreground color of the content.
    /// </summary>
    public class IsAccessableConverter : IValueConverter
    {
        /// <summary>
        /// Represents the method that converts the foreground color.
        /// </summary>
        /// <param name="value">The value indicating whether the field is useable.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>Returns white if the field is not useable, otherwise orange.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value == true)
                {
                    return "#ffb700";
                }

                return "#ffffff";
            }

            return null;
        }

        /// <summary>
        /// Represents the method that converts the foreground color back.
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
