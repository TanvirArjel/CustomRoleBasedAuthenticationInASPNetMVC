namespace CustomRoleBasedAuthenticationInASPNetMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleActionCategoryRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoleActionCategory", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.RoleActionCategory", "ActionCategoryId", "dbo.ActionCategories");
            DropIndex("dbo.RoleActionCategory", new[] { "RoleId" });
            DropIndex("dbo.RoleActionCategory", new[] { "ActionCategoryId" });
            DropTable("dbo.RoleActionCategory");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RoleActionCategory",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        ActionCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.ActionCategoryId });
            
            CreateIndex("dbo.RoleActionCategory", "ActionCategoryId");
            CreateIndex("dbo.RoleActionCategory", "RoleId");
            AddForeignKey("dbo.RoleActionCategory", "ActionCategoryId", "dbo.ActionCategories", "ActionCategoryId", cascadeDelete: true);
            AddForeignKey("dbo.RoleActionCategory", "RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
        }
    }
}
