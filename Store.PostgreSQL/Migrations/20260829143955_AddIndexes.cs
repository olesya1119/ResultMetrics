using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResultMetrics.Store.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_values_date",
                table: "values",
                column: "date");

            migrationBuilder.CreateIndex(
                name: "ix_values_file_name",
                table: "values",
                column: "file_name");

            migrationBuilder.CreateIndex(
                name: "ix_results_avg_execution_time",
                table: "results",
                column: "avg_execution_time");

            migrationBuilder.CreateIndex(
                name: "ix_results_avg_value",
                table: "results",
                column: "avg_value");

            migrationBuilder.CreateIndex(
                name: "ix_results_file_name",
                table: "results",
                column: "file_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_results_min_date",
                table: "results",
                column: "min_date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_values_date",
                table: "values");

            migrationBuilder.DropIndex(
                name: "ix_values_file_name",
                table: "values");

            migrationBuilder.DropIndex(
                name: "ix_results_avg_execution_time",
                table: "results");

            migrationBuilder.DropIndex(
                name: "ix_results_avg_value",
                table: "results");

            migrationBuilder.DropIndex(
                name: "ix_results_file_name",
                table: "results");

            migrationBuilder.DropIndex(
                name: "ix_results_min_date",
                table: "results");
        }
    }
}
