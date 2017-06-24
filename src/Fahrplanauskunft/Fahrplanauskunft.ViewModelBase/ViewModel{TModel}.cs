// <copyright file="ViewModel{TModel}.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>
// Vorlage: http://www.cocktailsandcode.de/2012/04/mvvm-tutorial-part-3-viewmodelbase-und-relaycommand/

using System;
using System.ComponentModel;
using System.Linq;
using Fahrplanauskunft.Funktionen;

namespace Fahrplanauskunft.ViewModelBase
{
    /// <summary>
    /// Abstrakte Klasse für ViewModel mit dem generischen Parameter für das Model
    /// </summary>
    /// <typeparam name="TModel">Das Model</typeparam>
    public abstract class ViewModel<TModel> : ViewModel, IViewModel<TModel>, IEquatable<ViewModel<TModel>>
        where TModel : class
    {
        private TModel model;

        /// <summary>
        /// Initialisert eine neue Instanz der Klasse ViewModel mit einem Model
        /// </summary>
        /// <param name="model">Das Model</param>
        protected ViewModel(TModel model)
            : base()
        {
            this.model = model;
        }

        /// <summary>
        /// Gibt das Model zurück, oder setzt es
        /// </summary>
        [Browsable(false)]
        [Bindable(false)]
        public TModel Model
        {
            get
            {
                return model;
            }

            set
            {
                if(Model != value)
                {
                    var properties = this.GetType().GetProperties(System.Reflection.BindingFlags.Public);
                    var oldValues = properties.Select(p => p.GetValue(this, null));
                    var enumerator = oldValues.GetEnumerator();

                    model = value;

                    foreach(var property in properties)
                    {
                        enumerator.MoveNext();
                        var oldValue = enumerator.Current;
                        var newValue = property.GetValue(this, null);

                        if((oldValue == null && newValue == null)
                            || (oldValue != null && newValue == null)
                            || (!oldValue.Equals(newValue)))
                        {
                            OnPropertyChanged(property.Name);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gibt den Hashwert des Models zurück
        /// </summary>
        /// <returns>Der Hashwert des Models</returns>
        public override int GetHashCode()
        {
            return Model.GetHashCode();
        }

        /// <summary>
        /// Vergleicht das ViewModel mit einem anderen Objekt
        /// </summary>
        /// <param name="obj">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as IViewModel<TModel>);
        }

        /// <summary>
        /// Vergleicht das IViewModel
        /// </summary>
        /// <param name="other">Die zu vergleichende IViewModel-Instanz</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public bool Equals(IViewModel<TModel> other)
        {
            return EqualsHelper.EqualBase<IViewModel<TModel>>(
                other,
                () =>
                {
                    return this.Model == other.Model;
                });
        }

        /// <summary>
        /// Implementation von IEquatable
        /// </summary>
        /// <param name="other">Die zu vergleichende ViewModel-Instanz</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public bool Equals(ViewModel<TModel> other)
        {
            return Equals(other as IViewModel<TModel>);
        }
    }
}
