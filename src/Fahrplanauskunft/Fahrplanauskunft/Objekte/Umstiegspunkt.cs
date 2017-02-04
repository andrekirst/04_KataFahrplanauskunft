using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplanauskunft.Objekte
{
    public class Umstiegspunkt
    {
        public Umstiegspunkt()
        {
        }
        public Umstiegspunkt(Haltestelle haltestelle)
        {
            Haltestelle = haltestelle;
            Name = haltestelle.Name;
        }

        /// <summary>
        /// Gibt die Haltestelle zurück
        /// </summary>
        public Haltestelle Haltestelle { get; private set; }

        /// <summary>
        /// Name des Umstiegspunkt
        /// </summary>
        public string Name { get; set; }

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
            Umstiegspunkt other = obj as Umstiegspunkt;
            return this.Name == other.Name;
        }

        /// <summary>
        /// Gibt den HashCode zurück
        /// </summary>
        /// <returns>Der HashCode</returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
