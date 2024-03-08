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
        [Column("NAME")]
        public string Name { get; set; } = string.Empty;
        [Column("DESCRIPTION")]
        public string Description { get; set; } = string.Empty;
        [Column("PRICE")]
        public decimal Price { get; set; }
        [Column("STOCK")]
        public int Stock { get; set; }
    }
}
