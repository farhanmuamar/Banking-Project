using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class TransaksilMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaksi_Nasabah_AccountId",
                table: "Transaksi");

            migrationBuilder.DropIndex(
                name: "IX_Transaksi_AccountId",
                table: "Transaksi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Transaksi_AccountId",
                table: "Transaksi",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaksi_Nasabah_AccountId",
                table: "Transaksi",
                column: "AccountId",
                principalTable: "Nasabah",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
