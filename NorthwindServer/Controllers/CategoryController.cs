using AutoMapper;
using Contracts;
using Entities.ModelsDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace NorthwindServer.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("{id}")]
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
    }
}
