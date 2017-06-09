using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GM11.Migrations
{
    public partial class GMM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Part_Service_ServiceID",
                table: "Part");

            migrationBuilder.DropIndex(
                name: "IX_Part_ServiceID",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "ServiceID",
                table: "Part");

            migrationBuilder.RenameColumn(
                name: "PartID",
                table: "Service",
                newName: "PartsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PartsID",
                table: "Service",
                newName: "PartID");

            migrationBuilder.AddColumn<int>(
                name: "ServiceID",
                table: "Part",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Part_ServiceID",
                table: "Part",
                column: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Part_Service_ServiceID",
                table: "Part",
                column: "ServiceID",
                principalTable: "Service",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
