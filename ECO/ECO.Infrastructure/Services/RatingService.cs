using AutoMapper;
using ECO.Application.DTOs.Rating;
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
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public RatingService(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task Add(RatingRequestDTO entity)
        {
            await _ratingRepository.Add(_mapper.Map<Rating>(entity));
        }

        public async Task<RatingResponseDTO> FindById(int id)
        {
            return _mapper.Map<RatingResponseDTO>(await _ratingRepository.FindSingle(x => x.Id == id));
        }

        public async Task<List<RatingResponseDTO>> GetAll()
        {
            return _mapper.Map<List<RatingResponseDTO>>(await _ratingRepository.FindAll().ToListAsync());
        }

        public DataResult<RatingResponseDTO> GetPaging(DataRequest req)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int id)
        {
            await _ratingRepository.RemoveSoft(id);
        }

        public async Task Update(RatingRequestDTO entity)
        {
            await _ratingRepository.Update(_mapper.Map<Rating>(entity), "CreatedAt");
        }
    }
}
