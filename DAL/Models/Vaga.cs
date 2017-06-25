using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Vaga
    {
        [Key]
        public int VagaID { get; set; }
        [Required]
        public bool Ocupada { get; set; } //True para sim e false para não

        public virtual List<Ticket> Tickets { get; set; }
    }
}
