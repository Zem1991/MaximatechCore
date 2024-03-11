using Infrastructure.Context.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Queries;
using Npgsql;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private string ConnectionString { get; } = string.Empty;

        public ProductRepository(ApplicationDbContext context, IConfiguration configuration) : base(context)
        {
            ConnectionString = configuration.GetConnectionString("TesteMaximatech");
        }

        public override async Task<List<Product>> GetAllAsync()
        {
            string queryString = ProductQueries.GetAll;
            List<Product> funcResult(NpgsqlDataReader reader)
            {
                List<Product> resultList = new();
                while (reader.Read())
                {
                    Product entity = new()
                    {
                        Id = (int)reader["Id"],
                        Codigo = (string)reader["Codigo"],
                        Descricao = (string)reader["Descricao"],
                        IdDepartamento = (int)reader["IdDepartamento"],
                        Preco = (decimal)reader["Preco"],
                        Status = (bool)reader["Status"],
                    };
                    resultList.Add(entity);
                }
                return resultList;
            }
            return await CustomQuery(ConnectionString, queryString, funcResult);
        }
    }
}
