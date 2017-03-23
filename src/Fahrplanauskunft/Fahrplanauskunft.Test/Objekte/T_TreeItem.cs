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
            // expected             actual
            // root:       H1       root:       H1

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
            // expected             actual
            // root:       H1       root:       H2

            TreeItem expected = new TreeItem(new Haltestelle() { Name = "H1" });

            TreeItem actual = new TreeItem(new Haltestelle() { Name = "H2" });

            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        /// Test der Equals-Methode, dass zwei TreeItem mit jeweils einer Haltestelle Name: "H1" und Childs "H2","H4" bzw. Childs "H4","H2" gleich sind
        /// </summary>
        [TestMethod]
        public void TreeItem_Equal_2()
        {
            // expected             actual
            // root:       H1       root:       H1
            //            /  \                 /  \
            // 1. Ebene:H4 # H2     1. Ebene:H2 # H4

            TreeItem expected = new TreeItem(new Haltestelle() { Name = "H1" });
            expected.Childs.Add(new TreeItem(new Haltestelle() { Name = "H4" }));
            expected.Childs.Add(new TreeItem(new Haltestelle() { Name = "H2" }));

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
            // expected             actual
            // root:       H1       root:       H1
            //            /  \                 /  \
            // 1. Ebene:H2 # H4     1. Ebene:H2 # H5

            TreeItem expected = new TreeItem(new Haltestelle() { Name = "H1" });
            expected.Childs.Add(new TreeItem(new Haltestelle() { Name = "H2" }));
            expected.Childs.Add(new TreeItem(new Haltestelle() { Name = "H4" }));

            TreeItem actual = new TreeItem(new Haltestelle() { Name = "H1" });
            actual.Childs.Add(new TreeItem(new Haltestelle() { Name = "H4" }));
            actual.Childs.Add(new TreeItem(new Haltestelle() { Name = "H5" }));

            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        /// Test der Equals-Methode, dass zwei TreeItem mit jeweils einer Haltestelle Name: "H1", Childs "H2","H4" bzw. Childs "H4","H2" und weitere Grandchildren "H8" gleich sind
        /// </summary>
        [TestMethod]
        public void TreeItem_Equal_3()
        {
            #region Vorbereitung
            // expected           actual
            // root:       H1     root:        H1
            //            /  \                /  \
            // 1. Ebene:H2 # H4   1. Ebene: H2 # H4
            //          |    |              |    |
            // 2. Ebene:H8 # H8   2. Ebene: H8 # H8

            // 2. Ebene
            TreeItem ti_2_h8_l = new TreeItem(new Haltestelle() { Name = "H8" });
            TreeItem ti_2_h8_r = new TreeItem(new Haltestelle() { Name = "H8" });

            // 1. Ebene
            TreeItem ti_1_h2_l = new TreeItem(new Haltestelle() { Name = "H2" });
            TreeItem ti_1_h4_r = new TreeItem(new Haltestelle() { Name = "H4" });

            // Root
            TreeItem ti_root_Haltestelle = new TreeItem(new Haltestelle() { Name = "H1" });
            
            // 1. Ebene --> Root
            ti_root_Haltestelle.Childs.Add(ti_1_h2_l);
            ti_root_Haltestelle.Childs.Add(ti_1_h4_r);

            // 2. Ebene --> 1. Ebene
            ti_1_h2_l.Childs.Add(ti_2_h8_l);
            ti_2_h8_r.Childs.Add(ti_2_h8_r);
            #endregion

            TreeItem expected = ti_root_Haltestelle;
            TreeItem actual = ti_root_Haltestelle;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test der Equals-Methode, dass zwei TreeItem mit einer Haltestelle Name: "H1" , Childs "H2","H4" und einmal ein weiteres Grandchildren "H8"  sowie einmal ein weiteres Grandchildren "H10" sind nicht gleich
        /// </summary>
        [TestMethod]
        public void TreeItem_Not_Equal_3()
        {
            #region Vorbereitung
            // expected             actual
            // root:       H1       root:       H1
            //            /  \                 /  \
            // 1. Ebene:H2 # H4     1. Ebene:H2 # H4
            //          |    |               |    |
            // 2. Ebene:H8 # H8     2. Ebene:H8 # H10

            // expected
            // 2. Ebene
            TreeItem eti_2_h8_l = new TreeItem(new Haltestelle() { Name = "H8" });
            TreeItem eti_2_h8_r = new TreeItem(new Haltestelle() { Name = "H8" });

            // 1. Ebene
            TreeItem eti_1_h2_l = new TreeItem(new Haltestelle() { Name = "H2" });
            TreeItem eti_1_h4_r = new TreeItem(new Haltestelle() { Name = "H4" });

            // Root
            TreeItem eti_root_Haltestelle = new TreeItem(new Haltestelle() { Name = "H1" });

            // 1. Ebene --> Root
            eti_root_Haltestelle.Childs.Add(eti_1_h2_l);
            eti_root_Haltestelle.Childs.Add(eti_1_h4_r);

            // 2. Ebene --> 1. Ebene
            eti_1_h2_l.Childs.Add(eti_2_h8_l);
            eti_1_h4_r.Childs.Add(eti_2_h8_r);

            // actual
            // 2. Ebene
            TreeItem ati_2_h8_l = new TreeItem(new Haltestelle() { Name = "H8" });
            TreeItem ati_2_h10_r = new TreeItem(new Haltestelle() { Name = "H10" });

            // 1. Ebene
            TreeItem ati_1_h2_l = new TreeItem(new Haltestelle() { Name = "H2" });
            TreeItem ati_1_h4_r = new TreeItem(new Haltestelle() { Name = "H4" });

            // Root
            TreeItem ati_root_Haltestelle = new TreeItem(new Haltestelle() { Name = "H1" });

            // 1. Ebene --> Root
            ati_root_Haltestelle.Childs.Add(ati_1_h2_l);
            ati_root_Haltestelle.Childs.Add(ati_1_h4_r);

            // 2. Ebene --> 1. Ebene
            ati_1_h2_l.Childs.Add(ati_2_h8_l);
            ati_1_h4_r.Childs.Add(ati_2_h10_r);
            #endregion

            TreeItem expected = eti_root_Haltestelle;
            TreeItem actual = ati_root_Haltestelle;

            Assert.AreNotEqual(expected, actual);
        }
    }
}
