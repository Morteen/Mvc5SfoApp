namespace SfoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ansatts",
                c => new
                    {
                        AnsattId = c.Int(nullable: false, identity: true),
                        Fornavn = c.String(nullable: false),
                        Etternavn = c.String(nullable: false),
                        Username = c.String(),
                        Password = c.String(maxLength: 18),
                        SkoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnsattId)
                .ForeignKey("dbo.Skoles", t => t.SkoleId, cascadeDelete: false)
                .Index(t => t.SkoleId);
            
            CreateTable(
                "dbo.Skoles",
                c => new
                    {
                        SkoleId = c.Int(nullable: false, identity: true),
                        SkoleNavn = c.String(),
                    })
                .PrimaryKey(t => t.SkoleId);
            
            CreateTable(
                "dbo.Elevs",
                c => new
                    {
                        ElevId = c.Int(nullable: false, identity: true),
                        Fornavn = c.String(nullable: false),
                        Etternavn = c.String(nullable: false),
                        Trinn = c.Int(nullable: false),
                        Klasse = c.String(),
                        Telefon = c.String(),
                        SkoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ElevId)
                .ForeignKey("dbo.Skoles", t => t.SkoleId, cascadeDelete: true)
                .Index(t => t.SkoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SjekkInLoggs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SjekkInn = c.DateTime(nullable: false),
                        SjekkUt = c.DateTime(nullable: false),
                        Aar = c.DateTime(nullable: false),
                        Dato = c.DateTime(nullable: false),
                        Info = c.String(),
                        ElevId = c.Int(nullable: false),
                        AnsattId = c.Int(nullable: false),
                        SkoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ansatts", t => t.AnsattId, cascadeDelete: false)
                .ForeignKey("dbo.Elevs", t => t.ElevId, cascadeDelete: false)
                .ForeignKey("dbo.Skoles", t => t.SkoleId, cascadeDelete: false)
                .Index(t => t.ElevId)
                .Index(t => t.AnsattId)
                .Index(t => t.SkoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SjekkInLoggs", "SkoleId", "dbo.Skoles");
            DropForeignKey("dbo.SjekkInLoggs", "ElevId", "dbo.Elevs");
            DropForeignKey("dbo.SjekkInLoggs", "AnsattId", "dbo.Ansatts");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Elevs", "SkoleId", "dbo.Skoles");
            DropForeignKey("dbo.Ansatts", "SkoleId", "dbo.Skoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.SjekkInLoggs", new[] { "SkoleId" });
            DropIndex("dbo.SjekkInLoggs", new[] { "AnsattId" });
            DropIndex("dbo.SjekkInLoggs", new[] { "ElevId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Elevs", new[] { "SkoleId" });
            DropIndex("dbo.Ansatts", new[] { "SkoleId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SjekkInLoggs");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Elevs");
            DropTable("dbo.Skoles");
            DropTable("dbo.Ansatts");
        }
    }
}
