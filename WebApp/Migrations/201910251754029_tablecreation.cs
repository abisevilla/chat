namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablecreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id_Message = c.Guid(nullable: false, identity: true),
                        NickName = c.String(),
                    })
                .PrimaryKey(t => t.Id_Message);
            
            CreateTable(
                "dbo.Room_Message",
                c => new
                    {
                        Id_Room_Message = c.Guid(nullable: false, identity: true),
                        Message_Id_Message = c.Guid(),
                        Room_Id_Room = c.Guid(),
                    })
                .PrimaryKey(t => t.Id_Room_Message)
                .ForeignKey("dbo.Messages", t => t.Message_Id_Message)
                .ForeignKey("dbo.Rooms", t => t.Room_Id_Room)
                .Index(t => t.Message_Id_Message)
                .Index(t => t.Room_Id_Room);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id_Room = c.Guid(nullable: false, identity: true),
                        RoomName = c.String(),
                    })
                .PrimaryKey(t => t.Id_Room);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id_User = c.Guid(nullable: false, identity: true),
                        NickName = c.String(),
                    })
                .PrimaryKey(t => t.Id_User);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Room_Message", "Room_Id_Room", "dbo.Rooms");
            DropForeignKey("dbo.Room_Message", "Message_Id_Message", "dbo.Messages");
            DropIndex("dbo.Room_Message", new[] { "Room_Id_Room" });
            DropIndex("dbo.Room_Message", new[] { "Message_Id_Message" });
            DropTable("dbo.Users");
            DropTable("dbo.Rooms");
            DropTable("dbo.Room_Message");
            DropTable("dbo.Messages");
        }
    }
}
