namespace MvcFriendcode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotationsMig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FriendCodes", "User", c => c.String(nullable: false));
            AlterColumn("dbo.FriendCodes", "Code", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FriendCodes", "Code", c => c.String());
            AlterColumn("dbo.FriendCodes", "User", c => c.String());
        }
    }
}
