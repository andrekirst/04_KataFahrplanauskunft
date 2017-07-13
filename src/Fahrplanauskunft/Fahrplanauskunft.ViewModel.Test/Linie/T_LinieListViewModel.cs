﻿// <copyright file="T_LinieListViewModel.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Fahrplanauskunft.Objekte;
using Fahrplanauskunft.ViewModel.Linie;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.ViewModel.Test.Linie
{
    [TestClass]
    public class T_LinieListViewModel
    {
        public static List<Objekte.Linie> HoleTestDaten()
        {
            List<Objekte.Linie> linien = new List<Objekte.Linie>();
            linien.Add(new Objekte.Linie(id: "B11", nummer: "B1", lauf: "B11", farbe: "#FF4500"));
            linien.Add(new Objekte.Linie(id: "B12", nummer: "B1", lauf: "B12", farbe: "#FF4500"));
            linien.Add(new Objekte.Linie(id: "B21", nummer: "B2", lauf: "B21", farbe: "#FFDAB9"));
            linien.Add(new Objekte.Linie(id: "B22", nummer: "B2", lauf: "B22", farbe: "#FFDAB9"));
            linien.Add(new Objekte.Linie(id: "B31", nummer: "B3", lauf: "B31", farbe: "#66CDAA"));
            linien.Add(new Objekte.Linie(id: "B32", nummer: "B3", lauf: "B32", farbe: "#66CDAA"));
            linien.Add(new Objekte.Linie(id: "B41", nummer: "B4", lauf: "B41", farbe: "#FFD700"));
            linien.Add(new Objekte.Linie(id: "B42", nummer: "B4", lauf: "B42", farbe: "#FFD700"));
            linien.Add(new Objekte.Linie(id: "B51", nummer: "B5", lauf: "B51", farbe: "#6B8E23"));
            linien.Add(new Objekte.Linie(id: "B52", nummer: "B5", lauf: "B52", farbe: "#6B8E23"));
            linien.Add(new Objekte.Linie(id: "B61", nummer: "B6", lauf: "B61", farbe: "#32CD32"));
            linien.Add(new Objekte.Linie(id: "B62", nummer: "B6", lauf: "B62", farbe: "#32CD32"));
            return linien;
        }

        [TestMethod]
        public void LinieListViewModel_FilteredList_FilterLinieParameter_B1()
        {
            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(string.Empty);

            fahrplanauskunftSpeicher.Linien = HoleTestDaten();
            fahrplanauskunftSpeicher.Haltestellenfahrplaneintraege = new List<HaltestelleFahrplanEintrag>();
            fahrplanauskunftSpeicher.Streckenabschnitte = new List<Streckenabschnitt>();
            fahrplanauskunftSpeicher.Haltestellen = new List<Haltestelle>();
            Haltestelle h = new Haltestelle(id: "H1", name: "H1");
            h.Linien = fahrplanauskunftSpeicher.Linien.Where(l => l.Nummer == "H1").ToList();
            fahrplanauskunftSpeicher.Haltestellen.Add(h);

            LinieListViewModel llvm = new LinieListViewModel(fahrplanauskunftSpeicher);
            llvm.FilterLinieParameter = "B1";

            ObservableCollection<LinieViewModel> expected = new ObservableCollection<LinieViewModel>();
            expected.Add(new LinieViewModel(new Objekte.Linie(id: "B11", nummer: "B1", lauf: "B11", farbe: "#FF4500")));
            expected.Add(new LinieViewModel(new Objekte.Linie(id: "B12", nummer: "B1", lauf: "B12", farbe: "#FF4500")));

            ObservableCollection<LinieViewModel> actual = llvm.FilteredList;

            equalidator.Equalidator.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LinieListViewModel_EscapeInputCommand_Escape_Eingabe_FilteredList_Gleich_Linien()
        {
            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(string.Empty);

            fahrplanauskunftSpeicher.Linien = HoleTestDaten();
            fahrplanauskunftSpeicher.Streckenabschnitte = new List<Streckenabschnitt>();
            fahrplanauskunftSpeicher.Haltestellenfahrplaneintraege = new List<HaltestelleFahrplanEintrag>();
            fahrplanauskunftSpeicher.Haltestellen = new List<Haltestelle>();
            Haltestelle h = new Haltestelle(id: "H1", name: "H1");
            h.Linien = fahrplanauskunftSpeicher.Linien.Where(l => l.Nummer == "B1").ToList();
            fahrplanauskunftSpeicher.Haltestellen.Add(h);

            LinieListViewModel llvm = new LinieListViewModel(fahrplanauskunftSpeicher);
            llvm.FilterLinieParameter = "B1";

            llvm.ExecuteEscapeInputCommand();

            ObservableCollection<LinieViewModel> actual = llvm.FilteredList;
            ObservableCollection<LinieViewModel> expected = llvm.Linien;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LinieListViewModel_EscapeInputCommand_Escape_Eingabe_FilterParameter_Gleich_Empty()
        {
            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(string.Empty);

            fahrplanauskunftSpeicher.Linien = HoleTestDaten();
            fahrplanauskunftSpeicher.Streckenabschnitte = new List<Streckenabschnitt>();
            fahrplanauskunftSpeicher.Haltestellenfahrplaneintraege = new List<HaltestelleFahrplanEintrag>();
            fahrplanauskunftSpeicher.Haltestellen = new List<Haltestelle>();
            Haltestelle h = new Haltestelle(id: "H1", name: "H1");
            h.Linien = fahrplanauskunftSpeicher.Linien.Where(l => l.Lauf == "H1").ToList();
            fahrplanauskunftSpeicher.Haltestellen.Add(h);

            LinieListViewModel llvm = new LinieListViewModel(fahrplanauskunftSpeicher);
            llvm.FilterLinieParameter = "B1";

            llvm.ExecuteEscapeInputCommand();

            string expected = string.Empty;
            string actual = llvm.FilterLinieParameter;

            Assert.AreEqual(expected, actual);
        }
    }
}
