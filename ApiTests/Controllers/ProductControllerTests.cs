using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Dtos;
using Bogus;
using Infrastructure.Context;
using Moq;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Context.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using FluentAssertions;

namespace Api.Controllers.Tests
{
    [TestClass()]
    public class ProductControllerTests
    {
        [TestMethod()]
        public async Task GetAllAsyncTest()
        {
            int amount = 1;
            List<Product> data = GenerateData(amount);
            IQueryable<Product> dataQueryable = data.AsQueryable();
            Mock<DbSet<Product>> mockDbSet = new();
            mockDbSet.As<IQueryable>().Setup(m => m.Provider).Returns(dataQueryable.Provider);
            mockDbSet.As<IQueryable>().Setup(m => m.Expression).Returns(dataQueryable.Expression);
            mockDbSet.As<IQueryable>().Setup(m => m.ElementType).Returns(dataQueryable.ElementType);
            mockDbSet.As<IQueryable>().Setup(m => m.GetEnumerator()).Returns(dataQueryable.GetEnumerator);
            Mock<ApplicationDbContext> mockDbContext = new();
            mockDbContext.Setup(x => x.Set<Product>()).Returns(mockDbSet.Object);
            IProductRepository repository = new ProductRepository(mockDbContext.Object);
            Product toInsert = data.FirstOrDefault();
            bool result = await repository.InsertAsync(toInsert);
            result.Should().BeTrue();
        }

        private List<Product> GenerateData(int count)
        {
            Faker<Product> faker = new Faker<Product>()
                .RuleFor(x => x.Codigo, f => f.Commerce.Department())
                .RuleFor(x => x.Descricao, f => f.Commerce.Product())
                .RuleFor(x => x.Preco, f => f.Commerce.Random.Decimal())
                .RuleFor(x => x.Status, f => f.Commerce.Random.Bool());
            return faker.Generate(count);
        }
    }
}