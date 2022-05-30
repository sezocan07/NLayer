using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;

        public ProductsController(IMapper mapper, IService<Product> service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var products = await _service.GetAllAsync();
            var productsDto = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var products = await _service.GetByIdAsync(id);
            var productsDto = _mapper.Map<List<ProductDto>>(products);
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDto));
        }

      
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] ProductDto param)
        {
            IActionResult result;
            if (param.Id == 0)
            {
                param.CreatedDate = DateTime.Now;
                var products = await _service.AddAsync(_mapper.Map<Product>(param));
                var productsDto = _mapper.Map<ProductDto>(products);
                result= CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto, "Kayit Eklendi"));
            }
            else {
              
                param.UpdatedDate = DateTime.Now;
                await _service.UpdateAsync(_mapper.Map<Product>(param));

                result = CreateActionResult(CustomResponseDto<ProductDto>.Success(200, param,"Kayit Guncenlendi"));
            }
            return result;
           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null) {
                return CreateActionResult(CustomResponseDto<ProductDto>.Fail(404, "Urun Bulunamadi"));
            }
            await _service.RemoveAsync(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(204,null));
        }
    }
}

