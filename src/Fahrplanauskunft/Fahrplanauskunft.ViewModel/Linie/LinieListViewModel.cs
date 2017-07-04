// <copyright file="LinieListViewModel.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using Fahrplanauskunft.Objekte;
using Fahrplanauskunft.ViewModelBase;

namespace Fahrplanauskunft.ViewModel.Linie
{
    public class LinieListViewModel : ViewModelBase.ViewModel
    {
        private string filterLinieParameter;
        private ObservableCollection<LinieViewModel> linien;

        private ICommand neueLinieCommand;

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

        public ObservableCollection<LinieViewModel> FilteredList
        {
            get
            {
                return GetFilteredList(Linien);
            }
        }

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

        public static bool FilterLinie(Objekte.Linie linie, string filter)
        {
            if(string.IsNullOrEmpty(filter))
            {
                return true;
            }

            filter = filter.ToLower();
            return linie.Name.ToLower().Contains(filter) || linie.Ident.ToLower().Contains(filter);
        }

        public void ExecuteNeueLinieCommand()
        {
            Linien.Add(new LinieViewModel(new Objekte.Linie()));
        }

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
