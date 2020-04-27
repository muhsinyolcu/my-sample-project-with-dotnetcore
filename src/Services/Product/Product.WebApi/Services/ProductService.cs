using Common.Core.Enums;
using Common.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Product.WebApi.Services
{
    public class ProductService : IProductService
    {
        #region datas
        private readonly List<Models.Product> _products = new List<Models.Product>()
        {
            new Models.Product { Id = 1, ProductName = "Apple MacBook Pro Intel Core i7 9750H", ProductPrice = 17945.00m, Unit = 27 },
            new Models.Product { Id = 2, ProductName = "Lenovo L340 Intel Core i7 9750H", ProductPrice = 8389.53m , Unit = 56 },
            new Models.Product { Id = 3, ProductName = "HP Pavilion GAMİNG 17-CD0012NT Intel Core i7 9750H", ProductPrice = 10299.00m, Unit = 15 },
            new Models.Product { Id = 4, ProductName = "MSI GF75 Thin 9SC-439XTR Intel Core i7 9750H", ProductPrice = 10158.00m, Unit = 18 }
        };
        #endregion
        public ServiceResult<List<Models.Product>> GetAllProducts()
        {
            var serviceResult = new ServiceResult<List<Models.Product>>();
            try
            {
                var products = _products.ToList();

                if (products == null)
                    serviceResult.StatusCode = (int)StatusCodesEnum.BadRequest;

                serviceResult.Result = products;
            }
            catch (Exception ex)
            {
                serviceResult.HasError = true;
                serviceResult.StatusCode = (int)StatusCodesEnum.SystemException;
                serviceResult.ValidationMessages.Add(ex.Message);
                //LOG
            }
            return serviceResult;
        }
    }
}
