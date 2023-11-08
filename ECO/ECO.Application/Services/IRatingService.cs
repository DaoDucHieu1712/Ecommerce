using ECO.Application.DTOs.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Services
{
    public interface IRatingService : IBaseService<RatingResponseDTO, RatingRequestDTO, int>
    {
    }
}
