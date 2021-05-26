using ProductKata.Domain.Models;
using ProductKata.Domain.Repository;
using ProductKata.Domain.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductKata.Domain.Service
{
    public class ProductService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly DateHelper dateHelper;

        public ProductService(UnitOfWork unitOfWork, DateHelper dateHelper)
        {
            this.unitOfWork = unitOfWork;
            this.dateHelper = dateHelper;
        }

        public async Task<ProductPrice> GetById(int productId, string login = null)
        {
            ProductCatalog product = await GetProductById(productId);
            Price price = await GetPrice(productId, login);
            return new ProductPrice
            {
                Product = product,
                Price = price
            };
        }

        private async Task<Price> GetPrice(int productId, string login)
        {
            Price price = await unitOfWork.Price.GetByProductId(productId);
  
            if (!string.IsNullOrEmpty(login) && price != null)
            {
                price = await GetReductedPrice(productId, login, price);
            }

            return price;
        }

        private async Task<Price> GetReductedPrice(int productId, string login, Price price)
        {
            User user = await unitOfWork.User.GetByLogin(login);
            double reduction = 0;
            if (user != null)
            {
                List<SellHistory> history = (await unitOfWork.SellHistory.GetByUserId(user.Id)).ToList();
                if (history.Where(x => dateHelper.AfterSixMonths(x.Date)).Count() > 3)
                {
                    reduction = 10;
                }
                else if (history.Where(x => x.ProductId == productId &&
                        dateHelper.AfterOneYear(x.Date)).Count() > 5)
                {
                    reduction = 5;
                }
            }
            Price updatedPrice = new()
            {
                ProductId = productId,
                CurrentPrice = price.CurrentPrice * (100 - reduction) / 100,
                UpdateDate = price.UpdateDate
            };
            return updatedPrice;
        }

        private Task<ProductCatalog> GetProductById(int id)
        {
            return unitOfWork.ProductCatalog.Get(id);
        }
    }
}
