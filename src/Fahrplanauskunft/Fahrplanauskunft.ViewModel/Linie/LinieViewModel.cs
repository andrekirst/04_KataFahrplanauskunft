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
        public string Name
        {
            get
            {
                return Model.Name;
            }

            set
            {
                if(Name != value)
                {
                    Model.Name = value;
                    this.OnPropertyChanged(nameof(Name));
                }
            }
        }

        /// <summary>
        /// Gibt den Ident der Linie zurück, oder setzt diesen
        /// </summary>
        public string Ident
        {
            get
            {
                return Model.Ident;
            }

            set
            {
                if(Ident != value)
                {
                    Model.Ident = value;
                    this.OnPropertyChanged(nameof(Ident));
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
        public int AnzahlHaltestellen { get; set; }
    }
}
