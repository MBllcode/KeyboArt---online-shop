using KeyboArt.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KeyboArt.Models
{
    public class Product:IEntityBase
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nazwa")]
        [MaxLength(30, ErrorMessage = "Nazwa nie może posiadać więcej niż {1} znaków")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        [MinLength(20, ErrorMessage = "Opis nie może posiadać mniej niż {1} znaków")]
        public string Description { get; set; }

        [Display(Name = "Cena")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Display(Name = "Ilość")]
        public int Quantity { get; set; }

        [Display(Name = "Adres URL zdjęcia")]
        public string ImageURL { get; set; }

        // Relationships
        [Required]
        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }
        [Display(Name = "Kategoria")]
        public virtual Category Category { get; set; }
    }
}
