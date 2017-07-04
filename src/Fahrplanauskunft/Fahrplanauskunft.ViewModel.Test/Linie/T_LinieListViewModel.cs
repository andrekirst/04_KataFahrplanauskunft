﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fahrplanauskunft.ViewModel.Linie;
using Fahrplanauskunft.Objekte;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Fahrplanauskunft.ViewModel.Test.Linie
{
    [TestClass]
    public class T_LinieListViewModel
    {
        public static List<Objekte.Linie> HoleTestDaten()
        {
            List<Objekte.Linie> linien = new List<Objekte.Linie>();
            linien.Add(new Objekte.Linie(name: "B1", ident: "B11", farbe: "#FF4500"));
            linien.Add(new Objekte.Linie(name: "B1", ident: "B12", farbe: "#FF4500"));
            linien.Add(new Objekte.Linie(name: "B2", ident: "B21", farbe: "#FFDAB9"));
            linien.Add(new Objekte.Linie(name: "B2", ident: "B22", farbe: "#FFDAB9"));
            linien.Add(new Objekte.Linie(name: "B3", ident: "B31", farbe: "#66CDAA"));
            linien.Add(new Objekte.Linie(name: "B3", ident: "B32", farbe: "#66CDAA"));

            linien.Add(new Objekte.Linie(name: "B4", ident: "B41", farbe: "#FFD700"));
            linien.Add(new Objekte.Linie(name: "B4", ident: "B42", farbe: "#FFD700"));
            linien.Add(new Objekte.Linie(name: "B5", ident: "B51", farbe: "#6B8E23"));
            linien.Add(new Objekte.Linie(name: "B5", ident: "B52", farbe: "#6B8E23"));
            linien.Add(new Objekte.Linie(name: "B6", ident: "B61", farbe: "#32CD32"));
            linien.Add(new Objekte.Linie(name: "B6", ident: "B62", farbe: "#32CD32"));
            return linien;
        }

        [TestMethod]
        public void LinieListViewModel_FilteredList_FilterLinieParameter_B1()
        {
            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(string.Empty);

            fahrplanauskunftSpeicher.Linien = HoleTestDaten();

            LinieListViewModel llvm = new LinieListViewModel(fahrplanauskunftSpeicher);
            llvm.FilterLinieParameter = "B1";

            ObservableCollection<LinieViewModel> expected = new ObservableCollection<LinieViewModel>();
            expected.Add(new LinieViewModel(new Objekte.Linie(name: "B1", ident: "B11", farbe: "#FF4500")));
            expected.Add(new LinieViewModel(new Objekte.Linie(name: "B1", ident: "B12", farbe: "#FF4500")));

            ObservableCollection<LinieViewModel> actual = llvm.FilteredList;

            equalidator.Equalidator.AreEqual(expected, actual);
        }
    }
}
