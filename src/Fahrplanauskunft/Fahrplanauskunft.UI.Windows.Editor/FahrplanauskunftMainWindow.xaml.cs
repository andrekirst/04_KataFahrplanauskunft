// <copyright file="FahrplanauskunftMainWindow.xaml.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Fahrplanauskunft.Objekte;
using Fahrplanauskunft.UI.Windows.Editor.Objekte.Linie;
using Fahrplanauskunft.ViewModel.Linie;

namespace Fahrplanauskunft.UI.Windows.Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FahrplanauskunftMainWindow : Window
    {
        FahrplanauskunftSpeicher speicher = new FahrplanauskunftSpeicher("");
        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public FahrplanauskunftMainWindow()
        {
            InitializeComponent();

            SetzeRessourcen();

            // TODO
            PrototypTest();
        }

        private void PrototypTest()
        {
            speicher.Linien = HoleTestLinien();

            var viewModel = new LinieListViewModel(speicher);
            linieListView.DataContext = viewModel;

            //string[] colors = new string[] { "#FF4500", "#FFDAB9", "#66CDAA", "#FFD700", "#6B8E23", "#32CD32" };
            //string[] fg = new string[colors.Length];
            //for(int i = 0; i < colors.Length; i++)
            //{
            //    Color color = (Color)ColorConverter.ConvertFromString(colors[i]);
            //    fg[i] = Color.FromArgb((byte)255, (byte)~color.R, (byte)~color.G, (byte)~color.B).ToString();
            //}

            //List<Linie> linien = HoleTestLinien();

            //var items = from linie in linien
            //            select new
            //            {
            //                Name = linie.Name,
            //                Ident = linie.Ident,
            //                AnzahlHaltestellen = 20,
            //                AnzahlStreckenabschnitte = 20,
            //                AnzahlHaltestellenfahrplaneintraege = 1000,
            //                Farbe = colors[int.Parse(new Regex("[^0-9 -]").Replace(linie.Name, string.Empty)) - 1],
            //                Schriftfarbe = fg[int.Parse(new Regex("[^0-9 -]").Replace(linie.Name, string.Empty)) - 1]
            //            };

            //ListBoxLinien.ItemsSource = items;
        }

        private List<Linie> HoleTestLinien()
        {
            List<Linie> linien = new List<Linie>();
            linien.Add(new Linie(name: "1", ident: "B11"));
            linien.Add(new Linie(name: "1", ident: "B12"));
            linien.Add(new Linie(name: "2", ident: "B21"));
            linien.Add(new Linie(name: "2", ident: "B22"));
            linien.Add(new Linie(name: "3", ident: "B31"));
            linien.Add(new Linie(name: "3", ident: "B32"));

            linien.Add(new Linie(name: "4", ident: "B41"));
            linien.Add(new Linie(name: "4", ident: "B42"));
            linien.Add(new Linie(name: "5", ident: "B51"));
            linien.Add(new Linie(name: "5", ident: "B52"));
            linien.Add(new Linie(name: "6", ident: "B61"));
            linien.Add(new Linie(name: "6", ident: "B62"));
            return linien;
        }

        /// <summary>
        /// Gibt den Text des TabPage-Control tabPageLinie zurück
        /// </summary>
        public string TabItemLinieText
        {
            get
            {
                return ((TabItemLinie.Header as Grid).Children[0] as TextBlock).Text;
            }
        }

        /// <summary>
        /// Methode für das Setzen der Ressourcen
        /// </summary>
        internal void SetzeRessourcen()
        {
            ResourceDictionary dict = new ResourceDictionary();

            const string uriTemplate = "pack://application:,,,/Fahrplanauskunft.UI.Windows.Editor;component/Resources/Resources{0}.xaml";

            switch(Thread.CurrentThread.CurrentUICulture.ToString())
            {
                case "en-US":
                    {
                        dict.Source = new Uri(string.Format(uriTemplate, ".en-US"), UriKind.Absolute);
                        break;
                    }

                case "de-DE":
                    {
                        dict.Source = new Uri(string.Format(uriTemplate, ".de-DE"), UriKind.Absolute);
                        break;
                    }

                default:
                    {
                        dict.Source = new Uri(string.Format(uriTemplate, string.Empty), UriKind.Absolute);
                        break;
                    }
            }

            this.Resources.MergedDictionaries.Add(dict);
        }

        private void TextBoxsucheingabeLinie_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            //string[] colors = new string[] { "#FF4500", "#FFDAB9", "#66CDAA", "#FFD700", "#6B8E23", "#32CD32" };
            //string[] fg = new string[colors.Length];
            //for(int i = 0; i < colors.Length; i++)
            //{
            //    Color color = (Color)ColorConverter.ConvertFromString(colors[i]);
            //    fg[i] = Color.FromArgb((byte)255, (byte)~color.R, (byte)~color.G, (byte)~color.B).ToString();
            //}

            //List<Linie> linien = new InteraktorSucheLinie().Suche_Linie(TextBoxsucheingabeLinie.Text, HoleTestLinien());

            //var items = from linie in linien
            //            select new
            //            {
            //                Name = linie.Name,
            //                Ident = linie.Ident,
            //                AnzahlHaltestellen = 20,
            //                AnzahlStreckenabschnitte = 20,
            //                AnzahlHaltestellenfahrplaneintraege = 1000,
            //                Farbe = colors[int.Parse(new Regex("[^0-9 -]").Replace(linie.Name, string.Empty)) - 1],
            //                Schriftfarbe = fg[int.Parse(new Regex("[^0-9 -]").Replace(linie.Name, string.Empty)) - 1]
            //            };

            //ListBoxLinien.ItemsSource = items;
        }

        private void ListBoxLinien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Type type = e.AddedItems[0].GetType();
            string ident = (string)type.GetProperty("Ident").GetValue(e.AddedItems[0], null);
            string name = (string)type.GetProperty("Name").GetValue(e.AddedItems[0], null);

            Linie linie = new Linie(ident: ident, name: name);

            Grid_Bearbeitungsmaske.DataContext = linie;
        }
    }
}
