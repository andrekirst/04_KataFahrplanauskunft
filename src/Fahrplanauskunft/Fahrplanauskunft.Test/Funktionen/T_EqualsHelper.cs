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
        /// Test, wenn der Parameter obj den Wert Null hat, die Methode false zurückgeben muss
        /// </summary>
        [TestMethod, TestCategory("EqualsHelper")]
        public void EqualsHelper_Parameter_obj_Ist_Null()
        {
            bool expected = false;
            bool actual = EqualsHelper.EqualBase<Linie>(null, null);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, wenn der Parameter obj einen anderen Typ hat, als der Typ T vorgibt, muss false zurückgegeben werden
        /// </summary>
        [TestMethod]
        public void EqualsHelper_Paramter_obj_falscher_Typ()
        {
            Haltestelle haltestelle = new Haltestelle();

            bool expected = false;

            bool actual = EqualsHelper.EqualBase<Linie>(haltestelle, null);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, wenn der Paramater custom Null ist, dass die Methode false zurückgeben muss
        /// </summary>
        [TestMethod]
        public void EqualsHelper_Paramter_custom_Ist_Null()
        {
            Linie linie = new Linie(); ;

            bool expected = false;

            bool actual = EqualsHelper.EqualBase<Linie>(linie, null);

            Assert.AreEqual(expected, actual);
        }
    }
}
