using Fahrplanauskunft.Objekte;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.Test.Objekte
{
    /// <summary>
    /// Test-Klasse für das Objekt Umstiegspunkt
    /// </summary>
    [TestClass]
    public class T_Umstiegspunkt
    {
        /// <summary>
        /// Test der Equals-Methode, dass zwei Umstiegspunkt gleich sind. Name: "Test"
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Umstiegspunkt_Equals_Name_Test()
        {
            string name = "Test";
            Umstiegspunkt actual = new Umstiegspunkt(new Haltestelle(name));

            string name2 = "Test";
            Umstiegspunkt expected = new Umstiegspunkt(new Haltestelle(name2));

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, dass die Rückgabe Name: H4 ist, wenn der Name der Umstiegspunkt H4 ist.
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Umstiegspunkt_ToString()
        {
            Umstiegspunkt umstiegspunkt = new Umstiegspunkt(new Haltestelle("H4"));

            string expected = "Name: H4";

            string actual = umstiegspunkt.ToString();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei gleichen Umstiegspunkten
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Umstiegspunkt_Gleichheitsoperator_Gleiche_Umstiegspunkte()
        {
            Umstiegspunkt umstiegspunkt1 = new Umstiegspunkt(new Haltestelle("H1"));
            Umstiegspunkt umstiegspunkt2 = new Umstiegspunkt(new Haltestelle("H1"));

            Assert.IsTrue(umstiegspunkt1 == umstiegspunkt2);
        }

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei verschiedenen Umstiegspunkten
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Umstiegspunkt_Gleichheitsoperator_Verschiedene_Umstiegspunkte()
        {
            Umstiegspunkt umstiegspunkt1 = new Umstiegspunkt(new Haltestelle("H1"));
            Umstiegspunkt umstiegspunkt2 = new Umstiegspunkt(new Haltestelle("H2"));

            Assert.IsFalse(umstiegspunkt1 == umstiegspunkt2);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei gleichen Umstiegspunkten
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Umstiegspunkt_Ungleichheitsoperator_Gleiche_Umstiegspunkte()
        {
            Umstiegspunkt umstiegspunkt1 = new Umstiegspunkt(new Haltestelle("H1"));
            Umstiegspunkt umstiegspunkt2 = new Umstiegspunkt(new Haltestelle("H1"));

            Assert.IsFalse(umstiegspunkt1 != umstiegspunkt2);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei ungleichen Umstiegspunkten
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Umstiegspunkt_Ungleichheitsoperator_Verschiedene_Umstiegspunkte()
        {
            Umstiegspunkt umstiegspunkt1 = new Umstiegspunkt(new Haltestelle("H1"));
            Umstiegspunkt umstiegspunkt2 = new Umstiegspunkt(new Haltestelle("H2"));

            Assert.IsTrue(umstiegspunkt1 != umstiegspunkt2);
        }
    }
}