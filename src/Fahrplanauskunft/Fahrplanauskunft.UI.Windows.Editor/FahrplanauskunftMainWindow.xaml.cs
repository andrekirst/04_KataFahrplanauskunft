// <copyright file="FahrplanauskunftMainWindow.xaml.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Fahrplanauskunft.Objekte;
using Fahrplanauskunft.ViewModel.Linie;

namespace Fahrplanauskunft.UI.Windows.Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FahrplanauskunftMainWindow : Window
    {
        private FahrplanauskunftSpeicher speicher = new FahrplanauskunftSpeicher("../../../Fahrplanauskunft.Test/bin/Debug/TestDaten/TestSatzBrainstorming");
        //private FahrplanauskunftSpeicher speicher = new FahrplanauskunftSpeicher("");

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

        private static ICommand schliesseAnwendungCommand;
        private static ICommand oeffneFahrplanauskunftSpeicherDialogCommand;

        private void ExecuteOeffneFahrplanauskunftSpeicherDialogCommand(object sender, ExecutedRoutedEventArgs args)
        {
        }

        public void ExecuteSchliesseAnwendungCommand(object sender, ExecutedRoutedEventArgs args)
        {
            this.Close();
        }

        private void PrototypTest()
        {
            // TODO
            speicher.Laden();

            //var viewModel = new LinieListViewModel(speicher);
            //linieListView.DataContext = viewModel;

            var viewModel = new LinieListViewModel(speicher);
            //this.DataContext = viewModel;
            TabItemLinie.DataContext = viewModel;

            //Linie linie = new Linie();
            //LinieViewModel lvm = new LinieViewModel(linie);

            //Grid_Bearbeitungsmaske.DataContext = viewModel.SelectedLinie;
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

        public static ICommand OeffneFahrplanauskunftSpeicherDialogCommand
        {
            get
            {
                if(oeffneFahrplanauskunftSpeicherDialogCommand == null)
                {
                    oeffneFahrplanauskunftSpeicherDialogCommand = new RoutedUICommand(
                        nameof(OeffneFahrplanauskunftSpeicherDialogCommand),
                        nameof(OeffneFahrplanauskunftSpeicherDialogCommand),
                        typeof(FahrplanauskunftMainWindow),
                        new InputGestureCollection() { new KeyGesture(Key.O, ModifierKeys.Control) });
                }

                return oeffneFahrplanauskunftSpeicherDialogCommand;
            }
        }

        public static ICommand SchliesseAnwendungCommand
        {
            get
            {
                if(schliesseAnwendungCommand == null)
                {
                    schliesseAnwendungCommand = new RoutedUICommand(
                        nameof(SchliesseAnwendungCommand),
                        nameof(SchliesseAnwendungCommand),
                        typeof(FahrplanauskunftMainWindow),
                        new InputGestureCollection() { new KeyGesture(Key.F4, ModifierKeys.Alt) });
                }

                return schliesseAnwendungCommand;
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
