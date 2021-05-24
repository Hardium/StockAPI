using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    /// <summary>
    /// Cette classe décrit un produit.
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Nom
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Code EAN unique
        /// </summary>
        [Required]
        public string EAN { get; set; }

        /// <summary>
        /// Date de début de validité
        /// </summary>
        [Required]
        public DateTime ValidFrom { get; set; }

        /// <summary>
        /// Date de fin de validité
        /// </summary>
        [Required]
        public DateTime ValidTo { get; set; }

    }
}
