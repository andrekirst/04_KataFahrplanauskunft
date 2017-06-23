// <copyright file="T_ViewModel_TModel.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Fahrplanauskunft.Objekte;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void ViewModel_TModel_Linie_Eigenschaft_Name_wurde_veraendert()
        {
            Linie linie = new Linie(name: "B1", ident: "B11");

            LinieViewModel lvm = new LinieViewModel(model: linie);

            lvm.Name = "B12";

            string expected = "B12";
            string actual = lvm.Name;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testet das ViewModel ViewModelLinie, ob das Event PropertyChanged aufgerufen wurde
        /// </summary>
        [TestMethod]
        public void ViewModel_TModel_Linie_Eigenschaft_Name_wurde_veraendert_Event_PropertyChanged_1_mal_aufgerufen()
        {
            List<string> aufgerufeneEvents = new List<string>();

            Linie linie = new Linie(name: "B1", ident: "B11");

            LinieViewModel lvm = new LinieViewModel(model: linie);

            lvm.PropertyChanged += (sender, args) =>
            {
                aufgerufeneEvents.Add(args.PropertyName);
            };

            lvm.Name = "B12";

            const int expected = 1;
            var actual = aufgerufeneEvents.Count;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testet das ViewModel ViewModelLinie, ob das Event PropertyChanged die Eigenschaft Name hat
        /// </summary>
        [TestMethod]
        public void ViewModel_TModel_Linie_Eigenschaft_Name_wurde_veraendert_Event_PropertyChanged_PropertyName_Name()
        {
            List<string> aufgerufeneEvents = new List<string>();

            Linie linie = new Linie(name: "B1", ident: "B11");

            LinieViewModel lvm = new LinieViewModel(model: linie);

            lvm.PropertyChanged += (sender, args) =>
            {
                aufgerufeneEvents.Add(args.PropertyName);
            };

            lvm.Name = "B12";

            const string expected = "Name";
            string actual = aufgerufeneEvents[0];
            Assert.AreEqual(expected, actual);
        }
    }
}
