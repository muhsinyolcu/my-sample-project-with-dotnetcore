using Common.Core.Helpers;
using System.Collections.Generic;

namespace Product.WebApi.Services
{
    public interface IProductService
    {
        ServiceResult<List<Models.Product>> GetAllProducts();
    }
}
