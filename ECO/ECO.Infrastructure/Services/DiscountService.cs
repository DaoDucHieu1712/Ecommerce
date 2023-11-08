using AutoMapper;
using ECO.Application.DTOs.Discount;
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
    public class DiscountService : IDiscountService
    {

        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository discountRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
        }

        public async Task Add(DiscountRequestDTO entity)
        {
            await _discountRepository.Add(_mapper.Map<Discount>(entity));
        }

        public async Task<DiscountResponseDTO> FindById(int id)
        {
            return _mapper.Map<DiscountResponseDTO>(await _discountRepository.FindSingle(x => x.Id == id));
        }

        public async Task<List<DiscountResponseDTO>> GetAll()
        {
            return _mapper.Map<List<DiscountResponseDTO>>(await _discountRepository.FindAll().ToListAsync());
        }

        public DataResult<DiscountResponseDTO> GetPaging(DataRequest req)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int id)
        {
            await _discountRepository.RemoveSoft(id);
        }

        public async Task Update(DiscountRequestDTO entity)
        {
            await _discountRepository.Update(_mapper.Map<Discount>(entity), "CreatedAt");
        }
    }
}
