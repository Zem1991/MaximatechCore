using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Codigo is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Codigo")]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Descricao is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Descricao")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Departamento is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Departamento")]
        public string Departamento { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Preco is Required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preco")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "The Status is Required")]
        [DisplayName("Status")]
        public bool Status { get; set; }
    }
}
