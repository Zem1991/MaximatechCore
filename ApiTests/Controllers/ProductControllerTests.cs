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
using Microsoft.Extensions.Configuration;

namespace Api.Controllers.Tests
{
    [TestClass()]
    public class ProductControllerTests
    {
        private int initialDataAmount = 10;
        private List<Product> initialData;
        private IProductRepository repository;

        [TestInitialize()]
        public async Task Initialize()
        {
            initialData = GenerateData(initialDataAmount);
            IQueryable<Product> dataQueryable = initialData.AsQueryable();
            Mock<DbSet<Product>> mockDbSet = new();
            mockDbSet.As<IQueryable>().Setup(m => m.Provider).Returns(dataQueryable.Provider);
            mockDbSet.As<IQueryable>().Setup(m => m.Expression).Returns(dataQueryable.Expression);
            mockDbSet.As<IQueryable>().Setup(m => m.ElementType).Returns(dataQueryable.ElementType);
            mockDbSet.As<IQueryable>().Setup(m => m.GetEnumerator()).Returns(dataQueryable.GetEnumerator);
            Mock<ApplicationDbContext> mockDbContext = new();
            mockDbContext.Setup(x => x.Set<Product>()).Returns(mockDbSet.Object);
            IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
            repository = new ProductRepository(mockDbContext.Object, configuration);
        }

        [TestMethod()]
        public async Task GetAllAsyncTest()
        {
            IEnumerable<Product> products = await repository.GetAllAsync();
            products.Count().Should().Be(initialDataAmount);
        }

        [TestMethod()]
        public async Task InsertAsyncTest()
        {
            Product data = GenerateData(1).First();
            bool result = await repository.InsertAsync(data);
            result.Should().BeTrue();
        }

        [TestMethod()]
        public async Task UpdateAsyncTest()
        {
            Product data = GenerateData(1).First();
            bool result = await repository.UpdateAsync(data);
            result.Should().BeTrue();
        }

        [TestMethod()]
        public async Task DeleteAsyncTest()
        {
            Product data = GenerateData(1).First();
            bool result = await repository.DeleteAsync(data);
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