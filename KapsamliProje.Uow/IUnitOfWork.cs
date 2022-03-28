﻿using KapsamliProje.Repos.Abstract;
using KapsamliProje.Repos.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapsamliProje.Uow
{
    public interface IUnitOfWork 
    {
        ICategoriesRepos _categoriesRepos { get; }
        IProductsRepos _productsRepos { get; }
        ISuppliersRepos _suppliersRepos { get; }
        ICitiesRepos _citiesRepos { get; }
        ICustomersRepos _customersRepos { get; }
        ICountiesRepos _countiesRepos { get; }
        IEndConsumersRepos _endConsumersRepos { get; }
        IEmployeesRepos _employeesRepos { get; }
        IAuthRepos _authRepos { get; }
        IFatDetailRepos _fatDetailRepos { get; }
        IFatMasterRepos _fatMasterRepos { get; }
        void Save();
    }
}
