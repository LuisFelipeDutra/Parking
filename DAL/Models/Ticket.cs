using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }
        [Required]
        [StringLength(7, MinimumLength = 7)] //placa com no mínimo 7 e no máximo 7 letras
        public string Placa { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Data de Entrada")]
        public DateTime DataEntrada { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Data de Saída")]
        public DateTime DataSaida { get; set; }
        public bool SegundaVia { get; set; }

        //Sem pagamento (Outros,Emergência,Evento Especial)
        public List<string> MotivoLiberacaoEspecifico = new List<string>(new string[] { "Emergencia", "Evento Especial", "Outros" });
        
        public string MotivoLiberacaoGeral { get; set; }
        public string MotivoSegundaVia { get; set; }
        
        
        public double Valor { get; set; }
        public bool Liberado { get; set; }

        public int VagaID { get; set; }
        public virtual Vaga Vaga { get; set; }
    }
}
