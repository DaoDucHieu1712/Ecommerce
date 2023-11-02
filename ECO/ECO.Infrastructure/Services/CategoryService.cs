using AutoMapper;
using ECO.Application.DTOs.Category;
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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task Add(CategoryRequestDTO entity)
        {
            var c = _mapper.Map<Category>(entity);
            await _categoryRepository.Add(c);
        }

        public async Task<CategoryResponseDTO> FindById(int id)
        {
            return _mapper.Map<CategoryResponseDTO>(await _categoryRepository.FindSingle(x => x.Id == id));
        }

        public async Task<List<CategoryResponseDTO>> GetAll()
        {
            return _mapper.Map<List<CategoryResponseDTO>>(await _categoryRepository.FindAll().ToListAsync());
        }

        public DataResult<CategoryResponseDTO> GetPaging(DataRequest req)
        {
            return _mapper.Map<DataResult<CategoryResponseDTO>>(_categoryRepository.GetPaging(req));
        }

        public async Task Remove(int id)
        {
            await _categoryRepository.RemoveSoft(id);
        }

        public async Task Update(CategoryRequestDTO entity)
        {
            await _categoryRepository.Update(_mapper.Map<Category>(entity), "CreatedAt");
        }
    }
}
