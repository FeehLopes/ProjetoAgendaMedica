using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model
{
    [Table("Registros")]
    class Registro
    {
        [Key]
        public int RegistroId { get; set; }

        public string TipoDeServico { get; set; }
        public Decimal ValorServico { get; set; }
        public Cliente Cliente { get; set; }
        public string DataServico { get; set; }

        public Registro() { }

        public override string ToString()
        {
            return "\nTipoDeServico: " + TipoDeServico + "ValorServico" + ValorServico + "Cliente" + Cliente + "DataServico" + DataServico;

        }
    }
}
