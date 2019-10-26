namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemodelsstructure : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Room_Message", "Message_Id_Message", "dbo.Messages");
            DropForeignKey("dbo.Room_Message", "Room_Id_Room", "dbo.Rooms");
            DropIndex("dbo.Room_Message", new[] { "Message_Id_Message" });
            DropIndex("dbo.Room_Message", new[] { "Room_Id_Room" });
            DropPrimaryKey("dbo.Messages");
            DropPrimaryKey("dbo.Rooms");
            DropPrimaryKey("dbo.Users");
            CreateTable(
                "dbo.RoomMessages",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Room_Id = c.Guid(nullable: false),
                        Message_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Messages", t => t.Message_Id, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.Room_Id, cascadeDelete: true)
                .Index(t => t.Room_Id)
                .Index(t => t.Message_Id);
            
            AddColumn("dbo.Messages", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Rooms", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Users", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Messages", "Id");
            AddPrimaryKey("dbo.Rooms", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            DropColumn("dbo.Messages", "Id_Message");
            DropColumn("dbo.Rooms", "Id_Room");
            DropColumn("dbo.Users", "Id_User");
            DropTable("dbo.Room_Message");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Room_Message",
                c => new
                    {
                        Id_Room_Message = c.Guid(nullable: false, identity: true),
                        Message_Id_Message = c.Guid(),
                        Room_Id_Room = c.Guid(),
                    })
                .PrimaryKey(t => t.Id_Room_Message);
            
            AddColumn("dbo.Users", "Id_User", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Rooms", "Id_Room", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Messages", "Id_Message", c => c.Guid(nullable: false, identity: true));
            DropForeignKey("dbo.RoomMessages", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.RoomMessages", "Message_Id", "dbo.Messages");
            DropIndex("dbo.RoomMessages", new[] { "Message_Id" });
            DropIndex("dbo.RoomMessages", new[] { "Room_Id" });
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Rooms");
            DropPrimaryKey("dbo.Messages");
            DropColumn("dbo.Users", "Id");
            DropColumn("dbo.Rooms", "Id");
            DropColumn("dbo.Messages", "Id");
            DropTable("dbo.RoomMessages");
            AddPrimaryKey("dbo.Users", "Id_User");
            AddPrimaryKey("dbo.Rooms", "Id_Room");
            AddPrimaryKey("dbo.Messages", "Id_Message");
            CreateIndex("dbo.Room_Message", "Room_Id_Room");
            CreateIndex("dbo.Room_Message", "Message_Id_Message");
            AddForeignKey("dbo.Room_Message", "Room_Id_Room", "dbo.Rooms", "Id_Room");
            AddForeignKey("dbo.Room_Message", "Message_Id_Message", "dbo.Messages", "Id_Message");
        }
    }
}
