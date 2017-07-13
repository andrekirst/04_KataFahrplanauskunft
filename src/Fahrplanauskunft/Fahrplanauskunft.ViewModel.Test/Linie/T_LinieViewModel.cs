// <copyright file="T_LinieViewModel.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Fahrplanauskunft.ViewModel.Linie;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.ViewModel.Test.Linie
{
    [TestClass]
    public class T_LinieViewModel
    {
        private static readonly Objekte.Linie LinieB11 = new Objekte.Linie(id: "B11", nummer: "B1", lauf: "B11", farbe: "#FF4500");

        [TestMethod]
        public void LinieViewModel_Eigenschaft_Get_Farbe()
        {
            LinieViewModel lvm = new LinieViewModel(LinieB11);

            string expected = "#FF4500";

            string actual = lvm.Farbe;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LinieViewModel_Eigenschaft_Get_Name()
        {
            LinieViewModel lvm = new LinieViewModel(LinieB11);

            string expected = "B1";

            string actual = lvm.Nummer;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LinieViewModel_Eigenschaft_Get_Ident()
        {
            LinieViewModel lvm = new LinieViewModel(LinieB11);

            string expected = "B11";

            string actual = lvm.Lauf;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LinieViewModel_Eigenschaft_Set_Lauf()
        {
            List<string> aufgerufeneEvents = new List<string>();

            LinieViewModel lvm = new LinieViewModel(model: LinieB11);

            lvm.PropertyChanged += (sender, args) =>
            {
                aufgerufeneEvents.Add(args.PropertyName);
            };

            lvm.Lauf = "B12";

            const string expected = "Lauf";
            string actual = aufgerufeneEvents[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LinieViewModel_Eigenschaft_Set_Nummer()
        {
            List<string> aufgerufeneEvents = new List<string>();

            LinieViewModel lvm = new LinieViewModel(model: LinieB11);

            lvm.PropertyChanged += (sender, args) =>
            {
                aufgerufeneEvents.Add(args.PropertyName);
            };

            lvm.Nummer = "B2";

            const string expected = "Nummer";
            string actual = aufgerufeneEvents[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LinieViewModel_Eigenschaft_Set_Farbe()
        {
            List<string> aufgerufeneEvents = new List<string>();

            LinieViewModel lvm = new LinieViewModel(model: LinieB11);

            lvm.PropertyChanged += (sender, args) =>
            {
                aufgerufeneEvents.Add(args.PropertyName);
            };

            lvm.Farbe = "#123456";

            const string expected = "Farbe";
            string actual = aufgerufeneEvents[0];
            Assert.AreEqual(expected, actual);
        }
    }
}
