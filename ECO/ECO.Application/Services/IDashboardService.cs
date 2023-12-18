using ECO.Application.DTOs.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Services
{
    public interface IDashboardService
    {
        Task<dynamic> GetStatisticCount();

        Task<List<RevenuePerMonth>> GetChartTotalPriceByMonth(int year);
        Task<List<CategoryStatictis>> GetCategoryStatictis();
    }
}
