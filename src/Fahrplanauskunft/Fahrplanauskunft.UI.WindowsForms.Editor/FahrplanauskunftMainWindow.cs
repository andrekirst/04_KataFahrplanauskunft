// <copyright file="FahrplanauskunftMainWindow.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Windows.Forms;
using Fahrplanauskunft.UI.WindowsForms.Editor.Helper;

namespace Fahrplanauskunft.UI.WindowsForms.Editor
{
    /// <summary>
    /// Standardform (wird demnächst entfernt)
    /// </summary>
    public partial class FahrplanauskunftMainWindow : Form
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
        /// Gibt den DockStyle des Controls tabControlObjekte zurück
        /// </summary>
        internal DockStyle DockStyleTabControlObjekte
        {
            get
            {
                return tabControlObjekte.Dock;
            }
        }

        /// <summary>
        /// Text des TabPage-Control tabPageLinie
        /// </summary>
        internal string TabPageLinieText
        {
            get
            {
                return tabPageLinie.Text;
            }
        }

        /// <summary>
        /// Methode für das Setzen der Ressourcen
        /// </summary>
        internal void SetzeRessourcen()
        {
            tabPageLinie.Text = ResourceHelper.RessourcenTextFuerIdent("tabPageTextLinie");
        }
    }
}
