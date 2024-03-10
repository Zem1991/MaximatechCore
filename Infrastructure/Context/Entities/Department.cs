using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.Entities
{
    [Table("DEPARTMENT")]
    public class Department : BaseEntity
    {
        [Column("Codigo")]
        public string Codigo { get; set; } = string.Empty;
        [Column("Descricao")]
        public string Descricao { get; set; } = string.Empty;
    }
}
