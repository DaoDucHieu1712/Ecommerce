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
            await _inventoryRepository.Add(_mapper.Map<Inventory>(entity));
        }

        public async Task<InventoryResponseDTO> FindById(int id)
        {
            return _mapper.Map<InventoryResponseDTO>(await _inventoryRepository.FindSingle(x => x.Id == id));
        }

        public async Task<List<InventoryResponseDTO>> GetAll()
        {
            return _mapper.Map<List<InventoryResponseDTO>>(await _inventoryRepository.FindAll(x => x.Color, x=> x.Product, x => x.Size).ToListAsync());
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
