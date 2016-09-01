namespace ProyectoAlfredo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastPurchase = c.DateTime(nullable: false),
                        UploadDate = c.DateTime(nullable: false),
                        Stock = c.Single(nullable: false),
                        minimum = c.Single(nullable: false),
                        State = c.Boolean(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.ProductProviders",
                c => new
                    {
                        ProductProviderID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        ProviderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductProviderID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Providers", t => t.ProviderID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.ProviderID);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        ProviderID = c.Int(nullable: false, identity: true),
                        ProviderName = c.String(nullable: false),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProviderID);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseID = c.Int(nullable: false, identity: true),
                        DatePurchase = c.DateTime(nullable: false),
                        UploadDate = c.DateTime(nullable: false),
                        ProviderID = c.Int(nullable: false),
                        Quantity = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseID)
                .ForeignKey("dbo.Providers", t => t.ProviderID, cascadeDelete: true)
                .Index(t => t.ProviderID);
            
            CreateTable(
                "dbo.ProductPurchases",
                c => new
                    {
                        ProductPurchaseID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        PurchaseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductPurchaseID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.PurchaseID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.PurchaseID);
            
            CreateTable(
                "dbo.ProductSales",
                c => new
                    {
                        ProductSaleID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        SaleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductSaleID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.SaleID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.SaleID);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleID = c.Int(nullable: false, identity: true),
                        SaleDate = c.DateTime(nullable: false),
                        UploadDate = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        Quantity = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.SaleID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false),
                        Address = c.String(),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductSales", "SaleID", "dbo.Sales");
            DropForeignKey("dbo.Sales", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.ProductSales", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Purchases", "ProviderID", "dbo.Providers");
            DropForeignKey("dbo.ProductPurchases", "PurchaseID", "dbo.Purchases");
            DropForeignKey("dbo.ProductPurchases", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductProviders", "ProviderID", "dbo.Providers");
            DropForeignKey("dbo.ProductProviders", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Sales", new[] { "CustomerID" });
            DropIndex("dbo.ProductSales", new[] { "SaleID" });
            DropIndex("dbo.ProductSales", new[] { "ProductID" });
            DropIndex("dbo.ProductPurchases", new[] { "PurchaseID" });
            DropIndex("dbo.ProductPurchases", new[] { "ProductID" });
            DropIndex("dbo.Purchases", new[] { "ProviderID" });
            DropIndex("dbo.ProductProviders", new[] { "ProviderID" });
            DropIndex("dbo.ProductProviders", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropTable("dbo.Customers");
            DropTable("dbo.Sales");
            DropTable("dbo.ProductSales");
            DropTable("dbo.ProductPurchases");
            DropTable("dbo.Purchases");
            DropTable("dbo.Providers");
            DropTable("dbo.ProductProviders");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
