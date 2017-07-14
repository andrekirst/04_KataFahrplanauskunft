// <copyright file="FarbeHelper.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Windows.Media;

namespace Fahrplanauskunft.UI.Windows.View.Helper
{
    public static class FarbeHelper
    {
        public static string BerechneVordergrundfarbeAnhandHintergrundfarbe(string farbe)
        {
            try
            {
                Color colorDatatype = (Color)ColorConverter.ConvertFromString(farbe);

                int sumFarbe = (int)colorDatatype.R + (int)colorDatatype.G + (int)colorDatatype.B;

                return sumFarbe < 420 ? "#FFFFFF" : "#000000";
            }
            catch(FormatException)
            {
                return "#000000";
            }
        }
    }
}
