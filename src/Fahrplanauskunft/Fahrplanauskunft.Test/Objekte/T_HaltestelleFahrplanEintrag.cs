using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fahrplanauskunft.Objekte;

namespace Fahrplanauskunft.Test.Objekte
{
    /// <summary>
    /// Summary description for T_HaltestelleFahrplanEintrag
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
            Haltestelle haltestelle = new Haltestelle(name: "Haltestelle1");
            Linie linie = new Linie(name: "U1", ident: "U1_NORD");

            HaltestelleFahrplanEintrag haltestelleFahrplanEintrag = new HaltestelleFahrplanEintrag(haltestelle: haltestelle, uhrzeit: 750, linie: linie);

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
                Haltestelle = new Haltestelle(name: "H1"),
                Linie = new Linie(name: "U1", ident: "U1_NORD")
            };

            HaltestelleFahrplanEintrag hfe2 = new HaltestelleFahrplanEintrag()
            {
                Uhrzeit = 720,
                Haltestelle = new Haltestelle(name: "H1"),
                Linie = new Linie(name: "U1", ident: "U1_NORD")
            };

            Assert.IsTrue(hfe1 == hfe2);
        }
    }
}
