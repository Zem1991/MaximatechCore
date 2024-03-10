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

        [Required(ErrorMessage = "The Codigo is Required")]
        //[MinLength(3)]
        //[MaxLength(100)]
        [DisplayName("Codigo")]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Descricao is Required")]
        //[MinLength(5)]
        //[MaxLength(200)]
        [DisplayName("Descricao")]
        public string Descricao { get; set; } = string.Empty;
    }
}
