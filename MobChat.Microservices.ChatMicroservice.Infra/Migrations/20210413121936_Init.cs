using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MobChat.Microservices.ChatMicroservice.Infra.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstMemberId = table.Column<Guid>(nullable: false),
                    FirstMemberName = table.Column<string>(nullable: true),
                    FirstMemberPhoto = table.Column<string>(nullable: true),
                    SecondMemberId = table.Column<Guid>(nullable: false),
                    SecondMemberName = table.Column<string>(nullable: true),
                    SecondMemberPhoto = table.Column<string>(nullable: true),
                    FirstMessageDate = table.Column<DateTime>(nullable: false),
                    LastMessageDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    IsOnline = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConnectedUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ContextUserId = table.Column<string>(nullable: true),
                    ConnectionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectedUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfflineTextMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReceiverId = table.Column<Guid>(nullable: false),
                    SenderId = table.Column<Guid>(nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfflineTextMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TextMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ChatId = table.Column<Guid>(nullable: false),
                    SenderId = table.Column<Guid>(nullable: false),
                    SenderName = table.Column<string>(nullable: true),
                    SenderPhoto = table.Column<string>(nullable: true),
                    ReceiverId = table.Column<Guid>(nullable: false),
                    ReceiverName = table.Column<string>(nullable: true),
                    ReceiverPhoto = table.Column<string>(nullable: true),
                    MessageDate = table.Column<DateTime>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextMessage", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "ConnectedUser");

            migrationBuilder.DropTable(
                name: "OfflineTextMessage");

            migrationBuilder.DropTable(
                name: "TextMessage");
        }
    }
}
