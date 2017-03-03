using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fahrplanauskunft.Funktionen;
using Fahrplanauskunft.Objekte;
using System.Linq;

namespace Fahrplanauskunft.Test.Objekte
{
    /// <summary>
    /// Summary description for T_TreeItem
    /// </summary>
    [TestClass]
    public class T_TreeItem
    {
        /// <summary>
        /// Test der Equals-Methode, dass zwei TreeItem mit jeweils einer Haltestelle Name: "H1" gleich sind
        /// </summary>
        [TestMethod]
        public void TreeItem_Equal_1()
        {
            TreeItem expected = new TreeItem(new Haltestelle() { Name = "H1" });

            TreeItem actual = new TreeItem(new Haltestelle() { Name = "H1" });

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test der Equals-Methode, dass zwei TreeItem mit jeweils einer Haltestelle Name: "H1" bzw. "H2" nicht gleich sind
        /// </summary>
        [TestMethod]
        public void TreeItem_Not_Equal_1()
        {
            TreeItem expected = new TreeItem(new Haltestelle() { Name = "H1" });

            TreeItem actual = new TreeItem(new Haltestelle() { Name = "H2" });

            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        /// Test der Equals-Methode, dass zwei TreeItem mit jeweils einer Haltestelle Name: "H1" und Childs "H2","H4" gleich sind
        /// </summary>
        [TestMethod]
        public void TreeItem_Equal_2()
        {
            TreeItem expected = new TreeItem(new Haltestelle() { Name = "H1" });
            expected.Childs.Add(new TreeItem(new Haltestelle() { Name = "H2" }));
            expected.Childs.Add(new TreeItem(new Haltestelle() { Name = "H4" }));

            TreeItem actual = new TreeItem(new Haltestelle() { Name = "H1" });
            actual.Childs.Add(new TreeItem(new Haltestelle() { Name = "H2" }));
            actual.Childs.Add(new TreeItem(new Haltestelle() { Name = "H4" }));

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test der Equals-Methode, dass zwei TreeItem mit einer Haltestelle Name: "H1" und Childs "H2","H4" sowie "H2","H5" nicht gleich sind
        /// </summary>
        [TestMethod]
        public void TreeItem_Not_Equal_2()
        {
            TreeItem expected = new TreeItem(new Haltestelle() { Name = "H1" });
            expected.Childs.Add(new TreeItem(new Haltestelle() { Name = "H2" }));
            expected.Childs.Add(new TreeItem(new Haltestelle() { Name = "H4" }));

            TreeItem actual = new TreeItem(new Haltestelle() { Name = "H1" });
            actual.Childs.Add(new TreeItem(new Haltestelle() { Name = "H2" }));
            actual.Childs.Add(new TreeItem(new Haltestelle() { Name = "H5" }));

            Assert.AreNotEqual(expected, actual);
        }



        //#region Vorbereitung
        //List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

        //// root:       H1
        ////            /  \
        //// 1. Ebene:H2 # H4
        ////          |    |
        //// 2. Ebene:H8 # H8

        //// 2. Ebene
        //TreeItem ti_2_h8_l = new TreeItem(haltestellen.First(h => h.Name == "H8"));
        //TreeItem ti_2_h8_r = new TreeItem(haltestellen.First(h => h.Name == "H8"));

        //// 1. Ebene
        //TreeItem ti_1_h2_l = new TreeItem(haltestellen.First(h => h.Name == "H2"));
        //TreeItem ti_1_h4_r = new TreeItem(haltestellen.First(h => h.Name == "H4"));

        //// Root
        //TreeItem ti_root_Haltestelle = new TreeItem(haltestellen.First(h => h.Name == "H1"));

        //// 1. Ebene --> Root
        //ti_root_Haltestelle.Childs.Add(ti_1_h2_l);
        //    ti_root_Haltestelle.Childs.Add(ti_1_h4_r);

        //    // 2. Ebene --> 1. Ebene
        //    ti_1_h2_l.Childs.Add(ti_2_h8_l);
        //    ti_2_h8_r.Childs.Add(ti_2_h8_r);
        //    #endregion

        //    TreeItem expected = ti_root_Haltestelle;
    }
}
