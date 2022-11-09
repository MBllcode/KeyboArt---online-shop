using KeyboArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
