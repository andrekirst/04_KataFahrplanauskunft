// <copyright file="LinieListViewModel.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using Fahrplanauskunft.Objekte;
using Fahrplanauskunft.ViewModelBase;
using System.Windows.Controls;

namespace Fahrplanauskunft.ViewModel.Linie
{
    /// <summary>
    /// ViewModel für eine Liste des VideModel <see cref="LinieViewModel"/>
    /// </summary>
    public class LinieListViewModel : ViewModelBase.ViewModel
    {
        private string filterLinieParameter;
        private ObservableCollection<LinieViewModel> linien;

        private ICommand neueLinieCommand;
        private ICommand escapeInputCommand;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="fahrplanauskunftSpeicher">Der FahrplanauskunftSpeicher</param>
        public LinieListViewModel(FahrplanauskunftSpeicher fahrplanauskunftSpeicher)
            : base(fahrplanauskunftSpeicher)
        {
            linien = new ObservableCollection<LinieViewModel>(FahrplanauskunftSpeicher.Linien.Select(p =>
                new LinieViewModel(p)
                {
                    AnzahlHaltestellen = fahrplanauskunftSpeicher.Haltestellen.Count(h => h.Linien.Contains(p))
                }));
            linien.CollectionChanged += Linien_CollectionChanged;
        }

        /// <summary>
        /// gibt die gefilterte Liste anhand der FilterParameter zurück
        /// </summary>
        public ObservableCollection<LinieViewModel> FilteredList
        {
            get
            {
                return GetFilteredList(Linien);
            }
        }

        /// <summary>
        /// Gibt den Der Filterparameter für die Suche nach den Linien zurück, oder setzt diesen
        /// </summary>
        public string FilterLinieParameter
        {
            get
            {
                return filterLinieParameter;
            }

            set
            {
                if(filterLinieParameter != value)
                {
                    filterLinieParameter = value;
                    OnPropertyChanged(nameof(FilterLinie));
                    OnPropertyChanged(nameof(FilteredList));
                }
            }
        }

        /// <summary>
        /// Die Orignalliste der Linien
        /// </summary>
        public ObservableCollection<LinieViewModel> Linien
        {
            get
            {
                return linien;
            }

            set
            {
                if(Linien != value)
                {
                    linien = value;
                    OnPropertyChanged(nameof(Linien));
                }
            }
        }

        /// <summary>
        /// Das Kommando für eine neue Linie
        /// </summary>
        public ICommand NeueLinieCommand
        {
            get
            {
                if(neueLinieCommand == null)
                {
                    neueLinieCommand = new RelayCommand(p => ExecuteNeueLinieCommand());
                }

                return neueLinieCommand;
            }
        }

        public ICommand EscapeInputCommand
        {
            get
            {
                if(escapeInputCommand == null)
                {
                    escapeInputCommand = new RelayCommand(p => ExecuteEscapeInputCommand(p));
                }

                return escapeInputCommand;
            }
        }

        /// <summary>
        /// Führt die Aktion aus, wenn das Kommando <see cref="NeueLinieCommand"/> aufgerufen wird
        /// </summary>
        public void ExecuteNeueLinieCommand()
        {
            Linien.Add(new LinieViewModel(new Objekte.Linie()));
        }

        public void ExecuteEscapeInputCommand(object parameter = null)
        {
            if(parameter != null && parameter is TextBox)
            {
                (parameter as TextBox).Text = string.Empty;
            }

            FilterLinieParameter = string.Empty;
        }

        /// <summary>
        /// Der angewandte Filter für die Suche nach Linien für eine einzelne <see cref="Objekte.Linie"/>
        /// Wenn der Parameter <paramref name="filter"/> null oder leer ist, wird true zurückgegeben.
        /// Der Parameter <paramref name="filter"/> wird vor dem Vergleich mit den Attributen <see cref="Objekte.Linie.Ident"/> und <see cref="Objekte.Linie.Name"/> auf Kleinbuchstaben transformiert. Danach werden diese jeweils mit Kleinbuchstaben verglichen, wenn der Text innerhalb der Attribute mittels <see cref="string.Contains(string)"/> verglichen.
        /// </summary>
        /// <param name="linie">Die aktuelle <see cref="Objekte.Linie"/>, die überprüft wird</param>
        /// <param name="filter">Der angeandte Filte</param>
        /// <returns>Gibt true zurück, wenn der Filter übereinstimmt. Andernfalls false</returns>
        internal static bool FilterLinie(Objekte.Linie linie, string filter)
        {
            if(string.IsNullOrEmpty(filter))
            {
                return true;
            }

            filter = filter.ToLower();
            return linie.Name.ToLower().Contains(filter) || linie.Ident.ToLower().Contains(filter);
        }

        /// <summary>
        /// Hilfsfunktion für das Bereitstellen der gefilterten Liste
        /// </summary>
        /// <param name="original">Die Original-Liste</param>
        /// <returns>gibt die gefilterte Menge anhand der Parameter zurück</returns>
        private ObservableCollection<LinieViewModel> GetFilteredList(ObservableCollection<LinieViewModel> original)
        {
            ObservableCollection<LinieViewModel> filteredList = new ObservableCollection<LinieViewModel>();

            var x = from p in original
                    where FilterLinie(p.Model, this.FilterLinieParameter)
                    select p;

            foreach(var u in x)
            {
                filteredList.Add(u);
            }

            return filteredList;
        }

        /// <summary>
        /// Die Implementierung, wenn die ObservableCollection geändert wurde
        /// </summary>
        /// <param name="sender">Das Objekt, dass das Event aufgerufen hat</param>
        /// <param name="e">Die Ereignisargumente</param>
        private void Linien_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach(LinieViewModel vm in e.NewItems)
                {
                    FahrplanauskunftSpeicher.Linien.Add(vm.Model);
                }
            }
            else if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach(LinieViewModel vm in e.OldItems)
                {
                    FahrplanauskunftSpeicher.Linien.Remove(vm.Model);
                }
            }
            else if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Reset)
            {
                FahrplanauskunftSpeicher.Linien.Clear();
            }
        }
    }
}
