using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplanauskunft.Objekte
{
    internal class TreeItem
    {
        public TreeItem(Haltestelle haltestelle) : this()
        {
            this.Haltestelle = haltestelle;
        }

        private TreeItem()
        {
            Childs = new List<TreeItem>();
        }

        /// <summary>
        /// Die Buechersaetze unterhalb des aktuellen
        /// </summary>
        internal List<TreeItem> Childs { get; set; }

        internal Haltestelle Haltestelle { get; private set; }


        /// <summary>
        /// Vergleicht die Haltestelle mit einem anderen Objekt
        /// </summary>
        /// <param name="obj">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException();
            }
            TreeItem other = obj as TreeItem;
            return this.Haltestelle.Equals(other.Haltestelle);
        }

        /// <summary>
        /// Gibt den HashCode zurück
        /// </summary>
        /// <returns>Der HashCode</returns>
        public override int GetHashCode()
        {
            return Haltestelle.GetHashCode();
        }

    }
}
