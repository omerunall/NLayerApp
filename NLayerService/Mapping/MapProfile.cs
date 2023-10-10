﻿using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerService.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap(); //reversemap dersem productDtoyu product da çevirebilirim
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDTO>().ReverseMap();

            CreateMap<ProductUpdateDTO, Product>();
            CreateMap<Product, ProductWithCategoryDTO>();
            CreateMap<Category, CategoryWithsProduct>();
        }
    }
}
