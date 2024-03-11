using Infrastructure.Context.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Infrastructure.Queries;
using Npgsql;

namespace Infrastructure.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private string ConnectionString { get; } = string.Empty;

        public DepartmentRepository(ApplicationDbContext context, IConfiguration configuration) : base(context)
        {
            ConnectionString = configuration.GetConnectionString("TesteMaximatech");
        }

        public override async Task<List<Department>> GetAllAsync()
        {
            string queryString = DepartmentQueries.GetAll;
            List<Department> funcResult(NpgsqlDataReader reader)
            {
                List<Department> resultList = new();
                while (reader.Read())
                {
                    Department entity = new()
                    {
                        Id = (int)reader["Id"],
                        Codigo = (string)reader["Codigo"],
                        Descricao = (string)reader["Descricao"],
                    };
                    resultList.Add(entity);
                }
                return resultList;
            }
            return await CustomQuery(ConnectionString, queryString, funcResult);
        }
    }
}
