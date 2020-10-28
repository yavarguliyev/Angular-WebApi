using Api.Resources;
using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    public class CatalogueController : ControllerBase
    {
        #region IServices
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public CatalogueController(IMapper mapper,
                                   IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Branches
        [Route("branches")]
        [HttpGet]
        public async Task<IActionResult> Branches()
        {
            var branches = await _unitOfWork.Branch.GetAllAsync();
            var branchResources = _mapper.Map<IEnumerable<Branch>, IEnumerable<BranchResource>>(branches);

            if (branchResources.Count() == 0)
            {
                ModelState.AddModelError("Branches", "There are no available branches yet...");
                return BadRequest(ModelState);
            }

            return Ok(branchResources);
        }
        #endregion

        #region Categories
        [Route("categories")]
        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            var categories = await _unitOfWork.Category.GetAllOrderedAsync();
            var categoryResources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);

            if (categoryResources.Count() == 0)
            {
                ModelState.AddModelError("Categories", "There are no available categories yet...");
                return BadRequest(ModelState);
            }

            return Ok(categoryResources);
        }
        #endregion

        #region Featured-Products
        [Route("featured-products")]
        [HttpGet]
        public async Task<IActionResult> GetFeaturedProducts([FromQuery] long branchId)
        {
            if (branchId == 0)
            {
                ModelState.AddModelError("Branch Id", "Branch Id cannot be empty...");
                return BadRequest(ModelState);
            }

            var branch = await _unitOfWork.Branch.GetByIdAsync(branchId);
            if (branch == null) return NotFound();

            var products = await _unitOfWork.Product.GetFeaturedProductsByBranchId(branchId);
            if (products.Count() == 0)
            {
                ModelState.AddModelError("Products", "There are no available products yet...");
                return BadRequest(ModelState);
            }

            var productResources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return Ok(productResources);
        }
        #endregion

        #region New-Products
        [Route("new-products")]
        [HttpGet]
        public async Task<IActionResult> GetNewProducts([FromQuery] long branchId)
        {
            if (branchId == 0)
            {
                ModelState.AddModelError("Branch Id", "Branch Id cannot be empty...");
                return BadRequest(ModelState);
            }

            var branch = await _unitOfWork.Branch.GetByIdAsync(branchId);
            if (branch == null) return NotFound();

            var products = await _unitOfWork.Product.GetNewProductsByBranchId(branchId);
            if (products.Count() == 0)
            {
                ModelState.AddModelError("Products", "There are no available products yet...");
                return BadRequest(ModelState);
            }

            var productResources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return Ok(productResources);
        }
        #endregion

        #region Products
        [Route("products")]
        [HttpGet]
        public async Task<IActionResult> GetProductsByCategory([FromQuery] long branchId,
                                                               [FromQuery] long categoryId,
                                                               [FromQuery] int page = 1)
        {
            if (branchId == 0)
            {
                ModelState.AddModelError("Branch Id", "Branch Id cannot be empty...");
                return BadRequest(ModelState);
            }

            if (categoryId == 0)
            {
                ModelState.AddModelError("Category Id", "Category Id cannot be empty...");
                return BadRequest(ModelState);
            }

            var branch = await _unitOfWork.Branch.GetByIdAsync(branchId);
            if (branch == null) return NotFound();

            var category = await _unitOfWork.Category.GetByIdAsync(categoryId);
            if (category == null) return NotFound();

            var totalProduct = await _unitOfWork.Product.GetNewProductsCountByBranchIdAndCategoryId(branchId, categoryId);

            var products = await _unitOfWork.Product.GetNewProductsByBranchIdAndCategoryId(branchId, categoryId, page);
            if (products.Count() == 0)
            {
                ModelState.AddModelError("Products", "There are no available products yet...");
                return BadRequest(ModelState);
            }

            var productResources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return Ok(new
            {
                products = productResources,
                pagination = new
                {
                    current = page,
                    totalPage = Convert.ToInt32(Math.Ceiling(totalProduct / 12.0))
                }
            });
        }
        #endregion

        #region Product
        [Route("product/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProductById(long id, [FromQuery] long branchId)
        {
            if (id == 0)
            {
                ModelState.AddModelError("Id", "Id cannot be empty...");
                return BadRequest(ModelState);
            }

            if (branchId == 0)
            {
                ModelState.AddModelError("Branch Id", "Branch Id cannot be empty...");
                return BadRequest(ModelState);
            }

            var product = await _unitOfWork.Product.GetByIdAsync(id);
            if (product == null) return NotFound();

            var branch = await _unitOfWork.Branch.GetByIdAsync(branchId);
            if (branch == null) return NotFound();

            var products = await _unitOfWork.Product.GetProductById(id, branchId);
            if (products == null) return NotFound();

            var productResource = _mapper.Map<Product, ProductResource>(products);

            return Ok(productResource);
        }
        #endregion

        #region Product
        [Route("relative-products")]
        [HttpGet]
        public async Task<IActionResult> GetRelativeProductsById([FromQuery] long id, [FromQuery] long branchId)
        {
            if (id == 0)
            {
                ModelState.AddModelError("Id", "Id cannot be empty...");
                return BadRequest(ModelState);
            }

            if (branchId == 0)
            {
                ModelState.AddModelError("Branch Id", "Branch Id cannot be empty...");
                return BadRequest(ModelState);
            }

            var product = await _unitOfWork.Product.GetByIdAsync(id);
            if (product == null) return NotFound();

            var branch = await _unitOfWork.Branch.GetByIdAsync(branchId);
            if (branch == null) return NotFound();

            var products = await _unitOfWork.Product.GetNewProductsByBranchIdAndCategoryId(product.CategoryId, branchId, 1);
            if (products.Count() == 0)
            {
                ModelState.AddModelError("Products", "There are no available products yet...");
                return BadRequest(ModelState);
            }

            var productToList = products.ToList();
            productToList.RemoveAll(p => p.Id == product.Id);

            var productResources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(productToList.Take(3));

            return Ok(productResources);
        }
        #endregion
    }
}