namespace WpfApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Logins");
            AddColumn("dbo.Logins", "UsuarioId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Logins", "Usuario", c => c.String());
            AddPrimaryKey("dbo.Logins", "UsuarioId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Logins");
            AlterColumn("dbo.Logins", "Usuario", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Logins", "UsuarioId");
            AddPrimaryKey("dbo.Logins", "Usuario");
        }
    }
}
