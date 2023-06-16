using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ElectronicLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    author_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    surname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    biography = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.author_id);
                });

            migrationBuilder.CreateTable(
                name: "electronic_source",
                columns: table => new
                {
                    electronic_source_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    file_path = table.Column<string>(type: "text", nullable: false),
                    file_size = table.Column<int>(type: "integer", nullable: false),
                    file_name = table.Column<string>(type: "text", nullable: false),
                    upload_datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_electronic_source", x => x.electronic_source_id);
                });

            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    genre_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre", x => x.genre_id);
                });

            migrationBuilder.CreateTable(
                name: "publisher",
                columns: table => new
                {
                    publisher_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    website_url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publisher", x => x.publisher_id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    bithday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    role = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    book_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    short_description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    long_description = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    isbn10 = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    isbn13 = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    title_image_url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    pages_count = table.Column<int>(type: "integer", nullable: false),
                    PaperCount = table.Column<int>(type: "integer", nullable: false),
                    ElectronicCount = table.Column<int>(type: "integer", nullable: false),
                    publisher_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.book_id);
                    table.ForeignKey(
                        name: "FK_book_publisher_publisher_id",
                        column: x => x.publisher_id,
                        principalTable: "publisher",
                        principalColumn: "publisher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "discount",
                columns: table => new
                {
                    discount_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    is_sent = table.Column<bool>(type: "boolean", nullable: false),
                    start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    stop = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    sent_datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    email_content = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Percent = table.Column<byte>(type: "smallint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discount", x => x.discount_id);
                    table.ForeignKey(
                        name: "FK_discount_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchase_order",
                columns: table => new
                {
                    purchase_order_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status = table.Column<byte>(type: "smallint", nullable: false),
                    phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_by_id = table.Column<long>(type: "bigint", nullable: false),
                    created_for_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase_order", x => x.purchase_order_id);
                    table.ForeignKey(
                        name: "FK_purchase_order_user_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchase_order_user_created_for_id",
                        column: x => x.created_for_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "taking_order",
                columns: table => new
                {
                    taking_order_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    stop = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<byte>(type: "smallint", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_by_id = table.Column<long>(type: "bigint", nullable: false),
                    created_for_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taking_order", x => x.taking_order_id);
                    table.ForeignKey(
                        name: "FK_taking_order_user_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_taking_order_user_created_for_id",
                        column: x => x.created_for_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_author",
                columns: table => new
                {
                    author_id = table.Column<long>(type: "bigint", nullable: false),
                    book_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_author", x => new { x.author_id, x.book_id });
                    table.ForeignKey(
                        name: "FK_book_author_author_author_id",
                        column: x => x.author_id,
                        principalTable: "author",
                        principalColumn: "author_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_book_author_book_book_id",
                        column: x => x.book_id,
                        principalTable: "book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_copy",
                columns: table => new
                {
                    book_copy_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    copy_type = table.Column<byte>(type: "smallint", nullable: false),
                    copy_number = table.Column<string>(type: "text", nullable: false),
                    qr_content = table.Column<string>(type: "text", nullable: false),
                    book_id = table.Column<long>(type: "bigint", nullable: false),
                    source_id = table.Column<long>(type: "bigint", nullable: false),
                    physical_condition = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_copy", x => x.book_copy_id);
                    table.ForeignKey(
                        name: "FK_book_copy_book_book_id",
                        column: x => x.book_id,
                        principalTable: "book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_book_copy_electronic_source_source_id",
                        column: x => x.source_id,
                        principalTable: "electronic_source",
                        principalColumn: "electronic_source_id");
                });

            migrationBuilder.CreateTable(
                name: "book_genres",
                columns: table => new
                {
                    book_id = table.Column<long>(type: "bigint", nullable: false),
                    genre_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_genres", x => new { x.book_id, x.genre_id });
                    table.ForeignKey(
                        name: "FK_book_genres_book_book_id",
                        column: x => x.book_id,
                        principalTable: "book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_book_genres_genre_genre_id",
                        column: x => x.genre_id,
                        principalTable: "genre",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "discount_book",
                columns: table => new
                {
                    book_id = table.Column<long>(type: "bigint", nullable: false),
                    discount_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discount_book", x => new { x.book_id, x.discount_id });
                    table.ForeignKey(
                        name: "FK_discount_book_book_book_id",
                        column: x => x.book_id,
                        principalTable: "book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_discount_book_discount_discount_id",
                        column: x => x.discount_id,
                        principalTable: "discount",
                        principalColumn: "discount_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchase_basket",
                columns: table => new
                {
                    purchase_id = table.Column<long>(type: "bigint", nullable: false),
                    book_copy_id = table.Column<long>(type: "bigint", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase_basket", x => new { x.book_copy_id, x.purchase_id });
                    table.ForeignKey(
                        name: "FK_purchase_basket_book_copy_book_copy_id",
                        column: x => x.book_copy_id,
                        principalTable: "book_copy",
                        principalColumn: "book_copy_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchase_basket_purchase_order_purchase_id",
                        column: x => x.purchase_id,
                        principalTable: "purchase_order",
                        principalColumn: "purchase_order_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "taking_book",
                columns: table => new
                {
                    book_id = table.Column<long>(type: "bigint", nullable: false),
                    taking_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taking_book", x => new { x.book_id, x.taking_id });
                    table.ForeignKey(
                        name: "FK_taking_book_book_copy_book_id",
                        column: x => x.book_id,
                        principalTable: "book_copy",
                        principalColumn: "book_copy_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_taking_book_taking_order_taking_id",
                        column: x => x.taking_id,
                        principalTable: "taking_order",
                        principalColumn: "taking_order_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_publisher_id",
                table: "book",
                column: "publisher_id");

            migrationBuilder.CreateIndex(
                name: "IX_book_title",
                table: "book",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_book_author_book_id",
                table: "book_author",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_book_copy_book_id",
                table: "book_copy",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_book_copy_source_id",
                table: "book_copy",
                column: "source_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_book_genres_genre_id",
                table: "book_genres",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_discount_user_id",
                table: "discount",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_discount_book_discount_id",
                table: "discount_book",
                column: "discount_id");

            migrationBuilder.CreateIndex(
                name: "IX_genre_description",
                table: "genre",
                column: "description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_publisher_name",
                table: "publisher",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_purchase_basket_purchase_id",
                table: "purchase_basket",
                column: "purchase_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_order_created_by_id",
                table: "purchase_order",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_order_created_for_id",
                table: "purchase_order",
                column: "created_for_id");

            migrationBuilder.CreateIndex(
                name: "IX_taking_book_taking_id",
                table: "taking_book",
                column: "taking_id");

            migrationBuilder.CreateIndex(
                name: "IX_taking_order_created_by_id",
                table: "taking_order",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_taking_order_created_for_id",
                table: "taking_order",
                column: "created_for_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_email",
                table: "user",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book_author");

            migrationBuilder.DropTable(
                name: "book_genres");

            migrationBuilder.DropTable(
                name: "discount_book");

            migrationBuilder.DropTable(
                name: "purchase_basket");

            migrationBuilder.DropTable(
                name: "taking_book");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "genre");

            migrationBuilder.DropTable(
                name: "discount");

            migrationBuilder.DropTable(
                name: "purchase_order");

            migrationBuilder.DropTable(
                name: "book_copy");

            migrationBuilder.DropTable(
                name: "taking_order");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "electronic_source");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "publisher");
        }
    }
}
