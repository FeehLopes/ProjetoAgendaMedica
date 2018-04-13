using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Model;

namespace WpfApplication1.Controller
{
    class Context : DbContext
    {
        public DbSet<Login> Logins{ get; set; }
    }
}
