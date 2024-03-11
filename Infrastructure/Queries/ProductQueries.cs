using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public static class ProductQueries
    {
        public static string GetAll { get; } = @"SELECT ""Id"", ""Codigo"", ""Descricao"", ""Preco"", ""Status"", ""IdDepartamento"" FROM public.""PRODUCT"";";
    }
}
