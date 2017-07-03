// <copyright file="RelayCommand.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Fahrplanauskunft.ViewModelBase
{
    /// <summary>
    /// Klasse für das Command-Pattern
    /// </summary>
    [Serializable]
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Die Aktion für da ausführen
        /// </summary>
        private readonly Action<object> execute;

        /// <summary>
        /// Die Überprüfung, ob das Kommando ausgeführt werden kann, oder nicht
        /// </summary>
        private readonly Predicate<object> canExecute;

        /// <summary>
        /// Initialisiert eine neue Instanz der Klasse <see cref="RelayCommand"/>
        /// </summary>
        /// <param name="execute">Die Ausführung</param>
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initialisiert eine neue Instanz der Klasse <see cref="RelayCommand"/>
        /// </summary>
        /// <param name="execute">Die Ausführung</param>
        /// <param name="canExecute">Die Überprüfung, ob die ausführung ausgeführt wird</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if(execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Wird aufgerufen, wenn sich das Event ändert
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Findet heraus, ob das Kommando ausgeführt werden kann
        /// </summary>
        /// <param name="parameter">Der Parameter</param>
        /// <returns>Wenn das Kommando ausgeführt werden kann, true. andernflass false</returns>
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            if(canExecute == null)
            {
                return true;
            }

            return canExecute(parameter);
        }

        /// <summary>
        /// Wird aufgerufen, wenn das Kommando ausgeführt wird
        /// </summary>
        /// <param name="parameter">Der Parameter</param>
        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
