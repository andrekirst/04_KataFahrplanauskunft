using System.Collections.Generic;

namespace Fahrplanauskunft.Objekte
{
    /// <summary>
    /// Eine Haltestelle ist ein Punkt, an denen ein- und ausgestiegen werden kann.
    /// </summary>
    public class Haltestelle
    {
        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public Haltestelle()
        {
            Linien = new List<Linie>();
        }

        /// <summary>
        /// Konstruktor mit dem Namen der Haltestelle
        /// </summary>
        /// <param name="name">Der Name der Haltestelle</param>
        public Haltestelle(string name)
            : this()
        {
            Name = name;
        }

        /// <summary>
        /// Die Linien, die der Haltestelle zugeordnet sind
        /// </summary>
        public List<Linie> Linien { get; set; }

        /// <summary>
        /// Gibt den Namen der Haltestelle zurück, oder setzt ihn
        /// </summary>
        public string Name { get; set; }
    }
}
