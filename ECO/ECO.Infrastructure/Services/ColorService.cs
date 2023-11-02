using AutoMapper;
using ECO.Application.DTOs.Color;
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
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public ColorService(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task Add(ColorRequestDTO entity)
        {
            await _colorRepository.Add(_mapper.Map<Color>(entity));
        }

        public async Task<ColorResponseDTO> FindById(int id)
        {
            return _mapper.Map<ColorResponseDTO>(await _colorRepository.FindSingle(x => x.Id == id));
        }

        public async Task<List<ColorResponseDTO>> GetAll()
        {
            return _mapper.Map<List<ColorResponseDTO>>(await _colorRepository.FindAll().ToListAsync());
        }

        public DataResult<ColorResponseDTO> GetPaging(DataRequest req)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int id)
        {
            await _colorRepository.RemoveSoft(id);
        }

        public async Task Update(ColorRequestDTO entity)
        {
            await _colorRepository.Update(_mapper.Map<Color>(entity), "CreatedAt");
        }
    }
}
