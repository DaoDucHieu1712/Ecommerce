using AutoMapper;
using ECO.Application.DTOs.Inventory;
using ECO.Application.Repositories;
using ECO.Application.Services;
using ECO.DataTable;
using ECO.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Infrastructure.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public InventoryService(IInventoryRepository inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task Add(InventoryRequestDTO entity)
        {
            var _invetory = await _inventoryRepository
                .FindSingle(x => x.ColorId == entity.ColorId
                && x.SizeId == entity.SizeId
                && x.ProductId == entity.ProductId);
            if (_invetory == null)
            {
                await _inventoryRepository.Add(_mapper.Map<Inventory>(entity));
            }
            else
            {
                throw new Exception("Tồn kho này đã tồn tại !!");
            }
        }

        public async Task AddQuantityInventory(int id, int quantity)
        {
            var inventory = await _inventoryRepository.FindSingle(x => x.Id == id);
            inventory.Quantity = inventory.Quantity + quantity;
            await _inventoryRepository.Update(inventory, "CreatedAt");
        }

        public async Task DescreaseQuantityInventory(int id, int quantity)
        {
            var inventory = await _inventoryRepository.FindSingle(x => x.Id == id);
            inventory.Quantity = inventory.Quantity - quantity;
            await _inventoryRepository.Update(inventory, "CreatedAt");
        }

        public async Task<InventoryResponseDTO> FindById(int id)
        {
            return _mapper.Map<InventoryResponseDTO>(await _inventoryRepository.FindSingle(x => x.Id == id));
        }

        public async Task<List<InventoryResponseDTO>> GetAll()
        {
            return _mapper.Map<List<InventoryResponseDTO>>(await _inventoryRepository.FindAll(x => x.Color, x => x.Product, x => x.Size).ToListAsync());
        }

        public async Task<List<InventoryResponseDTO>> GetAllByProductId(int productId)
        {
            return _mapper.Map<List<InventoryResponseDTO>>(await _inventoryRepository.FindAll(x => x.ProductId == productId, x => x.Color, x => x.Product, x => x.Size).ToListAsync());
        }

        public DataResult<InventoryResponseDTO> GetPaging(DataRequest req)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int id)
        {
            await _inventoryRepository.RemoveSoft(id);
        }

        public async Task Update(InventoryRequestDTO entity)
        {
            await _inventoryRepository.Update(_mapper.Map<Inventory>(entity), "CreatedAt");
        }
    }
}
