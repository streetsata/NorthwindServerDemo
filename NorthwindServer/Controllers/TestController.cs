using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace NorthwindServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILoggerManager _loggerManager;
        private IRepositoryWrapper _repository;

        public TestController(ILoggerManager loggerManager, IRepositoryWrapper repositoryWrapper)
        {
            _loggerManager = loggerManager;
            _repository = repositoryWrapper;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            var result = _repository. CategoryRepository.FindAll();
            var result2 = _repository.CategoryRepository.FindByCondition(x => x.CategoryName.Equals("Beverages"));

            return result;
        }


    }
}
