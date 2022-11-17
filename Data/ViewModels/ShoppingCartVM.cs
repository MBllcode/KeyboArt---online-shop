using KeyboArt.Data.Cart;
using KeyboArt.Models;

namespace KeyboArt.Data.ViewModels
{
    public class ShoppingCartVM
    {
        public ShoppingCart ShoppingCart { get; set; }
        public Product Product { get; set; }
        public double ShoppingCartTotal { get; set; }
    }
}
