// <copyright file="ViewModel.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>
// Vorlage: http://www.cocktailsandcode.de/2012/04/mvvm-tutorial-part-3-viewmodelbase-und-relaycommand/

using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Fahrplanauskunft.Objekte;
using System.Diagnostics;

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
        /// <param name="fahrplanauskunftSpeicher">Der FahrplanauskunftSpeicher</param>
        protected ViewModel(FahrplanauskunftSpeicher fahrplanauskunftSpeicher)
        {
            FahrplanauskunftSpeicher = fahrplanauskunftSpeicher;
            Task initializationTask = new Task(() => Initialize());
            initializationTask.ContinueWith(result => InitializationCompletedCallback(result));
            initializationTask.Start();
        }

        /// <summary>
        /// Wird aufgerufen, wenn sich eine Eigenschaft ändert
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Wird aufgerufen, wenn die Initiaisierung abgeschlossen ist
        /// </summary>
        public event AsyncCompletedEventHandler InitializationCompleted;

        /// <summary>
        /// Gibt den FahrplanauskunftSpeicher zurück
        /// </summary>
        public FahrplanauskunftSpeicher FahrplanauskunftSpeicher
        {
            get;
            set;
        }

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
            string debugMessage = $"{DateTime.Now} - {propertyName}";
            Debug.WriteLine(debugMessage);
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
