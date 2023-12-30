using ECO.Application.DTOs.Orders;
using ECO.Application.DTOs.Others;
using ECO.Domain.Entites;
using ECO.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Services
{
    public interface IOrderService : IBaseService<OrderResponseDTO, OrderRequestDTO, int>
    {
        Task<Payment> CreateAndGetPayment(Payment payment);
        Task<OrderResponseDTO> CreateAndGet(OrderRequestDTO orderRequestDTO);
        Task<EntityFilterDTO<OrderResponseDTO>>GetAllOrder(OrderFilterDTO orderFilterDTO);
        Task<EntityFilterDTO<OrderResponseDTO>> MyOrder(string id , OrderFilterDTO orderFilterDTO);
        Task<List<OrderDetailResponseDTO>> GetOrderDetail(int id);
        Task UpdateOrderStatus(int id, OrderStatus status, string? reason);
        Task UpdatePayment(int id, PaymentMethod method, PaymentStatus status);
        Task UpdateOrderPayment(int id, PaymentStatus status);
    }
}
