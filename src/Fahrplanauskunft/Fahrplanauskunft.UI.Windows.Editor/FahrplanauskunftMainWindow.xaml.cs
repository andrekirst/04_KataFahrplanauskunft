// <copyright file="FahrplanauskunftMainWindow.xaml.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System.Windows;
using Fahrplanauskunft.UI.Windows.Editor.Helper;

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

            ResourceHelper = new ResourceHelper();

            SetzeRessourcen();
        }

        /// <summary>
        /// Eigenschaft für den ResourceHelper
        /// </summary>
        public ResourceHelper ResourceHelper
        {
            get;
            set;
        }

        /// <summary>
        /// Methode für das Setzen der Ressourcen
        /// </summary>
        internal void SetzeRessourcen()
        {
            // tabPageLinie.Text = ResourceHelper.RessourcenTextFuerIdent("tabPageTextLinie");
        }
    }
}
