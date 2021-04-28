using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;

        private readonly IGenericRepository<ProductType> _productTypeRepo;

        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo,
                                  IGenericRepository<ProductBrand> productBrandRepo,
                                  IGenericRepository<ProductType> productTypeRepo,
                                  IMapper mapper)
        {
            _mapper = mapper;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _productRepo = productRepo;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ProductToReturnDto>>> GetProducts()
        {
            var specification = new ProductsWithTypeAndBrandSpecification();
            var products = await _productRepo.ListAllAsync(specification);
            var productsToReturn = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

            if (!productsToReturn.Any())
                return NotFound();

            return Ok(productsToReturn);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var specification = new ProductsWithTypeAndBrandSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(specification);
            var productToReturn = _mapper.Map<Product, ProductToReturnDto>(product);

            if (productToReturn == null)
                return NotFound();

            return Ok(productToReturn);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrand>> GetProductBrands()
        {
            var productBrands = await _productBrandRepo.ListAllAsync();
            return Ok(productBrands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<ProductType>> GetProductTypes()
        {
            var productTypes = await _productTypeRepo.ListAllAsync();
            return Ok(productTypes);
        }
    }
}