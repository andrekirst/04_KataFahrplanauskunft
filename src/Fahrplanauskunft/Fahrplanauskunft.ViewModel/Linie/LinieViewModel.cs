using Fahrplanauskunft.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fahrplanauskunft.Objekte;

namespace Fahrplanauskunft.ViewModel.Linie
{
    public class LinieViewModel : ViewModel<Objekte.Linie>
    {
        public LinieViewModel(Objekte.Linie model)
            : base(model)
        {
        }

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
    }
}
