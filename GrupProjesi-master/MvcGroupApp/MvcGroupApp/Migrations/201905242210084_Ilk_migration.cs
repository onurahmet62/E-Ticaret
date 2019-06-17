namespace MvcGroupApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Ilk_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Baskets",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    BasketPrice = c.Single(nullable: false),
                    Amount = c.Int(nullable: false),
                    ProductId = c.Int(nullable: false),
                    UserId = c.Int(nullable: false),
                    CreateDate = c.DateTime(nullable: false),
                    CreatedBy = c.String(),
                    UpdateDate = c.DateTime(nullable: false),
                    UpdatedBy = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.Products",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ProductName = c.String(nullable: false, maxLength: 200),
                    ProductPhoto = c.String(),
                    ProductPrice = c.Single(nullable: false),
                    StokState = c.Int(nullable: false),
                    IsItDeleted = c.Boolean(nullable: false),
                    CreateDate = c.DateTime(nullable: false),
                    CreatedBy = c.String(),
                    UpdateDate = c.DateTime(nullable: false),
                    UpdatedBy = c.String(),
                    brand_Id = c.Int(),
                    category_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.brand_Id)
                .ForeignKey("dbo.Categories", t => t.category_Id)
                .Index(t => t.brand_Id)
                .Index(t => t.category_Id);

            CreateTable(
                "dbo.Brands",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    BrandName = c.String(nullable: false, maxLength: 50),
                    CreateDate = c.DateTime(nullable: false),
                    CreatedBy = c.String(),
                    UpdateDate = c.DateTime(nullable: false),
                    UpdatedBy = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Categories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CategoryName = c.String(nullable: false, maxLength: 200),
                    CreateDate = c.DateTime(nullable: false),
                    CreatedBy = c.String(),
                    UpdateDate = c.DateTime(nullable: false),
                    UpdatedBy = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.OrderDetails",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Total = c.Int(nullable: false),
                    Price = c.Single(nullable: false),
                    OrderId = c.Int(nullable: false),
                    ProductId = c.Int(nullable: false),
                    CreateDate = c.DateTime(nullable: false),
                    CreatedBy = c.String(),
                    UpdateDate = c.DateTime(nullable: false),
                    UpdatedBy = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);

            CreateTable(
                "dbo.Orders",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    OrderDate = c.DateTime(nullable: false),
                    OrderTotalPrice = c.Single(nullable: false),
                    OrderAddress = c.String(nullable: false, maxLength: 250),
                    UserId = c.Int(nullable: false),
                    ModelNumber = c.Int(nullable: false),
                    CreateDate = c.DateTime(nullable: false),
                    CreatedBy = c.String(),
                    UpdateDate = c.DateTime(nullable: false),
                    UpdatedBy = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserName = c.String(nullable: false, maxLength: 200),
                    UserSurname = c.String(nullable: false, maxLength: 200),
                    UserMail = c.String(nullable: false, maxLength: 200),
                    UserPhone = c.String(nullable: false, maxLength: 200),
                    UserAddress = c.String(nullable: false, maxLength: 200),
                    UserPassword = c.String(nullable: false, maxLength: 200),
                    UserType = c.String(nullable: false),
                    CreateDate = c.DateTime(nullable: false),
                    CreatedBy = c.String(),
                    UpdateDate = c.DateTime(nullable: false),
                    UpdatedBy = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.ProductSuppliers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ProductId = c.Int(nullable: false),
                    SupplierId = c.Int(nullable: false),
                    Date = c.DateTime(nullable: false),
                    PurchasePrice = c.Single(nullable: false),
                    OrderAmount = c.Int(nullable: false),
                    CreateDate = c.DateTime(nullable: false),
                    CreatedBy = c.String(),
                    UpdateDate = c.DateTime(nullable: false),
                    UpdatedBy = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.SupplierId);

            CreateTable(
                "dbo.Suppliers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    SupplierName = c.String(maxLength: 200),
                    SupplierSurname = c.String(maxLength: 200),
                    SupplierAddress = c.String(maxLength: 200),
                    SupplierPhone = c.String(maxLength: 200),
                    CreateDate = c.DateTime(nullable: false),
                    CreatedBy = c.String(),
                    UpdateDate = c.DateTime(nullable: false),
                    UpdatedBy = c.String(),
                })
                .PrimaryKey(t => t.Id);

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
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProductSuppliers", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.ProductSuppliers", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Baskets", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Products", "category_Id", "dbo.Categories");
            DropForeignKey("dbo.Products", "brand_Id", "dbo.Brands");
            DropForeignKey("dbo.Baskets", "ProductId", "dbo.Products");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProductSuppliers", new[] { "SupplierId" });
            DropIndex("dbo.ProductSuppliers", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Products", new[] { "category_Id" });
            DropIndex("dbo.Products", new[] { "brand_Id" });
            DropIndex("dbo.Baskets", new[] { "UserId" });
            DropIndex("dbo.Baskets", new[] { "ProductId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Suppliers");
            DropTable("dbo.ProductSuppliers");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
            DropTable("dbo.Products");
            DropTable("dbo.Baskets");
        }
    }
}
