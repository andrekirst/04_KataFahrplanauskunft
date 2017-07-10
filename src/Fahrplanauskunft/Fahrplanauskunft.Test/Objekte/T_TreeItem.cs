// <copyright file="T_TreeItem.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using Fahrplanauskunft.Objekte;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.Test.Objekte
{
    /// <summary>
    /// Testklasse für TreeItem
    /// </summary>
    [TestClass]
    public class T_TreeItem
    {
        /// <summary>
        /// Hilfsmethode für das Erstellen von virtuellen Haltestellen anhand einer ID
        /// </summary>
        /// <param name="id">Die ID der Haltestelle</param>
        /// <returns>Gibt ein Objekt vom Typ <see cref="Haltestelle"/> zurück</returns>
        public Haltestelle TestHaltestelleByID(string id)
        {
            return new Haltestelle(id: id, name: id);
        }

        /// <summary>
        /// Test der Equals-Methode, dass zwei TreeItem mit jeweils einer Haltestelle Name: "H1" gleich sind
        /// </summary>
        [TestMethod]
        public void TreeItem_Equal_1()
        {
            // expected             actual
            // root:       H1       root:       H1

            TreeItem expected = new TreeItem(TestHaltestelleByID("H1"));

            TreeItem actual = new TreeItem(TestHaltestelleByID("H1"));

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

            TreeItem expected = new TreeItem(TestHaltestelleByID("H1"));

            TreeItem actual = new TreeItem(TestHaltestelleByID("H2"));

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

            TreeItem expected = new TreeItem(TestHaltestelleByID("H1"));
            expected.Childs.Add(new TreeItem(TestHaltestelleByID("H4")));
            expected.Childs.Add(new TreeItem(TestHaltestelleByID("H2")));

            TreeItem actual = new TreeItem(TestHaltestelleByID("H1"));
            actual.Childs.Add(new TreeItem(TestHaltestelleByID("H2")));
            actual.Childs.Add(new TreeItem(TestHaltestelleByID("H4")));

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

            TreeItem expected = new TreeItem(TestHaltestelleByID("H1"));
            expected.Childs.Add(new TreeItem(TestHaltestelleByID("H2")));
            expected.Childs.Add(new TreeItem(TestHaltestelleByID("H4")));

            TreeItem actual = new TreeItem(TestHaltestelleByID("H1"));
            actual.Childs.Add(new TreeItem(TestHaltestelleByID("H4")));
            actual.Childs.Add(new TreeItem(TestHaltestelleByID("H5")));

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
            TreeItem ti_2_h8_l = new TreeItem(TestHaltestelleByID("H8"));
            TreeItem ti_2_h8_r = new TreeItem(TestHaltestelleByID("H8"));

            // 1. Ebene
            TreeItem ti_1_h2_l = new TreeItem(TestHaltestelleByID("H2"));
            TreeItem ti_1_h4_r = new TreeItem(TestHaltestelleByID("H4"));

            // Root
            TreeItem ti_root_Haltestelle = new TreeItem(TestHaltestelleByID("H1"));

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
            TreeItem eti_2_h8_l = new TreeItem(TestHaltestelleByID("H8"));
            TreeItem eti_2_h8_r = new TreeItem(TestHaltestelleByID("H8"));

            // 1. Ebene
            TreeItem eti_1_h2_l = new TreeItem(TestHaltestelleByID("H2"));
            TreeItem eti_1_h4_r = new TreeItem(TestHaltestelleByID("H4"));

            // Root
            TreeItem eti_root_Haltestelle = new TreeItem(TestHaltestelleByID("H1"));

            // 1. Ebene --> Root
            eti_root_Haltestelle.Childs.Add(eti_1_h2_l);
            eti_root_Haltestelle.Childs.Add(eti_1_h4_r);

            // 2. Ebene --> 1. Ebene
            eti_1_h2_l.Childs.Add(eti_2_h8_l);
            eti_1_h4_r.Childs.Add(eti_2_h8_r);

            // actual
            // 2. Ebene
            TreeItem ati_2_h8_l = new TreeItem(TestHaltestelleByID("H8"));
            TreeItem ati_2_h10_r = new TreeItem(TestHaltestelleByID("H10"));

            // 1. Ebene
            TreeItem ati_1_h2_l = new TreeItem(TestHaltestelleByID("H2"));
            TreeItem ati_1_h4_r = new TreeItem(TestHaltestelleByID("H4"));

            // Root
            TreeItem ati_root_Haltestelle = new TreeItem(TestHaltestelleByID("H1"));

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

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei gleichen TreeItems
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void TreeItem_Gleichheitsoperator_Gleiches_TreeItem()
        {
            TreeItem treeItem1 = new TreeItem(TestHaltestelleByID("H1"));
            TreeItem treeItem2 = new TreeItem(TestHaltestelleByID("H1"));

            Assert.IsTrue(treeItem1 == treeItem2);
        }

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei verschiedenen TreeItems
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void TreeItem_Gleichheitsoperator_Verschiedene_TreeItem()
        {
            TreeItem treeItem1 = new TreeItem(TestHaltestelleByID("H1"));
            TreeItem treeItem2 = new TreeItem(TestHaltestelleByID("H2"));

            Assert.IsFalse(treeItem1 == treeItem2);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei gleichen TreeItems
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void TreeItem_Ungleichheitsoperator_Gleiches_TreeItem()
        {
            TreeItem treeItem1 = new TreeItem(TestHaltestelleByID("H1"));
            TreeItem treeItem2 = new TreeItem(TestHaltestelleByID("H1"));

            Assert.IsFalse(treeItem1 != treeItem2);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei ungleichen TreeItems
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void TreeItem_Ungleichheitsoperator_Verschiedene_TreeItem()
        {
            TreeItem treeItem1 = new TreeItem(TestHaltestelleByID("H1"));
            TreeItem treeItem2 = new TreeItem(TestHaltestelleByID("H2"));

            Assert.IsTrue(treeItem1 != treeItem2);
        }

        /// <summary>
        /// Testet den HashCode vom TreeItem
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void TreeItem_GetHashCode()
        {
            TreeItem treeItem = new TreeItem(TestHaltestelleByID("H1"));

            int expected = "H1".GetHashCode();

            int actual = treeItem.GetHashCode();

            Assert.AreEqual(expected, actual);
        }
    }
}
