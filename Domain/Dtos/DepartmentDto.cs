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
    public class DepartmentDto
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
    }
}
