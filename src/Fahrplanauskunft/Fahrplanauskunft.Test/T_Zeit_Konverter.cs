using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.Test
{
    [TestClass]
    public class T_Zeit_Konverter
    {
        /// <summary>
        /// Es soll die Funktion ZuUhrzeitText mit dem Wert 120 aufgerufen werden und die Ausgabe soll "02:00" betragen.
        /// </summary>
        [TestMethod]
        public void ZuUhrzeitText_Ganzzahl_120_Text_0200()
        {
            int zeit = 120;

            string expected = "02:00";

            string actual = Fahrplanauskunft.Zeit_Konverter.ZuUhrzeitText(zeit);

            Assert.AreEqual(expected, actual);
       }

        /// <summary>
        /// Es soll die Funktion ZuUhrzeitText mit dem Wert 726 aufgerufen werden und die Ausgabe soll "12:06" betragen.
        /// </summary>
        [TestMethod]
        public void ZuUhrzeitText_Ganzzahl_726_Text_1206()
        {
            int zeit = 726;

            string expected = "12:06";

            string actual = Fahrplanauskunft.Zeit_Konverter.ZuUhrzeitText(zeit);

            Assert.AreEqual(expected, actual);
        }

     }
}
