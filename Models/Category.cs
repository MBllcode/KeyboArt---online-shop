using KeyboArt.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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