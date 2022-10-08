using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tls.api.Migrations
{
    public partial class SeeProductTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductReferences",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "https://tlsfilestorage.blob.core.windows.net/assets/lemon.svg", "Pink Lemonade" });

            migrationBuilder.InsertData(
                table: "ProductReferences",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "https://tlsfilestorage.blob.core.windows.net/assets/lemon.svg", "Lemonade" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImageUrl", "Price", "ProductReferenceId", "SizeName", "SizeValue" },
                values: new object[,]
                {
                    { new Guid("2332aa04-9621-40e5-b383-4c0763f486ed"), null, 1.0, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Regular", 1 },
                    { new Guid("24625f9e-0e4a-49c7-835c-fd54d4e07971"), null, 1.0, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Regular", 1 },
                    { new Guid("c9bf56b2-7154-478d-8cf2-cb9d11de7694"), null, 1.5, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Large", 2 },
                    { new Guid("d31373c2-902e-441d-9d9f-c0fb987f929d"), null, 1.5, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Large", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2332aa04-9621-40e5-b383-4c0763f486ed"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("24625f9e-0e4a-49c7-835c-fd54d4e07971"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c9bf56b2-7154-478d-8cf2-cb9d11de7694"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d31373c2-902e-441d-9d9f-c0fb987f929d"));

            migrationBuilder.DeleteData(
                table: "ProductReferences",
                keyColumn: "Id",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "ProductReferences",
                keyColumn: "Id",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));
        }
    }
}
