using ECO.Application.DTOs.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Services
{
    public interface IDiscountService :IBaseService<DiscountResponseDTO, DiscountRequestDTO, int>
    {
    }
}
