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
        [TestMethod]
        public void LinieViewModel_Eigenschaft_Get_Farbe()
        {
            Objekte.Linie linie = new Objekte.Linie(name: "B1", ident: "B11", farbe: "#FF4500");
            LinieViewModel lvm = new LinieViewModel(linie);

            string expected = "#FF4500";

            string actual = lvm.Farbe;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LinieViewModel_Eigenschaft_Get_Name()
        {
            Objekte.Linie linie = new Objekte.Linie(name: "B1", ident: "B11", farbe: "#FF4500");
            LinieViewModel lvm = new LinieViewModel(linie);

            string expected = "B1";

            string actual = lvm.Name;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LinieViewModel_Eigenschaft_Get_Ident()
        {
            Objekte.Linie linie = new Objekte.Linie(name: "B1", ident: "B11", farbe: "#FF4500");
            LinieViewModel lvm = new LinieViewModel(linie);

            string expected = "B11";

            string actual = lvm.Ident;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LinieViewModel_Eigenschaft_Set_Ident()
        {
            List<string> aufgerufeneEvents = new List<string>();

            Objekte.Linie linie = new Objekte.Linie(name: "B1", ident: "B11", farbe: "#FF4500");

            LinieViewModel lvm = new LinieViewModel(model: linie);

            lvm.PropertyChanged += (sender, args) =>
            {
                aufgerufeneEvents.Add(args.PropertyName);
            };

            lvm.Ident = "B12";

            const string expected = "Ident";
            string actual = aufgerufeneEvents[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LinieViewModel_Eigenschaft_Set_Name()
        {
            List<string> aufgerufeneEvents = new List<string>();

            Objekte.Linie linie = new Objekte.Linie(name: "B1", ident: "B11", farbe: "#FF4500");

            LinieViewModel lvm = new LinieViewModel(model: linie);

            lvm.PropertyChanged += (sender, args) =>
            {
                aufgerufeneEvents.Add(args.PropertyName);
            };

            lvm.Name = "B2";

            const string expected = "Name";
            string actual = aufgerufeneEvents[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LinieViewModel_Eigenschaft_Set_Farbe()
        {
            List<string> aufgerufeneEvents = new List<string>();

            Objekte.Linie linie = new Objekte.Linie(name: "B1", ident: "B11", farbe: "#FF4500");

            LinieViewModel lvm = new LinieViewModel(model: linie);

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
