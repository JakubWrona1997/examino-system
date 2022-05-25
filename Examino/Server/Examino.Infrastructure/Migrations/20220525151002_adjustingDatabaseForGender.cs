using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examino.Infrastructure.Migrations
{
    public partial class adjustingDatabaseForGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Raports",
                keyColumn: "Id",
                keyValue: new Guid("a34d644f-55fc-4a39-addd-a8cc07f89c34"),
                column: "RaportTime",
                value: new DateTimeOffset(new DateTime(2022, 5, 25, 17, 10, 1, 765, DateTimeKind.Unspecified).AddTicks(1018), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Raports",
                keyColumn: "Id",
                keyValue: new Guid("b03172a3-fc8f-4419-a63e-618359d4cd99"),
                column: "RaportTime",
                value: new DateTimeOffset(new DateTime(2022, 5, 25, 17, 10, 1, 765, DateTimeKind.Unspecified).AddTicks(1081), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Raports",
                keyColumn: "Id",
                keyValue: new Guid("c72b703e-21f0-45ea-9323-e1362b494cb1"),
                column: "RaportTime",
                value: new DateTimeOffset(new DateTime(2022, 5, 25, 17, 10, 1, 765, DateTimeKind.Unspecified).AddTicks(1088), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Raports",
                keyColumn: "Id",
                keyValue: new Guid("fd01f84e-8917-461a-8d6d-b5758a6065b2"),
                column: "RaportTime",
                value: new DateTimeOffset(new DateTime(2022, 5, 25, 17, 10, 1, 765, DateTimeKind.Unspecified).AddTicks(1094), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8931ce67-348b-48b6-96fc-6fc47a74311e"),
                columns: new[] { "ConcurrencyStamp", "Gender", "PasswordHash", "SecurityStamp" },
                values: new object[] { "822074a9-722d-46d4-9733-6ae10c96fb55", "Man", "AQAAAAEAACcQAAAAECkvOE/ryDYm3DqVfGj1o+KR6hMJNtJczV8PjUZTyW2rdeNywxheUDl9cVywEX3EWw==", "9ef3f9c9-86fe-45eb-95d5-f05fbf6f377b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ae47d26c-b934-4057-8d05-dfd78ea1a138"),
                columns: new[] { "ConcurrencyStamp", "Gender", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9e801ab-be70-4781-8541-ca815dcdf12c", "Man", "AQAAAAEAACcQAAAAEFq6AdpF+GFIfmj5fkHha/GIA3AFf0DU3YSHRB7oFkwtsSiL6Q2HdDfF/q12rhgXyQ==", "3d9ea0be-819c-44ea-bf17-7d327dada347" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d9339e74-284d-46f4-ad46-b13269c4900e"),
                columns: new[] { "ConcurrencyStamp", "Gender", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81bd1f39-1e29-436a-9fdb-16dd8f706690", "Man", "AQAAAAEAACcQAAAAEJiGm6It1rE+138EfRX3PZ+OZqpTP36InFjR/S7zSs08zgZIm4wTwM+qi6+KYdif8A==", "f2108a97-5c18-4fa4-8180-a0753f313c0a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4d9b6996-8e8a-4cec-9f2f-d7f64e2113ca"),
                columns: new[] { "BloodType", "ConcurrencyStamp", "Gender", "PasswordHash", "SecurityStamp" },
                values: new object[] { "B Rh-", "6d040236-efa9-4427-88ed-80f8f1c10d18", "Man", "AQAAAAEAACcQAAAAEAl6cxuzWC8gD+MnqRPMn65VTODSjFzccjfsL1sb4bbf3uReO7eksZMieklS9Tze0w==", "4c7c9f14-ab4b-494d-8570-b29ea2a154de" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c394c3c5-3727-4b3b-999f-de8180edf15f"),
                columns: new[] { "BloodType", "ConcurrencyStamp", "Gender", "PasswordHash", "SecurityStamp" },
                values: new object[] { "B Rh+", "2f46b849-3cf5-4e93-b7cc-b1a5ec0e6f06", "Man", "AQAAAAEAACcQAAAAENR+48GJWVAhP2IGj/p9+ozUKw3m/6gXV32nxeWsZINPNQovoRVYszogKVJJg2cJ6Q==", "e15618f2-41c6-4c12-a859-446fb2655c5b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f43c4920-a607-4d32-a937-ba324e07ebd6"),
                columns: new[] { "BloodType", "ConcurrencyStamp", "Gender", "PasswordHash", "SecurityStamp" },
                values: new object[] { "A Rh+", "f8111c3c-a4ce-4da2-839f-043a667cc1ed", "Man", "AQAAAAEAACcQAAAAEMEWjTzhqPTgg/KEl2ZM8+vHsyfx+4yOt7Cygb+yu1d6K8sT3UKB2XtEEx9bQbdZKw==", "67a5da60-5f59-4ede-aecb-27cdd7336224" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c51ccbc5-bb54-4b23-a7dd-e121c746f9b2", "AQAAAAEAACcQAAAAEIOsHxJsz8H91GU1zYALgyP07cTLmBYsXOSQwIigxhFUxR974kxyklu0PFnZhiPbxA==", "c3e30320-9336-43a6-b91f-43f0eca3d03e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ae47d26c-b934-4057-8d05-dfd78ea1a138"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85065441-56b1-42ae-bcff-105aa2e81ea9", "AQAAAAEAACcQAAAAEAfi5uPTDE4cLEenAyNeZPS7jzAWM33hniFm08u5NY9y7Oy84S9VNanSevFAl4P+uQ==", "063346bf-a96a-4095-ae04-17864db27fe6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d9339e74-284d-46f4-ad46-b13269c4900e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0b537e0-ff5d-4eb9-abfe-58082308a0c8", "AQAAAAEAACcQAAAAEJSNZklf2zoJlTGtgdhESrGYVxtmwaGa1XxKwlz38K2KrMCDFE1NApkh6lWu32TPog==", "63eab17a-6915-422d-b4df-998c31943309" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4d9b6996-8e8a-4cec-9f2f-d7f64e2113ca"),
                columns: new[] { "BloodType", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "B-", "836a9c03-4f5e-4d4e-9f4a-a94981cd60fe", "AQAAAAEAACcQAAAAEF0vo6RVfMFeMRGjmYGXA+P6AzOALg8T++KBfHez8K6iA2wz4TbJIzKDrd+93bO1dw==", "09d31b20-53af-4bb0-ab2b-f8826758cab6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c394c3c5-3727-4b3b-999f-de8180edf15f"),
                columns: new[] { "BloodType", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "B+", "d8216bd4-4d78-4b46-88f0-9803342821f7", "AQAAAAEAACcQAAAAEBXqyFHvR7MFiu9BOzWwKTZSgEFjJM2GzzYTIZYt8yiOP2ETJhItTU4j7Gaz7Le0pg==", "b08916cd-fb23-4919-b136-23dcb0484f03" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f43c4920-a607-4d32-a937-ba324e07ebd6"),
                columns: new[] { "BloodType", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "A+", "1239327d-a230-4402-967b-56b133986a19", "AQAAAAEAACcQAAAAEAuZdYiNQXykwf6DCR+Z1YkdsTJR6yksPmh4CAc+LjhJVe0yRLWS2fZHXLleMKtbBQ==", "f7e982f9-24d6-4ad9-b285-86ae03723238" });
        }
    }
}
