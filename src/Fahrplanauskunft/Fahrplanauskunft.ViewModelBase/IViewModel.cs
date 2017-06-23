// <copyright file="IViewModel.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplanauskunft.ViewModelBase
{
    /// <summary>
    /// Schnittstelle für das ViewModel
    /// </summary>
    public interface IViewModel : INotifyPropertyChanged
    {
    }

    /// <summary>
    /// Schnittstelle für das ViewModel mit dem generischen Parameter für das Model
    /// </summary>
    /// <typeparam name="TModel">Das Model</typeparam>
    public interface IViewModel<TModel> : IViewModel
    {
        /// <summary>
        /// Gibt das Model zurück oder setzt es
        /// </summary>
        [Browsable(false)]
        [Bindable(false)]
        TModel Model
        {
            get;
            set;
        }
    }
}
