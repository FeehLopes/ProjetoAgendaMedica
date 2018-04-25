using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model
{
    [Table("Clientes")]
    class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }

        public string NomePet {get; set;}
        public string Raca { get; set; }
        public string Idade { get; set; }
        public string Data { get; set; }
        public string Sexo { get; set; }

        public Cliente() { }

        public override string ToString()
        {
            return "\nNome: " + Nome +"CPF" + CPF + "Numero" + Numero + "Endereco" + Endereco  + "Telefone" + Telefone
                 + "Celular" + Celular + "Complemento" + Complemento + "NomePet" + NomePet + "Raca" + Raca + "Idade" + Idade 
                 + "Data" + Data + "Sexo" + Sexo;
        }
    }
}
