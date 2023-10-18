﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sayaratech.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNavProberity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                schema: "Sayaratech",
                table: "Employees");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                schema: "Sayaratech",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                schema: "Sayaratech",
                table: "Employees",
                column: "DepartmentId",
                principalSchema: "Sayaratech",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                schema: "Sayaratech",
                table: "Employees");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                schema: "Sayaratech",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                schema: "Sayaratech",
                table: "Employees",
                column: "DepartmentId",
                principalSchema: "Sayaratech",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
