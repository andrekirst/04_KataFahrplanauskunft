// <copyright file="FahrplanauskunftMainWindow.xaml.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using Fahrplanauskunft.Objekte;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace Fahrplanauskunft.UI.Windows.Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FahrplanauskunftMainWindow : Window
    {
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
            string[] colors = new string[] { "#FF4500", "#FFDAB9", "#66CDAA", "#FFD700", "#6B8E23", "#32CD32" };
            string[] fg = new string[colors.Length];
            for(int i = 0; i < colors.Length; i++)
            {
                Color color = (Color)ColorConverter.ConvertFromString(colors[i]);
                fg[i] = Color.FromArgb((byte)255, (byte)~color.R, (byte)~color.G, (byte)~color.B).ToString();
            }

            List<Linie> linien = new List<Linie>();
            linien.Add(new Linie(name: "B1", ident: "B11"));
            linien.Add(new Linie(name: "B1", ident: "B12"));
            linien.Add(new Linie(name: "B2", ident: "B21"));
            linien.Add(new Linie(name: "B2", ident: "B22"));
            linien.Add(new Linie(name: "B3", ident: "B31"));
            linien.Add(new Linie(name: "B3", ident: "B32"));

            linien.Add(new Linie(name: "B4", ident: "B41"));
            linien.Add(new Linie(name: "B4", ident: "B42"));
            linien.Add(new Linie(name: "B5", ident: "B51"));
            linien.Add(new Linie(name: "B5", ident: "B52"));
            linien.Add(new Linie(name: "B6", ident: "B61"));
            linien.Add(new Linie(name: "B6", ident: "B62"));

            var items = from linie in linien
                        select new
                        {
                            Name = linie.Name,
                            Ident = linie.Ident,
                            AnzahlHaltestellen = new Random().Next(10, 20),
                            AnzahlStreckenabschnitte = new Random().Next(10, 20),
                            AnzahlHaltestellenfahrplaneintraege = new Random().Next(1000, 1500),
                            Farbe = colors[int.Parse(new Regex("[^0-9 -]").Replace(linie.Name, string.Empty)) - 1],
                            Schriftfarbe = fg[int.Parse(new Regex("[^0-9 -]").Replace(linie.Name, string.Empty)) - 1]
                        };

            listBoxLinien.ItemsSource = items;
        }

        /// <summary>
        /// Gibt den Text des TabPage-Control tabPageLinie zurück
        /// </summary>
        public string TabItemLinieText
        {
            get
            {
                return tabItemLinie.Header as string;
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
    }
}
