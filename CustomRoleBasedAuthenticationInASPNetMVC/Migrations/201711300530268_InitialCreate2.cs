namespace CustomRoleBasedAuthenticationInASPNetMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Action", newName: "ControllerAction");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ControllerAction", newName: "Action");
        }
    }
}
