// <copyright file="T_LinieListView.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System.Linq;
using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fahrplanauskunft.UI.Windows.View.Linie;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using Fahrplanauskunft.ViewModel.Linie;
using Fahrplanauskunft.Objekte;

namespace Fahrplanauskunft.UI.Windows.View.Test.Linie
{
    /// <summary>
    /// Test-Klasse für LinieListView
    /// </summary>
    [TestClass]
    public class T_LinieListView
    {
        private List<Objekte.Linie> HoleTestLinien()
        {
            List<Objekte.Linie> linien = new List<Objekte.Linie>();
            linien.Add(new Objekte.Linie(name: "1", ident: "B11", farbe: "#FF4500"));
            linien.Add(new Objekte.Linie(name: "1", ident: "B12", farbe: "#FF4500"));
            linien.Add(new Objekte.Linie(name: "2", ident: "B21", farbe: "#FFDAB9"));
            linien.Add(new Objekte.Linie(name: "2", ident: "B22", farbe: "#FFDAB9"));
            linien.Add(new Objekte.Linie(name: "3", ident: "B31", farbe: "#66CDAA"));
            linien.Add(new Objekte.Linie(name: "3", ident: "B32", farbe: "#66CDAA"));
            linien.Add(new Objekte.Linie(name: "4", ident: "B41", farbe: "#FFD700"));
            linien.Add(new Objekte.Linie(name: "4", ident: "B42", farbe: "#FFD700"));
            return linien;
        }

        [TestMethod]
        public void LinieListView_TextBoxSuche_EscapeInputCommand_Text_Gleich_Empty()
        {
            Window w = new Window();
            w.Content = new LinieListView();

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(string.Empty);
            fahrplanauskunftSpeicher.Linien = HoleTestLinien();

            fahrplanauskunftSpeicher.Haltestellen = new List<Haltestelle>();
            Haltestelle haltestelle = new Haltestelle(name: "H1");
            haltestelle.Linien = fahrplanauskunftSpeicher.Linien.Where(l => l.Ident.StartsWith("B1")).ToList();
            fahrplanauskunftSpeicher.Haltestellen.Add(haltestelle);

            LinieListViewModel llvm = new LinieListViewModel(fahrplanauskunftSpeicher);
            LinieListView llv = w.Content as LinieListView;
            llv.DataContext = llvm;
            w.Show();

            InputBinding inputbindingEsc = llv.TextBoxSuche.InputBindings.Cast<InputBinding>().First(ib => (ib.Gesture as KeyGesture).Key == Key.Escape);
            ICommand command = inputbindingEsc.Command;

            llv.TextBoxSuche.Focus();
            llv.TextBoxSuche.Text = "B1";

            command.Execute(inputbindingEsc.CommandParameter);

            string actual = llv.TextBoxSuche.Text;
            string expected = string.Empty;

            Assert.AreEqual(expected, actual);
        }
    }
}
