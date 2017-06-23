// <copyright file="HaltestelleViewModel.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
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
        /// Gibt den Namen der Linie zurück bzw. setzt diesen
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
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
    }
}
