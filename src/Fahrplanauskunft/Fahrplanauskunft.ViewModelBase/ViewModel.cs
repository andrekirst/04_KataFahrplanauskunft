// <copyright file="ViewModel.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>
// Vorlage: http://www.cocktailsandcode.de/2012/04/mvvm-tutorial-part-3-viewmodelbase-und-relaycommand/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplanauskunft.ViewModelBase
{
    /// <summary>
    /// Die ViewModel-Klasse
    /// </summary>
    public class ViewModel : IViewModel
    {
        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        protected ViewModel()
        {
            Task initializationTask = new Task(() => Initialize());
            initializationTask.ContinueWith(result => InitializationCompletedCallback(result));
            initializationTask.Start();
        }

        /// <summary>
        /// Wird aufgerufen, wenn sich eine eigenschaft ändert
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Wird aufgerufen, wenn die Initiaisierung abgeschlossen ist
        /// </summary>
        public event AsyncCompletedEventHandler InitializationCompleted;

        /// <summary>
        /// Initiailisiert die Instanz
        /// </summary>
        protected virtual void Initialize()
        {
        }

        /// <summary>
        /// Wird aufgerufen, wenn eine Eigenschaft des ViewModel verändert wird
        /// </summary>
        /// <param name="propertyName">Der Name der Eigenschaft</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Callback-Methode für die asynchrone Initialisierung
        /// </summary>
        /// <param name="result">Das Ergebnis des asynchronen Aufrufs</param>
        private void InitializationCompletedCallback(IAsyncResult result)
        {
            AsyncCompletedEventHandler initializationCompleted = InitializationCompleted;
            initializationCompleted?.Invoke(this, new AsyncCompletedEventArgs(null, !result.IsCompleted, result.AsyncState));
        }
    }
}
