using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateOnly>(type: "date", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderTotal = table.Column<double>(type: "float", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateAt = table.Column<DateOnly>(type: "date", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHeaderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderHeaders_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Men Clothing" },
                    { 2, "Women Clothing" },
                    { 3, "Kids Clothing" },
                    { 4, "Men Shoes" },
                    { 5, "Women Shoes" },
                    { 6, "Kids Shoes" },
                    { 7, "Bags" },
                    { 8, "Backpacks" },
                    { 9, "Men Accessories" },
                    { 10, "Women Accessories" },
                    { 11, "Watches" },
                    { 12, "Sunglasses" },
                    { 13, "Men Perfumes" },
                    { 14, "Women Perfumes" },
                    { 15, "Cosmetics" },
                    { 16, "Makeup" },
                    { 17, "Skincare" },
                    { 18, "Hair Care" },
                    { 19, "Personal Care" },
                    { 20, "Health & Beauty" },
                    { 21, "Mobiles" },
                    { 22, "Tablets" },
                    { 23, "Laptops" },
                    { 24, "Computers" },
                    { 25, "Smart Watches" },
                    { 26, "Headphones" },
                    { 27, "Speakers" },
                    { 28, "Cameras" },
                    { 29, "Gaming Consoles" },
                    { 30, "Video Games" },
                    { 31, "TV & Audio" },
                    { 32, "Home Appliances" },
                    { 33, "Kitchen Appliances" },
                    { 34, "Refrigerators" },
                    { 35, "Washing Machines" },
                    { 36, "Cookers" },
                    { 37, "Microwaves" },
                    { 38, "Vacuum Cleaners" },
                    { 39, "Furniture" },
                    { 40, "Living Room" },
                    { 41, "Bedroom" },
                    { 42, "Dining Room" },
                    { 43, "Office Furniture" },
                    { 44, "Garden Furniture" },
                    { 45, "Home Decor" },
                    { 46, "Lighting" },
                    { 47, "Bedding" },
                    { 48, "Carpets" },
                    { 49, "Kitchenware" },
                    { 50, "Tableware" },
                    { 51, "Cookware" },
                    { 52, "Bakeware" },
                    { 53, "Storage & Organization" },
                    { 54, "Cleaning Supplies" },
                    { 55, "Groceries" },
                    { 56, "Snacks" },
                    { 57, "Beverages" },
                    { 58, "Breakfast Items" },
                    { 59, "Canned Food" },
                    { 60, "Fresh Fruits" },
                    { 61, "Fresh Vegetables" },
                    { 62, "Dairy Products" },
                    { 63, "Meat & Poultry" },
                    { 64, "Seafood" },
                    { 65, "Frozen Food" },
                    { 66, "Baby Products" },
                    { 67, "Diapers" },
                    { 68, "Baby Care" },
                    { 69, "Toys" },
                    { 70, "Board Games" },
                    { 71, "Outdoor Games" },
                    { 72, "Books" },
                    { 73, "Novels" },
                    { 74, "School Supplies" },
                    { 75, "Office Supplies" },
                    { 76, "Art Supplies" },
                    { 77, "Sports Equipment" },
                    { 78, "Fitness Equipment" },
                    { 79, "Camping Gear" },
                    { 80, "Travel Accessories" },
                    { 81, "Car Accessories" },
                    { 82, "Car Electronics" },
                    { 83, "Motorcycle Gear" },
                    { 84, "Pet Supplies" },
                    { 85, "Pet Food" },
                    { 86, "Pet Toys" },
                    { 87, "Garden Tools" },
                    { 88, "Plants & Seeds" },
                    { 89, "DIY Tools" },
                    { 90, "Hand Tools" },
                    { 91, "Power Tools" },
                    { 92, "Building Materials" },
                    { 93, "Electrical Supplies" },
                    { 94, "Plumbing Supplies" },
                    { 95, "Safety Equipment" },
                    { 96, "Travel Luggage" },
                    { 97, "Jewelry" },
                    { 98, "Gold & Silver" },
                    { 99, "Collectibles" },
                    { 100, "Gifts" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "CreateAt", "Description", "IsActive", "LastUpdate", "ListPrice", "Price", "Price100", "Price50", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, "Nike", 4, new DateOnly(2025, 9, 8), "Comfortable running shoes with modern design", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 150.0, 140.0, 120.0, 130.0, 120, "Nike Air Max Shoes" },
                    { 2, "Samsung", 21, new DateOnly(2025, 9, 8), "Latest flagship smartphone with high performance camera", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 900.0, 850.0, 790.0, 820.0, 60, "Samsung Galaxy S23" },
                    { 3, "Adidas", 8, new DateOnly(2025, 9, 8), "Durable backpack for travel and school", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.0, 65.0, 55.0, 60.0, 200, "Adidas Backpack" },
                    { 4, "Apple", 23, new DateOnly(2025, 9, 8), "Powerful laptop with M2 chip for professionals", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000.0, 1900.0, 1800.0, 1850.0, 35, "Apple MacBook Pro 14" },
                    { 5, "Gucci", 7, new DateOnly(2025, 9, 8), "Luxury leather handbag for women", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1200.0, 1100.0, 1000.0, 1050.0, 50, "Gucci Handbag" },
                    { 6, "Sony", 26, new DateOnly(2025, 9, 8), "Noise cancelling wireless headphones", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 400.0, 380.0, 340.0, 360.0, 80, "Sony WH-1000XM5 Headphones" },
                    { 7, "LG", 31, new DateOnly(2025, 9, 8), "4K Ultra HD Smart LED TV", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 750.0, 720.0, 680.0, 700.0, 40, "LG 55 Inch Smart TV" },
                    { 8, "Dell", 23, new DateOnly(2025, 9, 8), "Slim and powerful laptop for work", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500.0, 1450.0, 1350.0, 1400.0, 25, "Dell XPS 13 Laptop" },
                    { 9, "Nestle", 56, new DateOnly(2025, 9, 8), "Delicious assorted chocolate pack", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 14.0, 12.0, 13.0, 300, "Nestle Chocolate Pack" },
                    { 10, "Levi’s", 1, new DateOnly(2025, 9, 8), "Classic denim jeans for men", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.0, 55.0, 50.0, 52.0, 180, "Levi’s Jeans" },
                    { 11, "HP", 75, new DateOnly(2025, 9, 8), "High speed wireless laser printer", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 250.0, 240.0, 220.0, 230.0, 50, "HP Laser Printer" },
                    { 12, "Adidas", 1, new DateOnly(2025, 9, 8), "Lightweight sportswear t-shirt", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.0, 32.0, 28.0, 30.0, 150, "Adidas Running T-Shirt" },
                    { 13, "Apple", 22, new DateOnly(2025, 9, 8), "Light and powerful tablet with Retina display", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 650.0, 630.0, 590.0, 610.0, 60, "Apple iPad Air" },
                    { 14, "Rolex", 11, new DateOnly(2025, 9, 8), "Luxury Swiss made men’s watch", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9000.0, 8800.0, 8600.0, 8700.0, 15, "Rolex Submariner Watch" },
                    { 15, "Canon", 28, new DateOnly(2025, 9, 8), "Professional DSLR camera for photography", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1200.0, 1150.0, 1050.0, 1100.0, 20, "Canon EOS 90D Camera" },
                    { 16, "Sony", 29, new DateOnly(2025, 9, 8), "Latest generation gaming console", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 600.0, 580.0, 540.0, 560.0, 40, "Sony PlayStation 5" },
                    { 17, "Microsoft", 29, new DateOnly(2025, 9, 8), "Powerful gaming console with 4K support", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 550.0, 530.0, 490.0, 510.0, 35, "Microsoft Xbox Series X" },
                    { 18, "Puma", 4, new DateOnly(2025, 9, 8), "Comfortable shoes for everyday wear", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.0, 95.0, 85.0, 90.0, 110, "Puma Sports Shoes" },
                    { 19, "Samsung", 25, new DateOnly(2025, 9, 8), "Smartwatch with health tracking", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 350.0, 340.0, 320.0, 330.0, 75, "Samsung Galaxy Watch" },
                    { 20, "KitchenAid", 33, new DateOnly(2025, 9, 8), "Professional stand mixer for baking", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 400.0, 380.0, 360.0, 370.0, 45, "KitchenAid Mixer" },
                    { 21, "Nike", 9, new DateOnly(2025, 9, 8), "Adjustable unisex sports cap", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 23.0, 20.0, 22.0, 160, "Nike Sports Cap" },
                    { 22, "Apple", 26, new DateOnly(2025, 9, 8), "Noise cancelling wireless earbuds", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 250.0, 240.0, 220.0, 230.0, 90, "Apple AirPods Pro" },
                    { 23, "Philips", 33, new DateOnly(2025, 9, 8), "High speed electric blender", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.0, 75.0, 70.0, 72.0, 70, "Philips Blender" },
                    { 24, "Gucci", 12, new DateOnly(2025, 9, 8), "Luxury designer sunglasses", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0, 480.0, 460.0, 470.0, 55, "Gucci Sunglasses" },
                    { 25, "Samsung", 23, new DateOnly(2025, 9, 8), "High speed solid state drive", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 150.0, 145.0, 135.0, 140.0, 100, "Samsung 1TB SSD" },
                    { 26, "Bosch", 91, new DateOnly(2025, 9, 8), "Cordless electric drill with battery", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200.0, 190.0, 180.0, 185.0, 80, "Bosch Power Drill" },
                    { 27, "Nestle", 57, new DateOnly(2025, 9, 8), "Premium instant coffee blend", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.0, 11.0, 9.0, 10.0, 250, "Nestle Coffee Pack" },
                    { 28, "Nike", 1, new DateOnly(2025, 9, 8), "Breathable sports shorts", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40.0, 38.0, 34.0, 36.0, 140, "Nike Training Shorts" },
                    { 29, "Samsung", 23, new DateOnly(2025, 9, 8), "Curved gaming monitor", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 300.0, 290.0, 270.0, 280.0, 60, "Samsung 32 Inch Monitor" },
                    { 30, "Adidas", 1, new DateOnly(2025, 9, 8), "Warm hoodie for winter", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 65.0, 60.0, 55.0, 58.0, 130, "Adidas Hoodie" },
                    { 31, "Apple", 25, new DateOnly(2025, 9, 8), "Advanced smartwatch with GPS", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 800.0, 780.0, 740.0, 760.0, 40, "Apple Watch Ultra" },
                    { 32, "Sony", 28, new DateOnly(2025, 9, 8), "Professional 4K video camera", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1800.0, 1750.0, 1700.0, 1720.0, 25, "Sony 4K Camcorder" },
                    { 33, "Levi’s", 1, new DateOnly(2025, 9, 8), "Denim jacket for men", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.0, 80.0, 75.0, 78.0, 95, "Levi’s Jacket" },
                    { 34, "Samsung", 37, new DateOnly(2025, 9, 8), "Compact digital microwave", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 130.0, 125.0, 115.0, 120.0, 70, "Samsung Microwave" },
                    { 35, "Nike", 9, new DateOnly(2025, 9, 8), "Breathable cotton socks", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 14.0, 12.0, 13.0, 200, "Nike Running Socks" },
                    { 36, "Asus", 23, new DateOnly(2025, 9, 8), "High performance laptop for gamers", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1700.0, 1650.0, 1600.0, 1620.0, 30, "Asus Gaming Laptop" },
                    { 37, "Sony", 27, new DateOnly(2025, 9, 8), "Portable wireless speaker", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 120.0, 115.0, 105.0, 110.0, 100, "Sony Bluetooth Speaker" },
                    { 38, "Gucci", 10, new DateOnly(2025, 9, 8), "Luxury leather wallet", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 400.0, 380.0, 360.0, 370.0, 40, "Gucci Wallet" },
                    { 39, "Apple", 21, new DateOnly(2025, 9, 8), "Latest iPhone with A16 chip", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1200.0, 1150.0, 1100.0, 1120.0, 55, "Apple iPhone 14 Pro" },
                    { 40, "Nike", 7, new DateOnly(2025, 9, 8), "Durable sports duffel bag", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.0, 65.0, 60.0, 62.0, 85, "Nike Gym Bag" },
                    { 41, "Samsung", 27, new DateOnly(2025, 9, 8), "High quality wireless soundbar", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 250.0, 240.0, 220.0, 230.0, 45, "Samsung Soundbar" },
                    { 42, "Rolex", 11, new DateOnly(2025, 9, 8), "Luxury classic men’s watch", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10000.0, 9800.0, 9600.0, 9700.0, 10, "Rolex Oyster Watch" },
                    { 43, "Sony", 30, new DateOnly(2025, 9, 8), "Wireless DualSense controller", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.0, 65.0, 60.0, 62.0, 150, "Sony PS5 Controller" },
                    { 44, "Apple", 24, new DateOnly(2025, 9, 8), "All-in-one desktop computer", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1600.0, 1550.0, 1500.0, 1520.0, 20, "Apple iMac 24 Inch" },
                    { 45, "Nike", 77, new DateOnly(2025, 9, 8), "Durable outdoor basketball", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40.0, 38.0, 34.0, 36.0, 140, "Nike Basketball" },
                    { 46, "Samsung", 22, new DateOnly(2025, 9, 8), "Powerful Android tablet", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 700.0, 680.0, 640.0, 660.0, 45, "Samsung Galaxy Tab S8" },
                    { 47, "Levi’s", 1, new DateOnly(2025, 9, 8), "Cotton t-shirt for men", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.0, 28.0, 25.0, 27.0, 180, "Levi’s T-Shirt" },
                    { 48, "Gucci", 10, new DateOnly(2025, 9, 8), "Designer leather belt", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 350.0, 340.0, 320.0, 330.0, 50, "Gucci Belt" },
                    { 49, "Sony", 31, new DateOnly(2025, 9, 8), "4K HDR Smart TV", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1200.0, 1150.0, 1100.0, 1120.0, 30, "Sony Bravia 65 Inch TV" },
                    { 50, "Nike", 77, new DateOnly(2025, 9, 8), "Fitness training gloves", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 23.0, 20.0, 22.0, 100, "Nike Training Gloves" },
                    { 51, "Adidas", 1, new DateOnly(2025, 9, 8), "Lightweight sports jacket for outdoor activities", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.0, 85.0, 75.0, 80.0, 95, "Adidas Sports Jacket" },
                    { 52, "Apple", 21, new DateOnly(2025, 9, 8), "Fast charging adapter for iPhone", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.0, 28.0, 25.0, 27.0, 200, "Apple iPhone Charger" },
                    { 53, "Samsung", 23, new DateOnly(2025, 9, 8), "High-speed external storage drive", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 250.0, 240.0, 220.0, 230.0, 70, "Samsung Portable SSD 2TB" },
                    { 54, "Nike", 1, new DateOnly(2025, 9, 8), "Comfortable training pants", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.0, 55.0, 50.0, 52.0, 120, "Nike Dri-FIT Pants" },
                    { 55, "Sony", 29, new DateOnly(2025, 9, 8), "12 months subscription card", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.0, 55.0, 50.0, 53.0, 300, "Sony PlayStation Plus Card" },
                    { 56, "Gucci", 14, new DateOnly(2025, 9, 8), "Luxury fragrance for women", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 150.0, 140.0, 130.0, 135.0, 70, "Gucci Perfume" },
                    { 57, "Logitech", 23, new DateOnly(2025, 9, 8), "Ergonomic design wireless mouse", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40.0, 38.0, 34.0, 36.0, 180, "Logitech Wireless Mouse" },
                    { 58, "Apple", 22, new DateOnly(2025, 9, 8), "Magic keyboard for iPad Pro", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 300.0, 290.0, 270.0, 280.0, 40, "Apple iPad Keyboard" },
                    { 59, "Nike", 7, new DateOnly(2025, 9, 8), "Sports duffel bag for gym use", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.0, 70.0, 65.0, 68.0, 95, "Nike Training Bag" },
                    { 60, "Samsung", 26, new DateOnly(2025, 9, 8), "Wireless earbuds with ANC", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 160.0, 150.0, 140.0, 145.0, 85, "Samsung Galaxy Buds 2" },
                    { 61, "Adidas", 6, new DateOnly(2025, 9, 8), "Comfortable sneakers for kids", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.0, 48.0, 44.0, 46.0, 140, "Adidas Kids Shoes" },
                    { 62, "Sony", 30, new DateOnly(2025, 9, 8), "Exclusive PS5 action game", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.0, 65.0, 60.0, 62.0, 100, "Sony PS5 Game - Spider Man" },
                    { 63, "Canon", 75, new DateOnly(2025, 9, 8), "High-quality black ink cartridge", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 23.0, 20.0, 22.0, 150, "Canon Printer Ink" },
                    { 64, "LG", 34, new DateOnly(2025, 9, 8), "Large double-door refrigerator", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1100.0, 1080.0, 1040.0, 1060.0, 20, "LG Refrigerator 400L" },
                    { 65, "Nike", 9, new DateOnly(2025, 9, 8), "Breathable lightweight cap", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 22.0, 20.0, 18.0, 19.0, 90, "Nike Running Cap" },
                    { 66, "Apple", 23, new DateOnly(2025, 9, 8), "Wireless mouse with multi-touch", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.0, 95.0, 90.0, 92.0, 70, "Apple Magic Mouse" },
                    { 67, "Samsung", 35, new DateOnly(2025, 9, 8), "Front load washing machine", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 900.0, 880.0, 850.0, 860.0, 25, "Samsung Washing Machine" },
                    { 68, "Nike", 3, new DateOnly(2025, 9, 8), "Cotton t-shirt for kids", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.0, 18.0, 16.0, 17.0, 130, "Nike Kids T-Shirt" },
                    { 69, "Sony", 31, new DateOnly(2025, 9, 8), "4K Ultra HD Smart OLED TV", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1300.0, 1270.0, 1230.0, 1250.0, 35, "Sony 55 Inch OLED TV" },
                    { 70, "Gucci", 4, new DateOnly(2025, 9, 8), "Luxury men’s leather shoes", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 900.0, 880.0, 840.0, 860.0, 45, "Gucci Leather Shoes" },
                    { 71, "Philips", 33, new DateOnly(2025, 9, 8), "Healthy cooking air fryer", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 250.0, 240.0, 220.0, 230.0, 65, "Philips Air Fryer" },
                    { 72, "Adidas", 3, new DateOnly(2025, 9, 8), "Winter hoodie for children", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.0, 42.0, 38.0, 40.0, 95, "Adidas Hoodie Kids" },
                    { 73, "Apple", 23, new DateOnly(2025, 9, 8), "Lightweight laptop with M1 chip", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000.0, 950.0, 900.0, 920.0, 50, "Apple MacBook Air" },
                    { 74, "Samsung", 23, new DateOnly(2025, 9, 8), "34 inch ultrawide curved monitor", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 650.0, 630.0, 590.0, 610.0, 30, "Samsung Curved Monitor" },
                    { 75, "Nike", 5, new DateOnly(2025, 9, 8), "Comfortable training shoes for women", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.0, 75.0, 70.0, 72.0, 100, "Nike Training Shoes Women" },
                    { 76, "Sony", 26, new DateOnly(2025, 9, 8), "Compact noise cancelling earbuds", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200.0, 190.0, 180.0, 185.0, 85, "Sony Wireless Earbuds" },
                    { 77, "Gucci", 10, new DateOnly(2025, 9, 8), "Luxury designer scarf", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 400.0, 380.0, 360.0, 370.0, 60, "Gucci Scarf" },
                    { 78, "Samsung", 21, new DateOnly(2025, 9, 8), "Innovative foldable smartphone", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1800.0, 1750.0, 1700.0, 1720.0, 25, "Samsung Galaxy Z Fold" },
                    { 79, "Nike", 9, new DateOnly(2025, 9, 8), "Breathable cotton socks pack", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 14.0, 12.0, 13.0, 220, "Nike Sports Socks" },
                    { 80, "Apple", 27, new DateOnly(2025, 9, 8), "Smart speaker with Siri", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 120.0, 115.0, 105.0, 110.0, 70, "Apple HomePod Mini" },
                    { 81, "Sony", 30, new DateOnly(2025, 9, 8), "Latest football game for PS5", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.0, 65.0, 60.0, 62.0, 150, "Sony PS5 Game - FIFA 24" },
                    { 82, "Nike", 8, new DateOnly(2025, 9, 8), "Durable everyday backpack", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 65.0, 60.0, 55.0, 58.0, 90, "Nike Backpack" },
                    { 83, "Samsung", 21, new DateOnly(2025, 9, 8), "Affordable Android smartphone", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 350.0, 330.0, 310.0, 320.0, 100, "Samsung Galaxy A54" },
                    { 84, "Adidas", 77, new DateOnly(2025, 9, 8), "Fitness gloves for gym training", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 23.0, 20.0, 22.0, 100, "Adidas Training Gloves" },
                    { 85, "Sony", 30, new DateOnly(2025, 9, 8), "HD camera for streaming", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.0, 65.0, 60.0, 62.0, 55, "Sony PlayStation Camera" },
                    { 86, "Gucci", 10, new DateOnly(2025, 9, 8), "Luxury fashion earrings", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0, 480.0, 460.0, 470.0, 40, "Gucci Earrings" },
                    { 87, "Samsung", 22, new DateOnly(2025, 9, 8), "Affordable Android tablet", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 250.0, 240.0, 220.0, 230.0, 80, "Samsung Galaxy Tab A7" },
                    { 88, "Nike", 1, new DateOnly(2025, 9, 8), "Light jacket for outdoor running", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.0, 85.0, 80.0, 82.0, 95, "Nike Running Jacket" },
                    { 89, "Apple", 22, new DateOnly(2025, 9, 8), "Stylus for iPad Pro", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 130.0, 125.0, 120.0, 122.0, 60, "Apple Pencil 2" },
                    { 90, "Sony", 31, new DateOnly(2025, 9, 8), "Premium 8K HDR Smart TV", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5000.0, 4900.0, 4700.0, 4800.0, 15, "Sony 75 Inch 8K TV" },
                    { 91, "Levi’s", 1, new DateOnly(2025, 9, 8), "Classic denim shorts for summer", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.0, 42.0, 38.0, 40.0, 110, "Levi’s Denim Shorts" },
                    { 92, "Samsung", 21, new DateOnly(2025, 9, 8), "High-performance Android phone", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 700.0, 680.0, 640.0, 660.0, 70, "Samsung Galaxy S22" },
                    { 93, "Nike", 9, new DateOnly(2025, 9, 8), "Absorbent sports towel", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.0, 16.0, 14.0, 15.0, 180, "Nike Gym Towel" },
                    { 94, "Adidas", 1, new DateOnly(2025, 9, 8), "Full tracksuit for men", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 95.0, 90.0, 85.0, 88.0, 100, "Adidas Tracksuit" },
                    { 95, "Apple", 25, new DateOnly(2025, 9, 8), "Smart Bluetooth tracker", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.0, 28.0, 25.0, 27.0, 120, "Apple AirTag" },
                    { 96, "Gucci", 97, new DateOnly(2025, 9, 8), "Luxury gold bracelet", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1200.0, 1150.0, 1100.0, 1120.0, 30, "Gucci Bracelet" },
                    { 97, "Samsung", 23, new DateOnly(2025, 9, 8), "Ultra-wide curved gaming monitor", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000.0, 950.0, 900.0, 920.0, 20, "Samsung 49 Inch Curved Monitor" },
                    { 98, "Nike", 4, new DateOnly(2025, 9, 8), "Lightweight training sneakers", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.0, 80.0, 75.0, 78.0, 140, "Nike Training Shoes Men" },
                    { 99, "Sony", 30, new DateOnly(2025, 9, 8), "Action-adventure exclusive game", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.0, 65.0, 60.0, 62.0, 80, "Sony PS5 Game - God of War" },
                    { 100, "Apple", 26, new DateOnly(2025, 9, 8), "High-end over-ear headphones", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 600.0, 580.0, 540.0, 560.0, 40, "Apple AirPods Max" },
                    { 101, "Nike", 1, new DateOnly(2025, 9, 8), "Lightweight breathable shorts for running", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.0, 32.0, 28.0, 30.0, 120, "Nike Running Shorts" },
                    { 102, "Apple", 24, new DateOnly(2025, 9, 8), "Smartwatch with health tracking features", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 450.0, 440.0, 420.0, 430.0, 60, "Apple Watch Series 8" },
                    { 103, "Samsung", 21, new DateOnly(2025, 9, 8), "High-performance smartphone with S Pen", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 950.0, 920.0, 880.0, 900.0, 50, "Samsung Galaxy Note 20" },
                    { 104, "Sony", 26, new DateOnly(2025, 9, 8), "Over-ear headphones with premium sound", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 350.0, 340.0, 320.0, 330.0, 70, "Sony Noise Cancelling Headphones" },
                    { 105, "Adidas", 77, new DateOnly(2025, 9, 8), "Official size 5 match football", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40.0, 38.0, 34.0, 36.0, 140, "Adidas Football" },
                    { 106, "Nike", 77, new DateOnly(2025, 9, 8), "Durable non-slip yoga mat", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.0, 52.0, 48.0, 50.0, 100, "Nike Yoga Mat" },
                    { 107, "Apple", 23, new DateOnly(2025, 9, 8), "Professional laptop with M2 chip", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1600.0, 1580.0, 1520.0, 1550.0, 30, "Apple MacBook Pro" },
                    { 108, "Gucci", 7, new DateOnly(2025, 9, 8), "Luxury leather handbag for women", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2200.0, 2150.0, 2050.0, 2100.0, 25, "Gucci Handbag" },
                    { 109, "Samsung", 24, new DateOnly(2025, 9, 8), "Smartwatch with fitness tracking", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 350.0, 340.0, 320.0, 330.0, 80, "Samsung Galaxy Watch 5" },
                    { 110, "Sony", 29, new DateOnly(2025, 9, 8), "Next-gen gaming console", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 600.0, 580.0, 560.0, 570.0, 35, "Sony PlayStation 5 Console" },
                    { 111, "Adidas", 5, new DateOnly(2025, 9, 8), "Comfortable sneakers for training", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.0, 65.0, 60.0, 62.0, 90, "Adidas Training Shoes Women" },
                    { 112, "Apple", 21, new DateOnly(2025, 9, 8), "Charging cable for iPhone and iPad", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.0, 18.0, 16.0, 17.0, 200, "Apple Lightning Cable" },
                    { 113, "Nike", 1, new DateOnly(2025, 9, 8), "Lightweight jacket for windy weather", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.0, 75.0, 70.0, 72.0, 70, "Nike Windbreaker Jacket" },
                    { 114, "Samsung", 27, new DateOnly(2025, 9, 8), "High-quality sound system", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 400.0, 380.0, 360.0, 370.0, 45, "Samsung Soundbar" },
                    { 115, "Sony", 29, new DateOnly(2025, 9, 8), "Wireless controller for PS5", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.0, 65.0, 60.0, 62.0, 120, "Sony PlayStation DualSense Controller" },
                    { 116, "Gucci", 12, new DateOnly(2025, 9, 8), "Designer sunglasses with UV protection", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 700.0, 680.0, 640.0, 660.0, 35, "Gucci Sunglasses" },
                    { 117, "Apple", 22, new DateOnly(2025, 9, 8), "Compact tablet for daily use", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0, 490.0, 470.0, 480.0, 55, "Apple iPad Mini" },
                    { 118, "Adidas", 9, new DateOnly(2025, 9, 8), "Adjustable cap for sports", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 23.0, 20.0, 22.0, 150, "Adidas Sports Cap" },
                    { 119, "Samsung", 31, new DateOnly(2025, 9, 8), "Smart QLED 4K TV", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1400.0, 1370.0, 1320.0, 1350.0, 25, "Samsung QLED 65 Inch TV" },
                    { 120, "Nike", 6, new DateOnly(2025, 9, 8), "Comfortable sneakers for children", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.0, 48.0, 44.0, 46.0, 110, "Nike Kids Sneakers" },
                    { 121, "Sony", 27, new DateOnly(2025, 9, 8), "Portable wireless speaker", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 120.0, 115.0, 105.0, 110.0, 90, "Sony Bluetooth Speaker" },
                    { 122, "Apple", 23, new DateOnly(2025, 9, 8), "Compact desktop computer", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 800.0, 780.0, 740.0, 760.0, 40, "Apple Mac Mini" },
                    { 123, "Gucci", 10, new DateOnly(2025, 9, 8), "Luxury leather wallet for men", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0, 480.0, 460.0, 470.0, 40, "Gucci Wallet" },
                    { 124, "Samsung", 22, new DateOnly(2025, 9, 8), "High-performance Android tablet", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 700.0, 680.0, 640.0, 660.0, 70, "Samsung Galaxy Tab S8" },
                    { 125, "Nike", 77, new DateOnly(2025, 9, 8), "Durable fitness gloves", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.0, 28.0, 25.0, 27.0, 95, "Nike Training Gloves" },
                    { 126, "Sony", 30, new DateOnly(2025, 9, 8), "Open world adventure game", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.0, 65.0, 60.0, 62.0, 85, "Sony PS5 Game - Horizon" },
                    { 127, "Apple", 26, new DateOnly(2025, 9, 8), "Wireless earbuds with noise cancellation", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 250.0, 240.0, 220.0, 230.0, 80, "Apple AirPods Pro 2" },
                    { 128, "Adidas", 1, new DateOnly(2025, 9, 8), "Comfortable track pants", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.0, 55.0, 50.0, 53.0, 100, "Adidas Training Pants Men" },
                    { 129, "Samsung", 21, new DateOnly(2025, 9, 8), "Mid-range Android smartphone", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 280.0, 270.0, 250.0, 260.0, 95, "Samsung Galaxy M33" },
                    { 130, "Nike", 7, new DateOnly(2025, 9, 8), "Duffel bag for gym and sports", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 65.0, 62.0, 58.0, 60.0, 70, "Nike Training Bag Medium" },
                    { 131, "Sony", 29, new DateOnly(2025, 9, 8), "Virtual reality headset for PlayStation 5", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 550.0, 540.0, 520.0, 530.0, 40, "Sony PS5 VR2 Headset" },
                    { 132, "Apple", 23, new DateOnly(2025, 9, 8), "All-in-one desktop computer", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500.0, 1470.0, 1420.0, 1450.0, 30, "Apple iMac 24 Inch" },
                    { 133, "Gucci", 10, new DateOnly(2025, 9, 8), "Designer leather belt", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 600.0, 580.0, 540.0, 560.0, 50, "Gucci Belt" },
                    { 134, "Samsung", 26, new DateOnly(2025, 9, 8), "Premium wireless earbuds", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 220.0, 210.0, 200.0, 205.0, 90, "Samsung Galaxy Buds Pro" },
                    { 135, "Nike", 2, new DateOnly(2025, 9, 8), "Stylish hoodie for women", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.0, 52.0, 48.0, 50.0, 85, "Nike Hoodie Women" },
                    { 136, "Sony", 31, new DateOnly(2025, 9, 8), "Large screen smart TV", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2500.0, 2450.0, 2350.0, 2400.0, 20, "Sony 85 Inch 4K TV" },
                    { 137, "Apple", 21, new DateOnly(2025, 9, 8), "Latest iPhone with advanced features", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1100.0, 1080.0, 1040.0, 1060.0, 60, "Apple iPhone 14" },
                    { 138, "Adidas", 6, new DateOnly(2025, 9, 8), "Lightweight sneakers for kids", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.0, 42.0, 38.0, 40.0, 100, "Adidas Training Shoes Kids" },
                    { 139, "Samsung", 21, new DateOnly(2025, 9, 8), "Flagship Android smartphone", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1200.0, 1180.0, 1140.0, 1160.0, 40, "Samsung Galaxy S21 Ultra" },
                    { 140, "Nike", 9, new DateOnly(2025, 9, 8), "Pack of 3 cotton socks", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.0, 18.0, 16.0, 17.0, 200, "Nike Training Socks Pack" },
                    { 141, "Sony", 30, new DateOnly(2025, 9, 8), "Racing game for PS5", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.0, 65.0, 60.0, 62.0, 100, "Sony PS5 Game - Gran Turismo" },
                    { 142, "Apple", 26, new DateOnly(2025, 9, 8), "Protective silicone case", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 14.0, 12.0, 13.0, 150, "Apple AirPods Case" },
                    { 143, "Gucci", 97, new DateOnly(2025, 9, 8), "Luxury gold necklace", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500.0, 1480.0, 1440.0, 1460.0, 25, "Gucci Necklace" },
                    { 144, "Samsung", 24, new DateOnly(2025, 9, 8), "Smartwatch with fitness features", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 300.0, 290.0, 270.0, 280.0, 65, "Samsung Galaxy Watch 4" },
                    { 145, "Nike", 77, new DateOnly(2025, 9, 8), "Reusable water bottle", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.0, 16.0, 14.0, 15.0, 180, "Nike Sports Bottle" },
                    { 146, "Adidas", 1, new DateOnly(2025, 9, 8), "Casual hoodie for daily wear", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.0, 55.0, 50.0, 52.0, 80, "Adidas Hoodie Men" },
                    { 147, "Sony", 27, new DateOnly(2025, 9, 8), "Premium surround sound system", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1200.0, 1180.0, 1140.0, 1160.0, 30, "Sony Home Theater System" },
                    { 148, "Apple", 21, new DateOnly(2025, 9, 8), "Protective case for iPhone models", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 23.0, 20.0, 22.0, 200, "Apple iPhone Case" },
                    { 149, "Nike", 1, new DateOnly(2025, 9, 8), "Comfortable sweatpants", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.0, 48.0, 44.0, 46.0, 100, "Nike Sweatpants Men" },
                    { 150, "Samsung", 21, new DateOnly(2025, 9, 8), "Reliable Android smartphone", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0, 480.0, 440.0, 460.0, 75, "Samsung Galaxy S10" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderHeaderId",
                table: "OrderDetails",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_UserID",
                table: "OrderHeaders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_productId",
                table: "Reviews",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ProductId",
                table: "ShoppingCarts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserID",
                table: "ShoppingCarts",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
