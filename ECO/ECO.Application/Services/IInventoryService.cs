using ECO.Application.DTOs.Inventory;
using ECO.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Services
{
    public interface IInventoryService : IBaseService<InventoryResponseDTO, InventoryRequestDTO, int>
    {
        Task<List<InventoryResponseDTO>> GetAllByProductId(int productId);
        Task AddQuantityInventory(int id, int quantity);
        Task DescreaseQuantityInventory(int id, int quantity);
       
    }
}
