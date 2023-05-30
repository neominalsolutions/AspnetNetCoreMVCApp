using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspnetNetCoreMVCApp.Migrations
{
    public partial class AccountConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Customers_CustomerId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransaction_Accounts_AccountId",
                table: "AccountTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "Musteri");

            migrationBuilder.RenameColumn(
                name: "AccountNumber",
                table: "Musteri",
                newName: "MusteriNo");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_CustomerId",
                table: "Musteri",
                newName: "IX_Musteri_CustomerId");

            migrationBuilder.AlterColumn<string>(
                name: "MusteriNo",
                table: "Musteri",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Musteri",
                table: "Musteri",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransaction_Musteri_AccountId",
                table: "AccountTransaction",
                column: "AccountId",
                principalTable: "Musteri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musteri_Customers_CustomerId",
                table: "Musteri",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransaction_Musteri_AccountId",
                table: "AccountTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Musteri_Customers_CustomerId",
                table: "Musteri");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Musteri",
                table: "Musteri");

            migrationBuilder.RenameTable(
                name: "Musteri",
                newName: "Accounts");

            migrationBuilder.RenameColumn(
                name: "MusteriNo",
                table: "Accounts",
                newName: "AccountNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Musteri_CustomerId",
                table: "Accounts",
                newName: "IX_Accounts_CustomerId");

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Customers_CustomerId",
                table: "Accounts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransaction_Accounts_AccountId",
                table: "AccountTransaction",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
