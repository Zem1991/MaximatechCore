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

        [Required(ErrorMessage = "Este campo é obrigatório")]
        //[MinLength(3)]
        //[MaxLength(100)]
        [DisplayName("Código")]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo é obrigatório")]
        //[MinLength(5)]
        //[MaxLength(200)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo é obrigatório")]
        //[MinLength(5)]
        //[MaxLength(200)]
        [DisplayName("Departamento")]
        public int IdDepartamento { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayName("Ativo?")]
        public bool Status { get; set; }
    }
}
