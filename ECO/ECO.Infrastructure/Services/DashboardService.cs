using ECO.Application.DTOs.Dashboard;
using ECO.Application.Repositories;
using ECO.Application.Services;
using ECO.Domain.Enums;
using ECO.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Infrastructure.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IProductRepository _productRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ECOContext _context;

        public DashboardService(IProductRepository productRepository, IInventoryRepository inventoryRepository, ICategoryRepository categoryRepository, IOrderDetailRepository orderDetailRepository, IOrderRepository orderRepository, ECOContext context)
        {
            _productRepository = productRepository;
            _inventoryRepository = inventoryRepository;
            _categoryRepository = categoryRepository;
            _orderDetailRepository = orderDetailRepository;
            _orderRepository = orderRepository;
            _context = context;
        }

        public async Task<List<RevenuePerMonth>> GetChartTotalPriceByMonth(int year)
        {
            try
            {
                var monthNames = new[] { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" };
                var distinctOrderIds = await _orderDetailRepository.FindAll()
                            .Select(od => od.OrderId)
                            .Distinct()
                            .ToListAsync();

                var revenuePerMonth = Enumerable.Range(1, 12)
                    .Select(month => new RevenuePerMonth
                    {
                        Month = monthNames[month - 1],
                        Revenue = _orderRepository.FindAll()
                            .Where(o => o.OrderStatus == Domain.Enums.OrderStatus.Completed && o.CreatedAt.Year == year && o.CreatedAt.Month == month && distinctOrderIds.Contains(o.Id))
                            .Sum(x => x.TotalPrice)
                    })
                    .ToList();

                return revenuePerMonth;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<dynamic> GetStatisticCount()
        {
            var products = await _productRepository.FindAll().ToListAsync();
            var orders = await _orderRepository.FindAll().ToListAsync();
            var categories = await _categoryRepository.FindAll().ToListAsync();
            var inventories = await _inventoryRepository.FindAll().ToListAsync();

            return new
            {
                ProductCount = products.Count,
                OrderCount = orders.Count,
                CategoryCount = categories.Count,
                InventoryCount = inventories.Count,
                UserCount = _context.AppUsers.Count(),
            };
        }

        public async Task<List<CategoryStatictis>> GetCategoryStatictis()
        {

            var OrderCount = _orderDetailRepository.FindAll().Sum(x => x.Quantity);

            var categoryOrder = await _categoryRepository.FindAll().Include(x => x.Products).ThenInclude(x => x.OrderDetails).Select(x => new
            {
                CategoryId = x.Id,
                CategoryName = x.Name,
                Count = x.Products.Sum(x => x.OrderDetails.Count),
            }).Select(x => new CategoryStatictis
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Percent = (double)x.Count / OrderCount * 100
            }).ToListAsync();


            return categoryOrder;
        }

        public async Task<List<OrderStatistic>> GetOrderStatistics()
        {
            var orderCount = _orderRepository.FindAll().Count();
            List<OrderStatistic> list = new List<OrderStatistic>();

            list.Add(new OrderStatistic
            {
                Status = "Đang chờ",
                Percent = (double)_orderRepository.FindAll(x => x.OrderStatus == OrderStatus.Idel).Count() / (double)orderCount *100
            });
            list.Add(new OrderStatistic
            {
                Status = "Đang giao",
                Percent = (double)_orderRepository.FindAll(x => x.OrderStatus == OrderStatus.Pending).Count() / (double)orderCount *100
            }); 
            list.Add(new OrderStatistic
            {
                Status = "Đã giao hàng",
                Percent =(double) _orderRepository.FindAll(x => x.OrderStatus == OrderStatus.Completed).Count() / (double) orderCount *100
            }); 
            list.Add(new OrderStatistic
            {
                Status = "Đã hủy",
                Percent = (double)_orderRepository.FindAll(x => x.OrderStatus == OrderStatus.Rejected).Count() / (double)orderCount *100
            });

            return list;
        }
    }
}
