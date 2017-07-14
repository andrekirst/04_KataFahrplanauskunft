// <copyright file="ForegroundColorDetectionConverter.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Globalization;
using System.Windows.Data;
using Fahrplanauskunft.UI.Windows.View.Helper;
using System.Windows.Media;

namespace Fahrplanauskunft.UI.Windows.View.Converters
{
    public class ForegroundColorDetectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string)
            {
                string colorValue = value as string;
                return FarbeHelper.BerechneVordergrundfarbeAnhandHintergrundfarbe(colorValue);
            }
            else
            {
                if(targetType == typeof(Brush))
                {
                    return FarbeHelper.BerechneVordergrundfarbeAnhandHintergrundfarbe("#FFFFFF");
                }

                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
