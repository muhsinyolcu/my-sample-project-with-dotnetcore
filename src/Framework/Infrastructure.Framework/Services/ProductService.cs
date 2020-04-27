using Common.Core.Helpers;
using Data.SqlServer.Entities;
using Infrastructure.Framework.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Framework.Services
{
    //TODO productservice
    public class ProductService : IProductService
    {
        public Task<ServiceResult<MySProduct>> AddAsync(MySProduct entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<int>> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<IReadOnlyList<MySProduct>>> ListAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<MySProduct>> UpdateAsync(MySProduct entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
