using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class ForeignkeyCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historicals_Receipts_ReceiptId",
                table: "Historicals");

            migrationBuilder.DropIndex(
                name: "IX_Historicals_ReceiptId",
                table: "Historicals");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "Historicals");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Receipts",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Historicals_Id",
                table: "Receipts",
                column: "Id",
                principalTable: "Historicals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Historicals_Id",
                table: "Receipts");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Receipts",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "ReceiptId",
                table: "Historicals",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Historicals_ReceiptId",
                table: "Historicals",
                column: "ReceiptId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Historicals_Receipts_ReceiptId",
                table: "Historicals",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
