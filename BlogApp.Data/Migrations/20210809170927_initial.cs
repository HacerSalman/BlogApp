using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogApp.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "entity_status_tab",
                columns: table => new
                {
                    v = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entity_status_tab", x => x.v);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "role_tab",
                columns: table => new
                {
                    v = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_tab", x => x.v);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_type_tab",
                columns: table => new
                {
                    v = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_type_tab", x => x.v);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "category_tab",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_time = table.Column<long>(type: "bigint", nullable: false),
                    Update_time = table.Column<long>(type: "bigint", nullable: false),
                    owner = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    modifier = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_tab", x => x.id);
                    table.ForeignKey(
                        name: "FK_category_tab_entity_status_tab_status",
                        column: x => x.status,
                        principalTable: "entity_status_tab",
                        principalColumn: "v",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_tab",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    surname = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_type = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    username = table.Column<Guid>(type: "char(128)", maxLength: 128, nullable: false, collation: "ascii_general_ci"),
                    email = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_time = table.Column<long>(type: "bigint", nullable: false),
                    Update_time = table.Column<long>(type: "bigint", nullable: false),
                    owner = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    modifier = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_tab", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_tab_entity_status_tab_status",
                        column: x => x.status,
                        principalTable: "entity_status_tab",
                        principalColumn: "v",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_tab_user_type_tab_user_type",
                        column: x => x.user_type,
                        principalTable: "user_type_tab",
                        principalColumn: "v",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "article_tab",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    thumbnail = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    view_count = table.Column<long>(type: "bigint", nullable: false),
                    comment_count = table.Column<long>(type: "bigint", nullable: false),
                    seo_author = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    seo_description = table.Column<string>(type: "varchar(2048)", maxLength: 2048, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    seo_tags = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_time = table.Column<long>(type: "bigint", nullable: false),
                    Update_time = table.Column<long>(type: "bigint", nullable: false),
                    owner = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    modifier = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article_tab", x => x.id);
                    table.ForeignKey(
                        name: "FK_article_tab_category_tab_category_id",
                        column: x => x.category_id,
                        principalTable: "category_tab",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_article_tab_entity_status_tab_status",
                        column: x => x.status,
                        principalTable: "entity_status_tab",
                        principalColumn: "v",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_article_tab_user_tab_user_id",
                        column: x => x.user_id,
                        principalTable: "user_tab",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_role_tab",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    role = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_time = table.Column<long>(type: "bigint", nullable: false),
                    Update_time = table.Column<long>(type: "bigint", nullable: false),
                    owner = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    modifier = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_role_tab", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_role_tab_entity_status_tab_status",
                        column: x => x.status,
                        principalTable: "entity_status_tab",
                        principalColumn: "v",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_role_tab_role_tab_role",
                        column: x => x.role,
                        principalTable: "role_tab",
                        principalColumn: "v",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_role_tab_user_tab_user_id",
                        column: x => x.user_id,
                        principalTable: "user_tab",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "comment_tab",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    article_id = table.Column<long>(type: "bigint", nullable: false),
                    parent_id = table.Column<long>(type: "bigint", nullable: true),
                    status = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_time = table.Column<long>(type: "bigint", nullable: false),
                    Update_time = table.Column<long>(type: "bigint", nullable: false),
                    owner = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    modifier = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment_tab", x => x.id);
                    table.ForeignKey(
                        name: "FK_comment_tab_article_tab_article_id",
                        column: x => x.article_id,
                        principalTable: "article_tab",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comment_tab_comment_tab_parent_id",
                        column: x => x.parent_id,
                        principalTable: "comment_tab",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comment_tab_entity_status_tab_status",
                        column: x => x.status,
                        principalTable: "entity_status_tab",
                        principalColumn: "v",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "entity_status_tab",
                column: "v",
                values: new object[]
                {
                    "ACTIVE",
                    "PASSIVE",
                    "DELETED"
                });

            migrationBuilder.InsertData(
                table: "role_tab",
                column: "v",
                values: new object[]
                {
                    "BLOG_WRITE",
                    "BLOG_READ",
                    "COMMENT_WRITE",
                    "COMMENT_READ"
                });

            migrationBuilder.InsertData(
                table: "user_type_tab",
                column: "v",
                values: new object[]
                {
                    "ADMIN",
                    "MEMBER",
                    "GUEST"
                });

            migrationBuilder.CreateIndex(
                name: "IX_article_tab_category_id",
                table: "article_tab",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_article_tab_create_time",
                table: "article_tab",
                column: "create_time");

            migrationBuilder.CreateIndex(
                name: "IX_article_tab_seo_author",
                table: "article_tab",
                column: "seo_author");

            migrationBuilder.CreateIndex(
                name: "IX_article_tab_status",
                table: "article_tab",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_article_tab_title",
                table: "article_tab",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "IX_article_tab_Update_time",
                table: "article_tab",
                column: "Update_time");

            migrationBuilder.CreateIndex(
                name: "IX_article_tab_user_id",
                table: "article_tab",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_category_tab_create_time",
                table: "category_tab",
                column: "create_time");

            migrationBuilder.CreateIndex(
                name: "IX_category_tab_name",
                table: "category_tab",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_category_tab_status",
                table: "category_tab",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_category_tab_Update_time",
                table: "category_tab",
                column: "Update_time");

            migrationBuilder.CreateIndex(
                name: "IX_comment_tab_article_id",
                table: "comment_tab",
                column: "article_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_tab_create_time",
                table: "comment_tab",
                column: "create_time");

            migrationBuilder.CreateIndex(
                name: "IX_comment_tab_parent_id",
                table: "comment_tab",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_tab_status",
                table: "comment_tab",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_comment_tab_Update_time",
                table: "comment_tab",
                column: "Update_time");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_tab_create_time",
                table: "user_role_tab",
                column: "create_time");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_tab_role",
                table: "user_role_tab",
                column: "role");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_tab_status",
                table: "user_role_tab",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_tab_Update_time",
                table: "user_role_tab",
                column: "Update_time");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_tab_user_id",
                table: "user_role_tab",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_tab_create_time",
                table: "user_tab",
                column: "create_time");

            migrationBuilder.CreateIndex(
                name: "IX_user_tab_email",
                table: "user_tab",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "IX_user_tab_name",
                table: "user_tab",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_user_tab_status",
                table: "user_tab",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_user_tab_Update_time",
                table: "user_tab",
                column: "Update_time");

            migrationBuilder.CreateIndex(
                name: "IX_user_tab_user_type",
                table: "user_tab",
                column: "user_type");

            migrationBuilder.CreateIndex(
                name: "IX_user_tab_username",
                table: "user_tab",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment_tab");

            migrationBuilder.DropTable(
                name: "user_role_tab");

            migrationBuilder.DropTable(
                name: "article_tab");

            migrationBuilder.DropTable(
                name: "role_tab");

            migrationBuilder.DropTable(
                name: "category_tab");

            migrationBuilder.DropTable(
                name: "user_tab");

            migrationBuilder.DropTable(
                name: "entity_status_tab");

            migrationBuilder.DropTable(
                name: "user_type_tab");
        }
    }
}
