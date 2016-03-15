namespace SchoolLibrary.Migrations.SchoolLibraryMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBorrowingRecordsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BorrowingRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        BorrowingTime = c.DateTime(nullable: false),
                        Description = c.String(),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BorrowingRecords", "Book_Id", "dbo.Books");
            DropIndex("dbo.BorrowingRecords", new[] { "Book_Id" });
            DropTable("dbo.BorrowingRecords");
        }
    }
}
