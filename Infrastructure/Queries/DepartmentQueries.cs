using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public static class DepartmentQueries
    {
        public static string GetAll { get; } = @"SELECT ""Id"", ""Codigo"", ""Descricao"" FROM public.""DEPARTMENT"";";
    }
}
