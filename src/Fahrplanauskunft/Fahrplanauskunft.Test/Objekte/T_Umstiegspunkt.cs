using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fahrplanauskunft.Objekte;
using System.Linq;

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
    }
}