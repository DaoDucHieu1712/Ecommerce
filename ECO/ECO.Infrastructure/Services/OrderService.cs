using AutoMapper;
using ECO.Application.DTOs.Orders;
using ECO.Application.DTOs.Others;
using ECO.Application.DTOs.Products;
using ECO.Application.Repositories;
using ECO.Application.Services;
using ECO.DataTable;
using ECO.Domain.Entites;
using ECO.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Infrastructure.Services
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IPaymentRepository paymentRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task Add(OrderRequestDTO entity)
        {
            await _orderRepository.Add(_mapper.Map<Order>(entity));
        }

        public async Task<Payment> CreateAndGetPayment(Payment payment)
        {
            return await _paymentRepository.CreateAndGetEntity(payment);
        }

        public async Task<OrderResponseDTO> FindById(int id)
        {
            var _order = await _orderRepository
                .FindAll(x => x.Id == id)
                .Include(x => x.Payment)
                .Include(x => x.Customer)
                .Include(x => x.OrderDetails).ThenInclude(x => x.Product)
                .Include(x => x.OrderDetails).ThenInclude(x => x.Inventory)
                .FirstOrDefaultAsync();


            return _mapper.Map<OrderResponseDTO>(_order);
        }

        public async Task<List<OrderResponseDTO>> GetAll()
        {
            return _mapper.Map<List<OrderResponseDTO>>(await _orderRepository.FindAll().ToListAsync());
        }

        public async Task<EntityFilterDTO<OrderResponseDTO>> GetAllOrder(OrderFilterDTO orderFilterDTO)
        {
            var query = _orderRepository.FindAll(x => x.Payment, x=>x.Customer);

            if (orderFilterDTO.SortType != null)
            {
                switch (orderFilterDTO.SortType)
                {
                    case "date-asc":
                        query = query.OrderBy(x => x.CreatedAt);
                        break;
                    case "date-desc":
                        query = query.OrderByDescending(x => x.CreatedAt);
                        break;
                    case "price-asc":
                        query = query.OrderBy(x => x.TotalPrice);
                        break;
                    case "price-desc":
                        query = query.OrderByDescending(x => x.TotalPrice);
                        break;
                    default:
                        query = query.OrderByDescending(x => x.CreatedAt);
                        break;
                }
            }

            if (orderFilterDTO.CustomerName != null)
            {
                query = query.Where(x => x.Customer.UserName.ToLower().Contains(orderFilterDTO.CustomerName.ToLower()));
            }

            if (orderFilterDTO.StartDate != null)
            {
                query = query.Where(x => x.CreatedAt >= orderFilterDTO.StartDate);
            }

            if (orderFilterDTO.EndDate != null)
            {
                query = query.Where(x => x.CreatedAt <= orderFilterDTO.EndDate);
            }

            if (orderFilterDTO.Status != null)
            {
                query = query.Where(x => x.OrderStatus == orderFilterDTO.Status);
            }

            if (orderFilterDTO.OrderId != null)
            {
                query = query.Where(x => x.Id == orderFilterDTO.OrderId);
            }

            PagedList<Order> _pagedList = await PagedList<Order>.ToPagedList(query, orderFilterDTO.PageIndex ?? 1, orderFilterDTO.PageSize ?? 7);

            return new EntityFilterDTO<OrderResponseDTO>()
            {
                List = _mapper.Map<List<OrderResponseDTO>>(_pagedList),
                PageIndex = _pagedList.CurrentPage,
                TotalPages = _pagedList.TotalPages,
                TotalCount = _pagedList.TotalCount,
                HasNext = _pagedList.HasNext,
                HasPrevious = _pagedList.HasPrevious,
                PageSize = _pagedList.PageSize
            };
        }

        public Task<List<OrderDetailResponseDTO>> GetOrderDetail(int id)
        {
            throw new NotImplementedException();
        }

        public DataResult<OrderResponseDTO> GetPaging(DataRequest req)
        {
            throw new NotImplementedException();
        }

        public async Task<EntityFilterDTO<OrderResponseDTO>> MyOrder(string id, OrderFilterDTO orderFilterDTO)
        {
            var query = _orderRepository.FindAll(x => x.CustomerId == id, x=>x.Payment, x => x.Customer);

            if (orderFilterDTO.SortType != null)
            {
                switch (orderFilterDTO.SortType)
                {
                    case "date-asc":
                        query = query.OrderBy(x => x.CreatedAt);
                        break;
                    case "date-desc":
                        query = query.OrderByDescending(x => x.CreatedAt);
                        break;
                    case "price-asc":
                        query = query.OrderBy(x => x.TotalPrice);
                        break;
                    case "price-desc":
                        query = query.OrderByDescending(x => x.TotalPrice);
                        break;
                    default:
                        query = query.OrderByDescending(x => x.CreatedAt);
                        break;
                }
            }

            if (orderFilterDTO.CustomerName != null)
            {
                query = query.Where(x => x.Customer.UserName.ToLower().Contains(orderFilterDTO.CustomerName.ToLower()));
            }

            if (orderFilterDTO.StartDate != null)
            {
                query = query.Where(x => x.CreatedAt >= orderFilterDTO.StartDate);
            }

            if (orderFilterDTO.EndDate != null)
            {
                query = query.Where(x => x.CreatedAt <= orderFilterDTO.EndDate);
            }

            if (orderFilterDTO.Status != null)
            {
                query = query.Where(x => x.OrderStatus == orderFilterDTO.Status);
            }

            if (orderFilterDTO.OrderId != null)
            {
                query = query.Where(x => x.Id == orderFilterDTO.OrderId);
            }

            PagedList<Order> _pagedList = await PagedList<Order>.ToPagedList(query, orderFilterDTO.PageIndex ?? 1, orderFilterDTO.PageSize ?? 7);

            return new EntityFilterDTO<OrderResponseDTO>()
            {
                List = _mapper.Map<List<OrderResponseDTO>>(_pagedList),
                PageIndex = _pagedList.CurrentPage,
                TotalPages = _pagedList.TotalPages,
                TotalCount = _pagedList.TotalCount,
                HasNext = _pagedList.HasNext,
                HasPrevious = _pagedList.HasPrevious,
                PageSize = _pagedList.PageSize
            };
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(OrderRequestDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateOrderPayment(int id, PaymentStatus status)
        {
            var _od = await _orderRepository.FindSingle(x => x.Id == id);
            if(_od == null) throw new Exception("Không tìm thấy Order nào !");
            var _payment = await _paymentRepository.FindSingle(x => x.Id == _od.PaymentId);
            if (_payment == null) throw new Exception("Không tìm thấy Payment nào !");
            _payment.Status = status;
            await _paymentRepository.Update(_payment, "CreatedAt");
        }

        public async Task UpdateOrderStatus(int id, OrderStatus status, string? reason)
        {
            var _od = await _orderRepository.FindSingle(x => x.Id == id);
            if (_od == null) throw new Exception("Không tìm thấy Order nào !");
            if(reason != null)
            {
                _od.CancelReason = reason;
            }
            _od.OrderStatus =status;
            await _orderRepository.Update(_od, "CreatedAt");
        }
    }
}
