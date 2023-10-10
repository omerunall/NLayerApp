using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayerService.Services;

namespace NLayer.API.Controllers
{

    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(IMapper mapper, IService<Product> productService, IProductService productService1)
        {
            _mapper = mapper;

            _productService = productService1;
        }

        // api/products/GetProductWithCategory
        [HttpGet("action")]
        public async Task<IActionResult> GetProductWithCategory()
        {

            return CreateActionResult(await _productService.GetProductWithCategory());
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var product = await _productService.GetAllAsync();
            var productsDtos = _mapper.Map<List<ProductDTO>>(product.ToList());

            //return Ok(CustomResponseDTO<List<ProductDTO>>.Success(200, productsDtos));
            return CreateActionResult(CustomResponseDTO<List<ProductDTO>>.Success(200, productsDtos));

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var productsDtos = _mapper.Map<ProductDTO>(product);

            //return Ok(CustomResponseDTO<List<ProductDTO>>.Success(200, productsDtos));
            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(200, productsDtos));

        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO productDTO)
        {
            var product = await _productService.AddAsync(_mapper.Map<Product>(productDTO)); //convert entity
            var productsDtos = _mapper.Map<ProductDTO>(product);

            //return Ok(CustomResponseDTO<List<ProductDTO>>.Success(200, productsDtos));
            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(201, productsDtos));

        }


        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDTO productUpdateDTO)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productUpdateDTO)); //convert entity
            //return Ok(CustomResponseDTO<List<ProductDTO>>.Success(200, productsDtos));
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.RemoveAsync(product);
            //return Ok(CustomResponseDTO<List<ProductDTO>>.Success(200, productsDtos));
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));

        }
    }
}
