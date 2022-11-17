using KeyboArt.Data.Base;
using KeyboArt.Models;

namespace KeyboArt.Data.Services
{
    public class CategoriesService : EntityBaseRepository<Category>, ICategoriesService
    {
        public CategoriesService(AppDbContext context) : base(context) { }
    }
}
