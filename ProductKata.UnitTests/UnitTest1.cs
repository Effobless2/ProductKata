using NUnit.Framework;
using ProductKata.Domain.Models;
using ProductKata.Domain.Repository;
using ProductKata.Domain.Service;
using ProductKata.Domain.Tools;
using ProductKata.UnitTests.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductKata.UnitTests
{
    public class Tests
    {
        private ProductService productService;
        private UnitOfWork unitOfWork;
        private DateHelper dateHelper;
        [SetUp]
        public void Setup()
        {
            unitOfWork = new(
                new MockSellHistoryRepository(),
                new MockPriceRepository(),
                new MockProductCatalogRepository(),
                new MockUserRepository()
            );
            dateHelper = new()
            {
                Now = new DateTime(2020, 6, 1)
            };
            productService = new(unitOfWork, dateHelper);
        }

        private async Task InitDB()
        {
            List<User> users = new List<User>()
            {
                new()
                {
                    Id = 1,
                    Name = "Paul",
                    Login = "Paul"
                },
                new()
                {
                    Id = 2,
                    Name = "Jeanne",
                    Login = "Jeanne"
                },
                new()
                {
                    Id = 3,
                    Name = "Marie",
                    Login = "Marie"
                },
            };
            List<ProductCatalog> products = new()
            {
                new()
                {
                    Id = 1,
                    Name = "Littière pour chat",
                    Category = "Animaux",
                    Details = new()
                    {
                        { "Poids", "12kg" }
                    },
                    Description = "Les chats l'adorent"
                },
                new()
                {
                    Id = 2,
                    Name = "Littière pour chien",
                    Category = "Animaux",
                    Details = new()
                    {
                        { "Poids", "36kg" }
                    },
                    Description = "Les chiens l'adorent"
                },
                new()
                {
                    Id = 3,
                    Name = "Cage à lapin",
                    Category = "Animaux",
                    Details = new()
                    {
                        { "Poids", "6g" }
                    },
                    Description = "Ils ne s'enfuient jamais"
                },
            };
            List<Price> prices = new()
            {
                new()
                {
                    ProductId = 1,
                    CurrentPrice = 45.0,
                    UpdateDate = new DateTime(2020, 4, 1)
                },
                new()
                {
                    ProductId = 2,
                    CurrentPrice = 12.0,
                    UpdateDate = new DateTime(2020, 4, 1)
                },
                new()
                {
                    ProductId = 3,
                    CurrentPrice = 4.0,
                    UpdateDate = new DateTime(2020, 5, 1)
                },
            };
            List<SellHistory> history = new()
            {
                new()
                {
                    ProductId = 1,
                    Date = new DateTime(2015, 1, 1),
                    UserId = 1
                },
                new()
                {
                    ProductId = 1,
                    Date = new DateTime(2016, 1, 1),
                    UserId = 2
                },
                new()
                {
                    ProductId = 1,
                    Date = new DateTime(2018, 1, 1),
                    UserId = 1
                },
                new()
                {
                    ProductId = 2,
                    Date = new DateTime(2020, 1, 4),
                    UserId = 1
                },
                new()
                {
                    ProductId = 2,
                    Date = new DateTime(2020, 1, 10),
                    UserId = 1
                },
                new()
                {
                    ProductId = 2,
                    Date = new DateTime(2020, 1, 15),
                    UserId = 1
                },
                new()
                {
                    ProductId = 2,
                    Date = new DateTime(2020, 1, 15),
                    UserId = 1
                },
                new()
                {
                    ProductId = 2,
                    Date = new DateTime(2020, 1, 15),
                    UserId = 1
                },
                new()
                {
                    ProductId = 2,
                    Date = new DateTime(2020, 1, 15),
                    UserId = 2
                },
                new()
                {
                    ProductId = 3,
                    Date = new DateTime(2020, 2, 15),
                    UserId = 2
                },
                new()
                {
                    ProductId = 1,
                    Date = new DateTime(2020, 3, 15),
                    UserId = 2
                },
                new()
                {
                    ProductId = 2,
                    Date = new DateTime(2020, 4, 15),
                    UserId = 2
                },
            };

            foreach (User u in users)
            {
                await unitOfWork.User.Add(u);
            }
            foreach (Price p in prices)
            {
                await unitOfWork.Price.Add(p);
            }
            foreach (SellHistory s in history)
            {
                await unitOfWork.SellHistory.Add(s);
            }
            foreach (ProductCatalog p in products)
            {
                await unitOfWork.ProductCatalog.Add(p);
            }
        }

        [Test]
        public async Task LitierePourChatPrixInitial45()
        {
            await InitDB();
            ProductPrice pp = await productService.GetById(1);
            Assert.IsTrue(pp.Price.CurrentPrice == 45);
        }

        [Test]
        public async Task LitierePourChienPrixPourPaul()
        {
            await InitDB();
            ProductPrice pp = await productService.GetById(2, "Paul");
            Assert.IsTrue(pp.Price.CurrentPrice == 10.8);
        }

        [Test]
        public async Task LitierePourChatPrixInitial40Euro50CentsPourJeanne()
        {
            await InitDB();
            ProductPrice pp = await productService.GetById(1, "Jeanne");
            Assert.IsTrue(pp.Price.CurrentPrice == 40.5);
        }

        [Test]
        public async Task LitierePourChatPrixInitial45PourMarie()
        {
            await InitDB();
            ProductPrice pp = await productService.GetById(1, "Marie");
            Assert.IsTrue(pp.Price.CurrentPrice == 45);
        }
    }
}