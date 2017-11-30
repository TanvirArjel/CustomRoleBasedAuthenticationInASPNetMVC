namespace CustomRoleBasedAuthenticationInASPNetMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionCategories",
                c => new
                    {
                        ActionCategoryId = c.Int(nullable: false, identity: true),
                        ActionCategoryName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ActionCategoryId)
                .Index(t => t.ActionCategoryName, unique: true, name: "Ix_ActionCategoryNameUnique");
            
            CreateTable(
                "dbo.Action",
                c => new
                    {
                        ControllerActionId = c.Int(nullable: false, identity: true),
                        ActionCategoryId = c.Int(nullable: false),
                        ActionName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ControllerActionId)
                .ForeignKey("dbo.ActionCategories", t => t.ActionCategoryId, cascadeDelete: true)
                .Index(t => t.ActionCategoryId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId)
                .Index(t => t.RoleName, unique: true, name: "Ix_RoleNameUnique");
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.UserName, unique: true, name: "Ix_UserNameUnique");
            
            CreateTable(
                "dbo.UserPasswordResets",
                c => new
                    {
                        PasswordResetId = c.Long(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PasswordResetToken = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsReset = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PasswordResetId);
            
            CreateTable(
                "dbo.RoleActionCategory",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        ActionCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.ActionCategoryId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.ActionCategories", t => t.ActionCategoryId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.ActionCategoryId);
            
            CreateTable(
                "dbo.RoleControllerAction",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        ControllerActionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.ControllerActionId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Action", t => t.ControllerActionId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.ControllerActionId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.Users");
            DropForeignKey("dbo.RoleControllerAction", "ControllerActionId", "dbo.Action");
            DropForeignKey("dbo.RoleControllerAction", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.RoleActionCategory", "ActionCategoryId", "dbo.ActionCategories");
            DropForeignKey("dbo.RoleActionCategory", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Action", "ActionCategoryId", "dbo.ActionCategories");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.RoleControllerAction", new[] { "ControllerActionId" });
            DropIndex("dbo.RoleControllerAction", new[] { "RoleId" });
            DropIndex("dbo.RoleActionCategory", new[] { "ActionCategoryId" });
            DropIndex("dbo.RoleActionCategory", new[] { "RoleId" });
            DropIndex("dbo.Users", "Ix_UserNameUnique");
            DropIndex("dbo.Roles", "Ix_RoleNameUnique");
            DropIndex("dbo.Action", new[] { "ActionCategoryId" });
            DropIndex("dbo.ActionCategories", "Ix_ActionCategoryNameUnique");
            DropTable("dbo.UserRole");
            DropTable("dbo.RoleControllerAction");
            DropTable("dbo.RoleActionCategory");
            DropTable("dbo.UserPasswordResets");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Action");
            DropTable("dbo.ActionCategories");
        }
    }
}
