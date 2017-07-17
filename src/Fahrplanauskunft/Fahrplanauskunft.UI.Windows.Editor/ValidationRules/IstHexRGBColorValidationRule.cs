// <copyright file="IstHexRGBColorValidationRule.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System.Globalization;
using System.Windows.Controls;
using Fahrplanauskunft.Funktionen;

namespace Fahrplanauskunft.UI.Windows.Editor.ValidationRules
{
    public class IstHexRGBColorValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            // TODO
            // Ressource für Fehlermeldung
            return new ValidationResult(FarbeHelper.IstFarbeGueltig(value as string), "Keine gültige Farbe");
        }
    }
}
