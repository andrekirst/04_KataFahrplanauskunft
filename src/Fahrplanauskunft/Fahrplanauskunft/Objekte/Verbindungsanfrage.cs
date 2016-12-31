using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplanauskunft.Objekte
{
    public class Verbindungsanfrage
    {
        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public Verbindungsanfrage()
        {

        }

        /// <summary>
        /// Konstruktor mit Start- und Ziel-Haltestelle, sowie der gewünschten Abfahrtszeit
        /// </summary>
        /// <param name="startHaltestelle">Die Start-Haltestelle, bei der man beginnen möchte</param>
        /// <param name="zielHaltestelle">Die Ziel-Haltestelle, zu der man transportiert werden möchte</param>
        /// <param name="wunschAbfahrtszeit">Die gewünschte Abfahrtszeit</param>
        public Verbindungsanfrage(Haltestelle startHaltestelle, Haltestelle zielHaltestelle, int wunschAbfahrtszeit)
        {
            StartHaltestelle = startHaltestelle;
            ZielHaltestelle = zielHaltestelle;
            WunschAbfahrtszeit = wunschAbfahrtszeit;
        }

        /// <summary>
        /// Die Start-Haltestelle, bei der man beginnen möchte
        /// </summary>
        public Haltestelle StartHaltestelle
        {
            get;
            set;
        }

        /// <summary>
        /// Die gewünschte Abfahrtszeit
        /// </summary>
        public int WunschAbfahrtszeit
        {
            get;
            set;
        }

        /// <summary>
        /// Die Ziel-Haltestelle, zu der man transportiert werden möchte
        /// </summary>
        public Haltestelle ZielHaltestelle
        {
            get;
            set;
        }
    }
}
