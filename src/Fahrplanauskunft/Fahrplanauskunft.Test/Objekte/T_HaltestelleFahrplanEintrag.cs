// <copyright file="T_HaltestelleFahrplanEintrag.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using Fahrplanauskunft.Objekte;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.Test.Objekte
{
    /// <summary>
    /// Testklasse für HaltestelleFahrplanEintrag
    /// </summary>
    [TestClass]
    public class T_HaltestelleFahrplanEintrag
    {
        /// <summary>
        /// Test, ob die Haltestelle nicht NULL ist, dass die Uhrzeit den Wert "750" hat und die Linie nicht NULL ist.
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Konstruktor_Haltestelle_NICHT_NULL_Uhrzeit_750_Linie_NICHT_NULL()
        {
            Haltestelle haltestelle = new Haltestelle(name: "Haltestelle1", id: "1");
            Linie linie = new Linie(name: "U1", ident: "U1_NORD", farbe: "#FF4500", id: "1");

            HaltestelleFahrplanEintrag haltestelleFahrplanEintrag = new HaltestelleFahrplanEintrag(haltestelle: haltestelle, uhrzeit: 750, linie: linie, id: "1");

            Assert.IsNotNull(haltestelleFahrplanEintrag.Haltestelle);
            Assert.AreEqual(750, haltestelleFahrplanEintrag.Uhrzeit);
            Assert.IsNotNull(haltestelleFahrplanEintrag.Linie);
        }

        /// <summary>
        /// Test, dass die Equals-Methode zwei Haltestellenfahrplaneinträge verschiedener Instanzen mit jeweils der Uhrzeit von 720, Linie U1 und Haltestelle H1 als den gleichen Haltestellenfahrplaneintrag identifiziert
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void HaltestellenFahrplanEintrag_Equals_Uhrzeit_720_Linie_U1_Haltestelle_H1()
        {
            HaltestelleFahrplanEintrag hfe1 = new HaltestelleFahrplanEintrag()
            {
                Uhrzeit = 720,
                Haltestelle = new Haltestelle(name: "H1", id: "1"),
                Linie = new Linie(name: "U1", ident: "U1_NORD", farbe: "#FF4500", id: "1"),
                ID = "1"
            };

            HaltestelleFahrplanEintrag hfe2 = new HaltestelleFahrplanEintrag()
            {
                Uhrzeit = 720,
                Haltestelle = new Haltestelle(name: "H1", id: "1"),
                Linie = new Linie(name: "U1", ident: "U1_NORD", farbe: "#FF4500", id: "1"),
                ID = "1"
            };

            Assert.IsTrue(hfe1.Equals(hfe2));
        }

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei gleichen Haltestellenfahrplaneinträge
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void HaltestellenFahrplanEintrag_Gleichheitsoperator_Gleiches_Objekt()
        {
            HaltestelleFahrplanEintrag hfe1 = new HaltestelleFahrplanEintrag()
            {
                Uhrzeit = 720,
                Haltestelle = new Haltestelle(name: "H1", id: "1"),
                Linie = new Linie(name: "U1", ident: "U1_NORD", farbe: "#FF4500", id: "1"),
                ID = "1"
            };

            HaltestelleFahrplanEintrag hfe2 = new HaltestelleFahrplanEintrag()
            {
                Uhrzeit = 720,
                Haltestelle = new Haltestelle(name: "H1", id: "1"),
                Linie = new Linie(name: "U1", ident: "U1_NORD", farbe: "#FF4500", id: "1"),
                ID = "1"
            };

            Assert.IsTrue(hfe1 == hfe2);
        }

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei ungleichen Haltestellenfahrplaneinträge
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void HaltestellenFahrplanEintrag_Gleichheitsoperator_Ungleiches_Objekt()
        {
            HaltestelleFahrplanEintrag hfe1 = new HaltestelleFahrplanEintrag()
            {
                Uhrzeit = 720,
                Haltestelle = new Haltestelle(name: "H1", id: "1"),
                Linie = new Linie(name: "U1", ident: "U1_NORD", farbe: "#FF4500", id: "1"),
                ID = "1"
            };

            HaltestelleFahrplanEintrag hfe2 = new HaltestelleFahrplanEintrag()
            {
                Uhrzeit = 720,
                Haltestelle = new Haltestelle(name: "H2", id: "2"),
                Linie = new Linie(name: "U1", ident: "U1_NORD", farbe: "#FF4500", id: "1"),
                ID = "2"
            };

            Assert.IsFalse(hfe1 == hfe2);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei gleichen Haltestellenfahrplaneinträgen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void HaltestellenFahrplanEintrag_Ungleichheitsoperator_Gleiches_Objekt()
        {
            HaltestelleFahrplanEintrag hfe1 = new HaltestelleFahrplanEintrag()
            {
                Uhrzeit = 720,
                Haltestelle = new Haltestelle(name: "H1", id: "1"),
                Linie = new Linie(name: "U1", ident: "U1_NORD", farbe: "#FF4500", id: "1"),
                ID = "1"
            };

            HaltestelleFahrplanEintrag hfe2 = new HaltestelleFahrplanEintrag()
            {
                Uhrzeit = 720,
                Haltestelle = new Haltestelle(name: "H1", id: "1"),
                Linie = new Linie(name: "U1", ident: "U1_NORD", farbe: "#FF4500", id: "1"),
                ID = "1"
            };

            Assert.IsFalse(hfe1 != hfe2);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei ungleichen Haltestellenfahrplaneinträgen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void HaltestellenFahrplanEintrage_Ungleichheitsoperator_Verschiedene_Haltestellenname()
        {
            HaltestelleFahrplanEintrag hfe1 = new HaltestelleFahrplanEintrag()
            {
                Uhrzeit = 720,
                Haltestelle = new Haltestelle(name: "H1", id: "1"),
                Linie = new Linie(name: "U1", ident: "U1_NORD", farbe: "#FF4500", id: "1"),
                ID = "1"
            };

            HaltestelleFahrplanEintrag hfe2 = new HaltestelleFahrplanEintrag()
            {
                Uhrzeit = 720,
                Haltestelle = new Haltestelle(name: "H2", id: "2"),
                Linie = new Linie(name: "U1", ident: "U1_NORD", farbe: "#FF4500", id: "1"),
                ID = "1"
            };

            Assert.IsTrue(hfe1 != hfe2);
        }
    }
}
