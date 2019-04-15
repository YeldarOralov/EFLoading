namespace EFLoading.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Author_Id1", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "Author_Id1" });
            RenameColumn(table: "dbo.Books", name: "Author_Id1", newName: "AuthorId");
            AlterColumn("dbo.Books", "AuthorId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Books", "AuthorId");
            AddForeignKey("dbo.Books", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
            DropColumn("dbo.Books", "Author_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Author_Id", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "AuthorId" });
            AlterColumn("dbo.Books", "AuthorId", c => c.Guid());
            RenameColumn(table: "dbo.Books", name: "AuthorId", newName: "Author_Id1");
            CreateIndex("dbo.Books", "Author_Id1");
            AddForeignKey("dbo.Books", "Author_Id1", "dbo.Authors", "Id");
        }
    }
}
