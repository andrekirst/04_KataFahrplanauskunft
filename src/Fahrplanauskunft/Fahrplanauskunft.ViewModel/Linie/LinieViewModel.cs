// <copyright file="LinieViewModel.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using Fahrplanauskunft.ViewModelBase;

namespace Fahrplanauskunft.ViewModel.Linie
{
    /// <summary>
    /// ViewModel-Klasse für Objekt Linie
    /// </summary>
    public class LinieViewModel : ViewModel<Objekte.Linie>
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="model">Das dazugehörige Model</param>
        public LinieViewModel(Objekte.Linie model)
            : base(model)
        {
        }

        /// <summary>
        /// Gibt den Namen der Linie zurück, oder setzt diesen
        /// </summary>
        public string Nummer
        {
            get
            {
                return Model.Nummer;
            }

            set
            {
                if(Nummer != value)
                {
                    Model.Nummer = value;
                    this.OnPropertyChanged(nameof(Nummer));
                }
            }
        }

        /// <summary>
        /// Gibt den Ident der Linie zurück, oder setzt diesen
        /// </summary>
        public string Lauf
        {
            get
            {
                return Model.Lauf;
            }

            set
            {
                if(Lauf != value)
                {
                    Model.Lauf = value;
                    this.OnPropertyChanged(nameof(Lauf));
                }
            }
        }

        /// <summary>
        /// Gibt die Farbe der Linie zurück, oder setzt diesen
        /// </summary>
        public string Farbe
        {
            get
            {
                return Model.Farbe;
            }

            set
            {
                if(Farbe != value)
                {
                    Model.Farbe = value;
                    this.OnPropertyChanged(nameof(Farbe));
                }
            }
        }

        /// <summary>
        /// Gibt die Anzahl der Haltestellen, die der Linie zugeordnet sind, zurück, oder setzt diese
        /// </summary>
        public int AnzahlHaltestellen
        {
            get;
            set;
        }

        public int AnzahlStreckenabschnitte
        {
            get;
            set;
        }

        public int AnzahlHaltestellenfahrplaneintraege
        {
            get;
            set;
        }
    }
}
