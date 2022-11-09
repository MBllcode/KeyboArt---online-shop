using KeyboArt.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KeyboArt.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAdress, DateTime date);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}
