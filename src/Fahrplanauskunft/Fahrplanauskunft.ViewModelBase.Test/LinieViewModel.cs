// <copyright file="LinieViewModel.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using Fahrplanauskunft.Objekte;

namespace Fahrplanauskunft.ViewModelBase.Test
{
    /// <summary>
    /// Test-Klasse HaltestelleViewModel
    /// </summary>
    public class LinieViewModel : ViewModel<Linie>
    {
        /// <summary>
        /// Konstruktor mit der Angabe einer Linie als Model
        /// </summary>
        /// <param name="model">Das Model</param>
        public LinieViewModel(Linie model)
            : base(model)
        {
        }

        /// <summary>
        /// Gibt die Nummer der Linie zurück bzw. setzt diesen
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
                    OnPropertyChanged(nameof(Nummer));
                }
            }
        }
    }
}
