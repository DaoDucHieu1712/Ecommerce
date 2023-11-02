using AutoMapper;
using ECO.Application.DTOs.Size;
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
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper _mapper;

        public SizeService(ISizeRepository sizeRepository, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }

        public async Task Add(SizeRequestDTO entity)
        {
            await _sizeRepository.Add(_mapper.Map<Size>(entity));
        }

        public async Task<SizeResponseDTO> FindById(int id)
        {
            return _mapper.Map<SizeResponseDTO>(await _sizeRepository.FindSingle(x => x.Id == id));
        }

        public async Task<List<SizeResponseDTO>> GetAll()
        {
            return _mapper.Map<List<SizeResponseDTO>>(await _sizeRepository.FindAll().ToListAsync());
        }

        public DataResult<SizeResponseDTO> GetPaging(DataRequest req)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int id)
        {
            await _sizeRepository.RemoveSoft(id);
        }

        public async Task Update(SizeRequestDTO entity)
        {
            await _sizeRepository.Update(_mapper.Map<Size>(entity), "CreatedAt");
        }
    }
}
