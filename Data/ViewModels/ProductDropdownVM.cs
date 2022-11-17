using KeyboArt.Models;
using System.Collections.Generic;

namespace KeyboArt.Data.ViewModels
{
    public class ProductDropdownVM
    {
        public ProductDropdownVM()
        {
            Categories = new List<Category>();
        }
        public List<Category> Categories { get; set; }
    }
}
