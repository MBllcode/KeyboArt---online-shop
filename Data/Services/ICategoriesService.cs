using KeyboArt.Data.Base;
using KeyboArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeyboArt.Data.Services
{
    public interface ICategoriesService : IEntityBaseRepository<Category>
    {
    }
}
