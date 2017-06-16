// <copyright file="T_ResourceHelper.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System.Globalization;
using System.Threading;
using Fahrplanauskunft.UI.WindowsForms.Editor.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.UI.WindowsForms.Editor.Test.Helper
{
    /// <summary>
    /// Testklasse für die Klasse ResourceHelper
    /// </summary>
    [TestClass]
    public class T_ResourceHelper
    {
        /// <summary>
        /// Testet, ob der Konstruktor die Eigenschaft ResourceManager gesetzt ist
        /// </summary>
        [TestMethod]
        public void ResourceHelper_Konstruktor_Ueberpruefe_ResourceManager()
        {
            ResourceHelper resourceHelper = new ResourceHelper();

            Assert.IsNotNull(resourceHelper.ResourceManager);
        }

        /// <summary>
        /// Testet, ob anhand der Sprache "en-US" der Text "Save" für den Ressourcenident "ButtonTextSpeichern" ausgegeben wird
        /// </summary>
        [TestMethod, TestCategory("Helper")]
        public void ResourceHelper_Sprache_en_US_Erwarte_Text_Save()
        {
            string expected = "Save";

            CultureInfo currentCultureInfo = new CultureInfo(Thread.CurrentThread.CurrentUICulture.LCID);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            ResourceHelper resourceHelper = new ResourceHelper();

            string actual = resourceHelper.RessourcenTextFuerIdent("ButtonTextSpeichern");

            Thread.CurrentThread.CurrentUICulture = currentCultureInfo;

            Assert.AreEqual(expected, actual);
        }
    }
}
