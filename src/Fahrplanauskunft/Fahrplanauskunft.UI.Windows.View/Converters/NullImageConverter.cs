// <copyright file="NullImageConverter.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Fahrplanauskunft.UI.Windows.View.Converters
{
    public class NullImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null)
            {
                if(targetType == typeof(Brush))
                {
                    return new SolidColorBrush(Colors.White);
                }

                return "#FFFFFF";
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string)
            {
                try
                {
                    return ColorConverter.ConvertFromString((string)value);
                }
                catch(Exception)
                {
                    return "#FFFFFF";
                }
            }

            return "#FFFFFF";
        }
    }
}
