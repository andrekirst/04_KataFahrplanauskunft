using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fahrplanauskunft.Funktionen;
using Fahrplanauskunft.Objekte;

namespace Fahrplanauskunft.Test.Funktionen
{
    /// <summary>
    /// Test-Klasse für EqualsHelper
    /// </summary>
    [TestClass]
    public class T_EqualsHelper
    {
        /// <summary>
        /// Wenn der Parameter obj den Wert Null hat, muss die Methode den Wert false zurückgeben
        /// </summary>
        [TestMethod, TestCategory("EqualsHelper")]
        public void EqualsHelper_Parameter_obj_Ist_Null()
        {
            bool expected = false;
            bool actual = EqualsHelper.EqualBase<Linie>(null, null);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Wenn der Parameter obj einen anderen Typ hat, als es der Typ T vorgibt, muss die Methode false zurückgegeben
        /// </summary>
        [TestMethod, TestCategory("EqualsHelper")]
        public void EqualsHelper_Paramter_obj_falscher_Typ()
        {
            Haltestelle haltestelle = new Haltestelle();

            bool expected = false;

            bool actual = EqualsHelper.EqualBase<Linie>(haltestelle, null);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Wenn der Paramater custom Null ist, muss die Methode false zurückgeben
        /// </summary>
        [TestMethod, TestCategory("EqualsHelper")]
        public void EqualsHelper_Paramter_custom_Ist_Null()
        {
            Linie linie = new Linie(); ;

            bool expected = false;

            bool actual = EqualsHelper.EqualBase<Linie>(linie, null);

            Assert.AreEqual(expected, actual);
        }
    }
}
