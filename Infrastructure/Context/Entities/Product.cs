using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.Entities
{
    [Table("PRODUCT")]
    public class Product : BaseEntity
    {
        [Column("Codigo")]
        public string Codigo { get; set; } = string.Empty;
        [Column("Descricao")]
        public string Descricao { get; set; } = string.Empty;
        [Column("IdDepartamento")]
        public int IdDepartamento { get; set; }
        [Column("Preco")]
        public decimal Preco { get; set; }
        [Column("Status")]
        public bool Status { get; set; }
    }
}
