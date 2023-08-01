﻿using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerService.Services
{
    public interface IProductService : IService<Product>
    {
        Task<CustomResponseDTO<List<ProductWithCategoryDTO>>> GetProductWithCategory();
    }
}
