using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessMember.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_FitnessClasses_FitnessClassId",
                table: "Members");

            migrationBuilder.CreateIndex(
                name: "IX_Members_Email",
                table: "Members",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_FitnessClasses_FitnessClassId",
                table: "Members",
                column: "FitnessClassId",
                principalTable: "FitnessClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_FitnessClasses_FitnessClassId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_Email",
                table: "Members");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_FitnessClasses_FitnessClassId",
                table: "Members",
                column: "FitnessClassId",
                principalTable: "FitnessClasses",
                principalColumn: "Id");
        }
    }
}
