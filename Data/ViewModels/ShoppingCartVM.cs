using KeyboArt.Data.Cart;
using KeyboArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeyboArt.Data.ViewModels
{
    public class ShoppingCartVM
    {
        public ShoppingCart ShoppingCart { get; set; }
        public Product Product { get; set; }
        public double ShoppingCartTotal { get; set; }
    }
}
