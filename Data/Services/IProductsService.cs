using KeyboArt.Data.Base;
using KeyboArt.Data.ViewModels;
using KeyboArt.Models;
using System.Threading.Tasks;

namespace KeyboArt.Data.Services
{
    public interface IProductsService : IEntityBaseRepository<Product>
    {
        Task<ProductDropdownVM> GetProductDropdownVM();
    }
}
