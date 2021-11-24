using AutoMapper;
using Contracts;
using Entities.Models;
using Entities.ModelsDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace NorthwindServer.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private ILoggerManager _logger;
        private IMapper _mapper;

        public CategoryController(IRepositoryWrapper repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns>List of Categories</returns>
        /// <remarks>
        /// Sample request
        ///     
        /// </remarks>
        [HttpGet]
        public IActionResult GeAllCategories()
        {
            try
            {
                var categories = _repository.CategoryRepository.GetAllCategories();

                _logger.LogInfo($"Returned all categories from DB");

                var categoriesResult = _mapper.Map<IEnumerable<CategoryDto>>(categories);


                return Ok(categoriesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error inside controller Category, action GeAllCategories, message: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public IActionResult GetCatgoryById(int id)
        {
            try
            {
                var category = _repository.CategoryRepository.GetCategoryById(id);

                if (category == null)
                {
                    _logger.LogError($"Category with id: {id} not found in DB");
                    return NotFound(); // 404
                }
                else
                {
                    _logger.LogInfo($"Returned category with id: {id}");

                    var categoryResult = _mapper.Map<CategoryDto>(category);

                    return Ok(categoryResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error inside controller Category, action GetCatgoryById, message: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/products", Name = "GetCatgoryWithOwnProducts")]
        public IActionResult GetCatgoryWithOwnProducts(int id)
        {
            try
            {
                var category = _repository.CategoryRepository.GetCatgoryWithOwnProducts(id);

                if (category == null)
                {
                    _logger.LogError($"Category with id: {id} not found in DB");
                    return NotFound(); // 404
                }
                else
                {
                    _logger.LogInfo($"Returned category withs own products with id: {id}");

                    var categoryResult = _mapper.Map<CategoryDto>(category);

                    return Ok(categoryResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error inside controller Category, action GetCatgoryWithOwnProducts, message: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Create Category
        /// </summary>
        /// <param name="category"></param>
        /// <response code="201">Returs created item</response>
        /// <response code="400">Category object sent from front is null or Incorrect model object from front</response>
        /// <response code="500">Error inside controller Category, action CreateCategory</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult CreateCategory([FromBody] CategoryForCreationDto category)
        {
            try
            {
                if (category == null)
                {
                    _logger.LogError("Category object sent from front is null");
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Incorrect model object from front");
                    return BadRequest("Incorrect model object from front");
                }

                var entity = _mapper.Map<Category>(category);

                _repository.CategoryRepository.CreateCategory(entity);
                _repository.Save();

                var createdCategory = _mapper.Map<CategoryDto>(entity);

                return CreatedAtRoute("GetCatgoryWithOwnProducts", new { id = createdCategory.Id }, createdCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error inside controller Category, action CreateCategory, message: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryForCreateUpdateDto category)
        {
            try
            {
                if (category == null)
                {
                    _logger.LogError("Category object sent from front is null");
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Incorrect Category model object from front");
                    return BadRequest("Incorrect Category model object from front");
                }

                var entity = _repository.CategoryRepository.GetCategoryById(id);

                if (entity == null)
                {
                    _logger.LogError($"Category with id: {id} not found in DB");
                    return NotFound();
                }

                _mapper.Map(category, entity);

                _repository.CategoryRepository.UpdateCategory(entity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error inside controller Category, action CreateCategory, message: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
