using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examino.Infrastructure.Migrations
{
    public partial class changingPeselToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PESEL",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Raports",
                keyColumn: "Id",
                keyValue: new Guid("a34d644f-55fc-4a39-addd-a8cc07f89c34"),
                column: "RaportTime",
                value: new DateTimeOffset(new DateTime(2022, 5, 14, 7, 46, 34, 864, DateTimeKind.Unspecified).AddTicks(129), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Raports",
                keyColumn: "Id",
                keyValue: new Guid("b03172a3-fc8f-4419-a63e-618359d4cd99"),
                column: "RaportTime",
                value: new DateTimeOffset(new DateTime(2022, 5, 14, 7, 46, 34, 864, DateTimeKind.Unspecified).AddTicks(192), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Raports",
                keyColumn: "Id",
                keyValue: new Guid("c72b703e-21f0-45ea-9323-e1362b494cb1"),
                column: "RaportTime",
                value: new DateTimeOffset(new DateTime(2022, 5, 14, 7, 46, 34, 864, DateTimeKind.Unspecified).AddTicks(200), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Raports",
                keyColumn: "Id",
                keyValue: new Guid("fd01f84e-8917-461a-8d6d-b5758a6065b2"),
                column: "RaportTime",
                value: new DateTimeOffset(new DateTime(2022, 5, 14, 7, 46, 34, 864, DateTimeKind.Unspecified).AddTicks(206), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8931ce67-348b-48b6-96fc-6fc47a74311e"),
                columns: new[] { "ConcurrencyStamp", "PESEL", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c51ccbc5-bb54-4b23-a7dd-e121c746f9b2", "99101912345", "AQAAAAEAACcQAAAAEIOsHxJsz8H91GU1zYALgyP07cTLmBYsXOSQwIigxhFUxR974kxyklu0PFnZhiPbxA==", "c3e30320-9336-43a6-b91f-43f0eca3d03e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ae47d26c-b934-4057-8d05-dfd78ea1a138"),
                columns: new[] { "ConcurrencyStamp", "PESEL", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85065441-56b1-42ae-bcff-105aa2e81ea9", "66030280889", "AQAAAAEAACcQAAAAEAfi5uPTDE4cLEenAyNeZPS7jzAWM33hniFm08u5NY9y7Oy84S9VNanSevFAl4P+uQ==", "063346bf-a96a-4095-ae04-17864db27fe6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d9339e74-284d-46f4-ad46-b13269c4900e"),
                columns: new[] { "ConcurrencyStamp", "PESEL", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0b537e0-ff5d-4eb9-abfe-58082308a0c8", "60070111229", "AQAAAAEAACcQAAAAEJSNZklf2zoJlTGtgdhESrGYVxtmwaGa1XxKwlz38K2KrMCDFE1NApkh6lWu32TPog==", "63eab17a-6915-422d-b4df-998c31943309" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4d9b6996-8e8a-4cec-9f2f-d7f64e2113ca"),
                columns: new[] { "ConcurrencyStamp", "PESEL", "PasswordHash", "SecurityStamp" },
                values: new object[] { "836a9c03-4f5e-4d4e-9f4a-a94981cd60fe", "78032180802", "AQAAAAEAACcQAAAAEF0vo6RVfMFeMRGjmYGXA+P6AzOALg8T++KBfHez8K6iA2wz4TbJIzKDrd+93bO1dw==", "09d31b20-53af-4bb0-ab2b-f8826758cab6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c394c3c5-3727-4b3b-999f-de8180edf15f"),
                columns: new[] { "ConcurrencyStamp", "PESEL", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8216bd4-4d78-4b46-88f0-9803342821f7", "90042182882", "AQAAAAEAACcQAAAAEBXqyFHvR7MFiu9BOzWwKTZSgEFjJM2GzzYTIZYt8yiOP2ETJhItTU4j7Gaz7Le0pg==", "b08916cd-fb23-4919-b136-23dcb0484f03" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f43c4920-a607-4d32-a937-ba324e07ebd6"),
                columns: new[] { "ConcurrencyStamp", "PESEL", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1239327d-a230-4402-967b-56b133986a19", "99042382888", "AQAAAAEAACcQAAAAEAuZdYiNQXykwf6DCR+Z1YkdsTJR6yksPmh4CAc+LjhJVe0yRLWS2fZHXLleMKtbBQ==", "f7e982f9-24d6-4ad9-b285-86ae03723238" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                name: "PESEL",
                table: "Users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Raports",
                keyColumn: "Id",
                keyValue: new Guid("a34d644f-55fc-4a39-addd-a8cc07f89c34"),
                column: "RaportTime",
                value: new DateTimeOffset(new DateTime(2022, 4, 26, 16, 42, 12, 158, DateTimeKind.Unspecified).AddTicks(1011), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Raports",
                keyColumn: "Id",
                keyValue: new Guid("b03172a3-fc8f-4419-a63e-618359d4cd99"),
                column: "RaportTime",
                value: new DateTimeOffset(new DateTime(2022, 4, 26, 16, 42, 12, 158, DateTimeKind.Unspecified).AddTicks(1067), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Raports",
                keyColumn: "Id",
                keyValue: new Guid("c72b703e-21f0-45ea-9323-e1362b494cb1"),
                column: "RaportTime",
                value: new DateTimeOffset(new DateTime(2022, 4, 26, 16, 42, 12, 158, DateTimeKind.Unspecified).AddTicks(1074), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Raports",
                keyColumn: "Id",
                keyValue: new Guid("fd01f84e-8917-461a-8d6d-b5758a6065b2"),
                column: "RaportTime",
                value: new DateTimeOffset(new DateTime(2022, 4, 26, 16, 42, 12, 158, DateTimeKind.Unspecified).AddTicks(1080), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8931ce67-348b-48b6-96fc-6fc47a74311e"),
                columns: new[] { "ConcurrencyStamp", "PESEL", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d73621af-f4d6-403e-9a65-dbe8905e4440", 99101912345L, "AQAAAAEAACcQAAAAENmur9tGyuLBQyu8sxpNdcYfPknQmGq9D7qQDtX+wwhaM2R/QNt9uldTq5h8aakInw==", "eb874b3e-21f9-4129-869a-6b934d18d76a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ae47d26c-b934-4057-8d05-dfd78ea1a138"),
                columns: new[] { "ConcurrencyStamp", "PESEL", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1e655b0-d7a4-483e-98d4-32c4961360f9", 66030280889L, "AQAAAAEAACcQAAAAEC2GO3klewDFS2SoPk/t6dT4olrUoaHvsp2+SepovOP30SdaZd19VBk3gJQ8Gcp9Vw==", "334cec6e-d359-49eb-9840-e8fe10a1722f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d9339e74-284d-46f4-ad46-b13269c4900e"),
                columns: new[] { "ConcurrencyStamp", "PESEL", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d7da63a-60f0-4ea6-8764-79617417faab", 60070111229L, "AQAAAAEAACcQAAAAEIYhM3YORQKJm0k7N5cqKnSbhC96Pq9RmXrxc4CnLTqoBTZuYzAQztZySAQeQW/pIg==", "d6656279-db07-475a-992c-c28e809ea181" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4d9b6996-8e8a-4cec-9f2f-d7f64e2113ca"),
                columns: new[] { "ConcurrencyStamp", "PESEL", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b754a0b-8f4f-4aaa-9c55-2894eead6de6", 78032180802L, "AQAAAAEAACcQAAAAEF9wZ88YNAt9H+3WLmOt+zKGWNOcWIJaZ55GLpwJBUNQkCVXR9QaYbZS3Qpw9LWXSQ==", "b4f9496b-eca1-4b64-9ab6-46cfba528706" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c394c3c5-3727-4b3b-999f-de8180edf15f"),
                columns: new[] { "ConcurrencyStamp", "PESEL", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b911963-272f-4e78-b743-189eb5a85003", 90042182882L, "AQAAAAEAACcQAAAAEDiothikNCKx8TYJg7G/RZcmv+gkd60YgwgUyl9bjy0px28NX1nCw0nldF/+95LuEQ==", "59839d0e-1ba4-45ac-9477-b5f715566585" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f43c4920-a607-4d32-a937-ba324e07ebd6"),
                columns: new[] { "ConcurrencyStamp", "PESEL", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ffcbc1e7-5df3-45f4-86b7-a20a010c9bc3", 99042382888L, "AQAAAAEAACcQAAAAECv20NXPrrfxjAEHUnwTNO9uDE4KgfugG9CxjET0omEU4pGNgv/9ahR86vfNvw4Egg==", "380391c6-6adf-4dc2-b4f1-c79f9689b044" });
        }
    }
}
