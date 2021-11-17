using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace NorthwindServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private ILoggerManager _logger;

        public EmployeeController(IRepositoryWrapper repository, ILoggerManager logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public IActionResult GeAllEmployes()
        {
            try
            {
                var employees = _repository.EmployeeRepository.GetAllEmployees();

                _logger.LogInfo($"Returned all employees from DB");

                return Ok(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error inside controller Employee, action GeAllEmployees, message: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
