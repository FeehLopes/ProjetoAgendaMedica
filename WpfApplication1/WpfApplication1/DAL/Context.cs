using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Model;
using WpfApplication1.Views;

namespace WpfApplication1.DAL
{
    class Context : DbContext

    {
        public Context() : base("stringConn")
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<Context>()
                 );
        }


        public DbSet<Login> Logins { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Registro> Registros { get; set; }


        // 
    }
}
