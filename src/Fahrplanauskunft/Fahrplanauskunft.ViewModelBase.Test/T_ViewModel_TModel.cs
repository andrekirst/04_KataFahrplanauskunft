// <copyright file="T_ViewModel_TModel.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Fahrplanauskunft.Objekte;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Fahrplanauskunft.ViewModelBase.Test
{
    /// <summary>
    /// Test-Klasse für das ViewModel mit dem generischen Parameter für das Model
    /// </summary>
    [TestClass]
    public class T_ViewModel_TModel
    {
        /// <summary>
        /// Testet das ViewModel ViewModelLinie, ob die Eigenschaft Name sich verändert
        /// </summary>
        [TestMethod]
        [TestCategory(@"ViewModelBase")]
        public void ViewModel_TModel_Linie_Eigenschaft_Name_wurde_veraendert()
        {
            LinieViewModel lvm = new LinieViewModel(model: new Objekte.Linie(id: "B11", nummer: "B1", lauf: "B11", farbe: "#FF4500"));

            lvm.Nummer = "B12";

            const string expected = "B12";
            string actual = lvm.Nummer;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testet das ViewModel ViewModelLinie, ob das Event PropertyChanged aufgerufen wurde
        /// </summary>
        [TestMethod]
        [TestCategory(@"ViewModelBase")]
        public void ViewModel_TModel_Linie_Eigenschaft_Nummer_wurde_veraendert_Event_PropertyChanged_1_mal_aufgerufen()
        {
            List<string> aufgerufeneEvents = new List<string>();

            LinieViewModel lvm = new LinieViewModel(model: new Objekte.Linie(id: "B11", nummer: "B1", lauf: "B11", farbe: "#FF4500"));

            lvm.PropertyChanged += (sender, args) =>
            {
                aufgerufeneEvents.Add(args.PropertyName);
            };

            lvm.Nummer = "B12";

            const int expected = 1;
            var actual = aufgerufeneEvents.Count;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testet das ViewModel ViewModelLinie, ob das Event PropertyChanged die Eigenschaft Name hat
        /// </summary>
        [TestMethod]
        [TestCategory(@"ViewModelBase")]
        public void ViewModel_TModel_Linie_Eigenschaft_Nummer_wurde_veraendert_Event_PropertyChanged_PropertyName_Name()
        {
            List<string> aufgerufeneEvents = new List<string>();

            LinieViewModel lvm = new LinieViewModel(model: new Objekte.Linie(id: "B11", nummer: "B1", lauf: "B11", farbe: "#FF4500"));

            lvm.PropertyChanged += (sender, args) =>
            {
                aufgerufeneEvents.Add(args.PropertyName);
            };

            lvm.Nummer = "B12";

            const string expected = "Nummer";
            string actual = aufgerufeneEvents[0];
            Assert.AreEqual(expected, actual);
        }
    }
}
