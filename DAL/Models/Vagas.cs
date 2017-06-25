using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Vagas
    {
        [Key]
        public int CodigoID { get; set; }
        [Required]
        public bool Ocupada { get; set; } //True para sim e false para não
    }
}
