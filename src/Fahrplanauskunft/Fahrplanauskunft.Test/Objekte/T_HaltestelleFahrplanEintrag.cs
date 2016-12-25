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
        [TestMethod]
        public void Konstruktor_Haltestelle_NICHT_NULL_Uhrzeit_750_Linie_NICHT_NULL()
        {
            Haltestelle haltestelle = new Haltestelle(name: "Haltestelle1");
            Linie linie = new Linie(name: "U1", ident: "U1_NORD");

            HaltestelleFahrplanEintrag haltestelleFahrplanEintrag = new HaltestelleFahrplanEintrag(haltestelle: haltestelle, uhrzeit: 750, linie: linie);

            Assert.IsNotNull(haltestelleFahrplanEintrag.Haltestelle);
            Assert.AreEqual(750, haltestelleFahrplanEintrag.Uhrzeit);
            Assert.IsNotNull(haltestelleFahrplanEintrag.Linie);
        }
    }
}
