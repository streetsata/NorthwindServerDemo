using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;
        private IEmployeeRepository _employeeRepository;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ICategoryRepository CategoryRepository
        {
            get 
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(_repositoryContext);

                return _categoryRepository; 
            }
        }

        public IProductRepository ProductRepository
        {
            get 
            {
                if(_productRepository == null)
                    _productRepository = new ProductRepository(_repositoryContext);

                return _productRepository; 
            }
        }

        public IEmployeeRepository EmployeeRepository
        {
            get 
            {
                if(_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_repositoryContext);

                return _employeeRepository;
            }
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
