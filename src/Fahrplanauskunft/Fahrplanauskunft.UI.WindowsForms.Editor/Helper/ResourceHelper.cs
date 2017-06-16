// <copyright file="ResourceHelper.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System.Resources;

namespace Fahrplanauskunft.UI.WindowsForms.Editor.Helper
{
    /// <summary>
    /// Klasse für die Hilfsklasse ResourceHelper
    /// </summary>
    public class ResourceHelper
    {
        /// <summary>
        /// Standardkonstruktor für die Klasse ResourceHelper
        /// </summary>
        public ResourceHelper()
        {
            ResourceManager = new ResourceManager("Fahrplanauskunft.UI.WindowsForms.Editor.Resources.Resources", typeof(FahrplanauskunftMainWindow).Assembly);
        }

        /// <summary>
        /// Der Ressourcenmanager für die Hilfsklasse
        /// </summary>
        public ResourceManager ResourceManager { get; set; }

        /// <summary>
        /// Methode für das Laden eines Resourcenwertes anhand eines Ident
        /// </summary>
        /// <param name="resourceIdent">Der Identifizierer der Resource</param>
        /// <returns>Gibt den Wert aus der Resourcendatei zurück</returns>
        public string RessourcenTextFuerIdent(string resourceIdent)
        {
            return ResourceManager.GetString(resourceIdent);
        }
    }
}
