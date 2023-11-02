using ECO.Application.DTOs.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Services
{
    public interface IColorService : IBaseService<ColorResponseDTO, ColorRequestDTO, int>
    {
    }
}
