namespace GeneralStoreApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        SKU = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Cost = c.Double(nullable: false),
                        NumberInInventory = c.Int(nullable: false),
                        IsInStock = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SKU);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ProductSKU = c.String(maxLength: 128),
                        ItemCount = c.Int(nullable: false),
                        DateOfTransaction = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductSKU)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductSKU);
            
            AddColumn("dbo.Customers", "FirstName", c => c.String());
            AddColumn("dbo.Customers", "LasName", c => c.String());
            AddColumn("dbo.Customers", "FullName", c => c.String());
            DropColumn("dbo.Customers", "Name");
            DropColumn("dbo.Customers", "Address");
            DropColumn("dbo.Customers", "State");
            DropColumn("dbo.Customers", "City");
            DropColumn("dbo.Customers", "ZipCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "ZipCode", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "City", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "State", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Address", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Name", c => c.String(nullable: false));
            DropForeignKey("dbo.Transactions", "ProductSKU", "dbo.Products");
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "ProductSKU" });
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            DropColumn("dbo.Customers", "FullName");
            DropColumn("dbo.Customers", "LasName");
            DropColumn("dbo.Customers", "FirstName");
            DropTable("dbo.Transactions");
            DropTable("dbo.Products");
        }
    }
}
