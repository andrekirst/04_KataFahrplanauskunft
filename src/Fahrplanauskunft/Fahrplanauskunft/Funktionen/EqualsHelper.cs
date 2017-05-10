using System;

namespace Fahrplanauskunft.Funktionen
{
    /// <summary>
    /// Diese Klasse ist eine Hilfsklasse für die Equals-Methode
    /// </summary>
    public static class EqualsHelper
    {
        /// <summary>
        /// Hilfsmethode für die Equals-Implementierung
        /// </summary>
        /// <typeparam name="T">Der Typ, für wen die Equals-Methode gilt</typeparam>
        /// <param name="obj">Die Objektreferenz, die der Equals-Methode übergeben wird</param>
        /// <param name="custom">Die Funktion, die bool zurückgibt und ein Objekt vom Typ T erwartet. Dieses spiegelt das gecastete Objekt wieder</param>
        /// <returns>Gibt true zurück, wenn die Funktion custom true zurückgibt, ansonsten false.</returns>
        public static bool EqualBase<T>(object obj, Func<T, bool> custom)
            where T : class
        {
            if (obj == null)
            {
                return false;
            }

            T other = obj as T;
            if (other == null)
            {
                return false;
            }

            if (custom != null)
            {
                Func<T, bool> func = custom;
                return func(other);
            }

            return false;
        }

        /// <summary>
        /// Hilfsmethode für die Equals-Implementierung
        /// </summary>
        /// <typeparam name="T">Der Type, für wen die Equals-Methode gilt</typeparam>
        /// <param name="obj">Die Objektreferenz, die der Equals-Methode übergeben wird</param>
        /// <param name="custom">Die Funktion, die bool zurückgibt und ein Objekt vom Typ T erwartet</param>
        /// <returns></returns>
        public static bool EqualBase<T>(T obj, Func<bool> custom)
        {
            if(obj == null)
            {
                return false;
            }

            if(custom != null)
            {
                Func<bool> func = custom;
                return func();
            }

            return false;
        }
    }
}
