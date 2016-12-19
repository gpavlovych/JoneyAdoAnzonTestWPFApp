namespace MyApplication.Desktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RowBases",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        State = c.Int(),
                        Text = c.String(),
                        Selected = c.Boolean(),
                        Selected1 = c.Boolean(),
                        RowType = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RowBases");
        }
    }
}
