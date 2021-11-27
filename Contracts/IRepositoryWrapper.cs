﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
