using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplanauskunft.Objekte
{
    /// <summary>
    /// Hierarchische Struktur von möglichen Umstiegspunkten von einer Haltestelle
    /// </summary>
    internal class TreeItem
    {
        /// <summary>
        /// Konstruktor für die Angabe der Haltstelle
        /// </summary>
        /// <param name="haltestelle">Haltestelle</param>
        public TreeItem(Haltestelle haltestelle) : this()
        {
            this.Haltestelle = haltestelle;
        }

        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        private TreeItem()
        {
            Childs = new List<TreeItem>();
        }

        /// <summary>
        /// Die TreeItems unterhalb des aktuellen
        /// </summary>
        public List<TreeItem> Childs { get; set; }

        /// <summary>
        /// Verweis auf die Hallstelle (Wurzel)
        /// </summary>
        public Haltestelle Haltestelle { get; private set; }


        /// <summary>
        /// Vergleicht das TreeItem mit einem anderen Objekt
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

            bool equal = true;

            equal = equal == this.Haltestelle.Equals(other.Haltestelle);
            if (this.Childs.Count == 0 && other.Childs.Count == 0)
            {
                equal = equal == true;
            }
            else
            {
                // Reihefolge spielt keine Rolle, wir sortieren vorher
                equal = equal == this.Childs.OrderBy(x => x.Haltestelle.Name).SequenceEqual(other.Childs.OrderBy(x => x.Haltestelle.Name));
            }

            return equal;
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
