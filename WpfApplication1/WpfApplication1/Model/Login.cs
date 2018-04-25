using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.DAL;

namespace WpfApplication1.Model
{
    [Table("Logins")]
    public class Login
    {
        
            [Key]
            public int LoginId { get; set; }
            public string Usuario { get; set; }
            public string Senha { get; set; }
          

            public Login() { }

            public override string ToString()
            {
                return "\nUsuario: " + Usuario + "Senha" + Senha ;
            }


        }
}

