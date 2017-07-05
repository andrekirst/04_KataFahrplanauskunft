// <copyright file="T_LinieListView.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fahrplanauskunft.UI.Windows.View.Linie;

namespace Fahrplanauskunft.UI.Windows.View.Test.Linie
{
    [TestClass]
    public class T_LinieListView
    {
        [TestMethod]
        public void LinieListView_Eingabe_Escape_Setzt_den_Filter_zurueck_auf_leeren_String()
        {
            LinieListView llv = new LinieListView();

            Assert.Fail();
        }
    }
}
