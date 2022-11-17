using KeyboArt.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KeyboArt.Models
{
    public class Category:IEntityBase
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa kategorii")]
        public string CategoryName { get; set; }
        [Display(Name = "Adres URL zdjęcia")]
        public string ImageURL { get; set; }

        // Relationships
        public List<Product> Products { get; set; }
    }
}