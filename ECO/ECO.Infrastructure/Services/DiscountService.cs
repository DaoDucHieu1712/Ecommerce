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
        private readonly IDiscountUserRepository _discountUserRepository;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository discountRepository, IDiscountUserRepository discountUserRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _discountUserRepository = discountUserRepository;
            _mapper = mapper;
        }

        public async Task Add(DiscountRequestDTO entity)
        {
            var _discount = await _discountRepository.FindSingle(x => x.Code== entity.Code);
            if (_discount != null) throw new Exception("Code discount already !");
            await _discountRepository.Add(_mapper.Map<Discount>(entity));
        }

        public async Task<UseDiscountDTO> CheckDiscount(string Code , string customerId)
        {
            var _discount = await _discountRepository.FindSingle(x => x.Code == Code);
            if (_discount == null) throw new Exception("Mã giảm giá không tồn tại !!");

            if(DateTime.Now >= _discount.Expire) throw new Exception("Mã giảm giá đã hết hạn !!");

            var _check = await _discountUserRepository.FindSingle(x => x.DiscountId == _discount.Id && x.CustomerId == customerId);
            if(_check != null) throw new Exception("Bạn đã sử dụng mã này rồi");

            return new UseDiscountDTO
            {
                Massage = "Mã giảm giá hợp lệ !!",
                Percent = _discount.Percent,
                IsUse = true
            };
        }

        public async Task<DiscountResponseDTO> FindById(int id)
        {
            return _mapper.Map<DiscountResponseDTO>(await _discountRepository.FindSingle(x => x.Id == id));
        }

        public async Task<List<DiscountResponseDTO>> GetAll()
        {
            return _mapper.Map<List<DiscountResponseDTO>>(await _discountRepository.FindAll(X => X.IsPublic == true).ToListAsync());
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

        public async Task UseDiscount(string Code, string customerId)
        {
            var _discount = await _discountRepository.FindSingle(x => x.Code == Code);
            if (_discount == null) throw new Exception("Discount Not found !!");
            await _discountUserRepository.Add(new DiscountUser { CustomerId = customerId, DiscountId = _discount.Id });
        }
    }
}
