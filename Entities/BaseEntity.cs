using System;
using System.Text.Json.Serialization;

namespace Entities
{
    /// <summary>
    ///     Représente les propriétés technique.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        ///     Identifiant technique
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        ///     Date de creation de la ligne
        /// </summary>
        [JsonIgnore]
        public DateTime CreationDate { get; set; }
    }
}