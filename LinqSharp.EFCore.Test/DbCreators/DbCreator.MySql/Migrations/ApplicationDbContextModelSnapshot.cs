﻿// <auto-generated />
using System;
using LinqSharp.EFCore.Data.Test;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DbCreator.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LinqSharp.EFCore.Data.LS_Name", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Note")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Name", "CreationTime")
                        .IsUnique();

                    b.ToTable("LS_Names");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.AppRegistry", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Item")
                        .HasColumnType("varchar(127) CHARACTER SET utf8mb4")
                        .HasMaxLength(127);

                    b.Property<string>("Key")
                        .HasColumnType("varchar(127) CHARACTER SET utf8mb4")
                        .HasMaxLength(127);

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("Item", "Key")
                        .IsUnique();

                    b.ToTable("AppRegistries");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.AuditLevel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Root")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<int>("ValueCount")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Root");

                    b.ToTable("AuditLevels");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.AuditRoot", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("LimitQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TotalQuantity")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AuditRoots");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.AuditValue", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<int>("Quantity")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Level");

                    b.ToTable("AuditValues");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.BulkTestModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .HasColumnName("UniqueCode")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("BulkTestModels");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.CPKeyModel", b =>
                {
                    b.Property<string>("Id1")
                        .HasColumnType("char(36)");

                    b.Property<string>("Id2")
                        .HasColumnType("char(36)");

                    b.HasKey("Id1", "Id2");

                    b.ToTable("CompositeKeyModels");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.ConcurrencyModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("CheckClientWin")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.Property<int>("CheckCombine")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.Property<int>("CheckDefault")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.Property<int>("CheckStoreWin")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.Property<int>("CheckThrow")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.Property<int>("RandomNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RandomNumber")
                        .IsUnique();

                    b.ToTable("ConcurrencyModels");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.EntityMonitorModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ChangeValues")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Event")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Key")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TypeName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("EntityMonitorModels");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.LS_Index", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Int0")
                        .HasColumnType("int");

                    b.Property<int>("Int1")
                        .HasColumnType("int");

                    b.Property<int>("Int2_G1")
                        .HasColumnType("int");

                    b.Property<int>("Int3_G1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Int0");

                    b.HasIndex("Int1")
                        .IsUnique();

                    b.HasIndex("Int2_G1", "Int3_G1")
                        .IsUnique();

                    b.ToTable("LS_Indices");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.LS_Provider", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("NameModel")
                        .HasColumnType("varchar(127) CHARACTER SET utf8mb4")
                        .HasMaxLength(127);

                    b.Property<string>("Password")
                        .HasColumnType("varchar(127) CHARACTER SET utf8mb4")
                        .HasMaxLength(127);

                    b.HasKey("Id");

                    b.ToTable("LS_Providers");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.SimpleModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SimpleModels");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.SimpleRow", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("SimpleRows");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.TrackModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ForCondensed")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ForLower")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ForTrim")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ForUpper")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("LastWriteTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("TrackModels");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.YearMonthModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("YearMonthModels");
                });

            modelBuilder.Entity("Northwnd.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("longblob");

                    b.HasKey("CategoryID");

                    b.ToTable("@Northwnd.Categories");
                });

            modelBuilder.Entity("Northwnd.Customer", b =>
                {
                    b.Property<string>("CustomerID")
                        .HasColumnType("varchar(5) CHARACTER SET utf8mb4")
                        .HasMaxLength(5);

                    b.Property<string>("Address")
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<string>("City")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("varchar(40) CHARACTER SET utf8mb4")
                        .HasMaxLength(40);

                    b.Property<string>("ContactName")
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4")
                        .HasMaxLength(30);

                    b.Property<string>("ContactTitle")
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4")
                        .HasMaxLength(30);

                    b.Property<string>("Country")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<string>("Fax")
                        .HasColumnType("varchar(24) CHARACTER SET utf8mb4")
                        .HasMaxLength(24);

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(24) CHARACTER SET utf8mb4")
                        .HasMaxLength(24);

                    b.Property<string>("PostalCode")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("Region")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.HasKey("CustomerID");

                    b.ToTable("@Northwnd.Customers");
                });

            modelBuilder.Entity("Northwnd.CustomerCustomerDemo", b =>
                {
                    b.Property<string>("CustomerTypeID")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("CustomerID")
                        .HasColumnType("varchar(5) CHARACTER SET utf8mb4")
                        .HasMaxLength(5);

                    b.HasKey("CustomerTypeID", "CustomerID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("CustomerTypeID");

                    b.ToTable("@Northwnd.CustomerCustomerDemos");
                });

            modelBuilder.Entity("Northwnd.CustomerDemographic", b =>
                {
                    b.Property<string>("CustomerTypeID")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("CustomerDesc")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CustomerTypeID");

                    b.ToTable("@Northwnd.CustomerDemographics");
                });

            modelBuilder.Entity("Northwnd.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("City")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<string>("Country")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<string>("Extension")
                        .HasColumnType("varchar(4) CHARACTER SET utf8mb4")
                        .HasMaxLength(4);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("HomePhone")
                        .HasColumnType("varchar(24) CHARACTER SET utf8mb4")
                        .HasMaxLength(24);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("Notes")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("longblob");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("PostalCode")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("Region")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<int?>("ReportsTo")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4")
                        .HasMaxLength(30);

                    b.Property<string>("TitleOfCourtesy")
                        .HasColumnType("varchar(25) CHARACTER SET utf8mb4")
                        .HasMaxLength(25);

                    b.HasKey("EmployeeID");

                    b.HasIndex("ReportsTo");

                    b.ToTable("@Northwnd.Employees");
                });

            modelBuilder.Entity("Northwnd.EmployeeTerritory", b =>
                {
                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("TerritoryID")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.HasKey("EmployeeID", "TerritoryID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("TerritoryID");

                    b.ToTable("@Northwnd.EmployeeTerritories");
                });

            modelBuilder.Entity("Northwnd.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<string>("CustomerID")
                        .HasColumnType("varchar(5) CHARACTER SET utf8mb4")
                        .HasMaxLength(5);

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<double?>("Freight")
                        .HasColumnType("double");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("RequiredDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ShipAddress")
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<string>("ShipCity")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<string>("ShipCountry")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<string>("ShipName")
                        .HasColumnType("varchar(40) CHARACTER SET utf8mb4")
                        .HasMaxLength(40);

                    b.Property<string>("ShipPostalCode")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("ShipRegion")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<int?>("ShipVia")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ShippedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ShipVia");

                    b.ToTable("@Northwnd.Orders");
                });

            modelBuilder.Entity("Northwnd.OrderDetail", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<float>("Discount")
                        .HasColumnType("float");

                    b.Property<short>("Quantity")
                        .HasColumnType("smallint");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("double");

                    b.HasKey("OrderID", "ProductID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("@Northwnd.OrderDetails");
                });

            modelBuilder.Entity("Northwnd.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<bool>("Discontinued")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("varchar(40) CHARACTER SET utf8mb4")
                        .HasMaxLength(40);

                    b.Property<string>("QuantityPerUnit")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<short?>("ReorderLevel")
                        .HasColumnType("smallint");

                    b.Property<int?>("SupplierID")
                        .HasColumnType("int");

                    b.Property<double?>("UnitPrice")
                        .HasColumnType("double");

                    b.Property<short?>("UnitsInStock")
                        .HasColumnType("smallint");

                    b.Property<short?>("UnitsOnOrder")
                        .HasColumnType("smallint");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("SupplierID");

                    b.ToTable("@Northwnd.Products");
                });

            modelBuilder.Entity("Northwnd.Region", b =>
                {
                    b.Property<int>("RegionID")
                        .HasColumnType("int");

                    b.Property<string>("RegionDescription")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.HasKey("RegionID");

                    b.ToTable("@Northwnd.Regions");
                });

            modelBuilder.Entity("Northwnd.Shipper", b =>
                {
                    b.Property<int>("ShipperID")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("varchar(40) CHARACTER SET utf8mb4")
                        .HasMaxLength(40);

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(24) CHARACTER SET utf8mb4")
                        .HasMaxLength(24);

                    b.HasKey("ShipperID");

                    b.ToTable("@Northwnd.Shippers");
                });

            modelBuilder.Entity("Northwnd.Supplier", b =>
                {
                    b.Property<int>("SupplierID")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<string>("City")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("varchar(40) CHARACTER SET utf8mb4")
                        .HasMaxLength(40);

                    b.Property<string>("ContactName")
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4")
                        .HasMaxLength(30);

                    b.Property<string>("ContactTitle")
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4")
                        .HasMaxLength(30);

                    b.Property<string>("Country")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<string>("Fax")
                        .HasColumnType("varchar(24) CHARACTER SET utf8mb4")
                        .HasMaxLength(24);

                    b.Property<string>("HomePage")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(24) CHARACTER SET utf8mb4")
                        .HasMaxLength(24);

                    b.Property<string>("PostalCode")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("Region")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.HasKey("SupplierID");

                    b.ToTable("@Northwnd.Suppliers");
                });

            modelBuilder.Entity("Northwnd.Territory", b =>
                {
                    b.Property<string>("TerritoryID")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<int>("RegionID")
                        .HasColumnType("int");

                    b.Property<string>("TerritoryDescription")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.HasKey("TerritoryID");

                    b.HasIndex("RegionID");

                    b.ToTable("@Northwnd.Territories");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.AuditLevel", b =>
                {
                    b.HasOne("LinqSharp.EFCore.Data.Test.AuditRoot", "RootLink")
                        .WithMany("Levels")
                        .HasForeignKey("Root")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.AuditValue", b =>
                {
                    b.HasOne("LinqSharp.EFCore.Data.Test.AuditLevel", "LevelLink")
                        .WithMany("Values")
                        .HasForeignKey("Level")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.SimpleRow", b =>
                {
                    b.OwnsOne("LinqSharp.EFCore.Data.Test.SimpleRowItemGroup2", "Group", b1 =>
                        {
                            b1.Property<string>("SimpleRowId")
                                .HasColumnType("char(36)");

                            b1.Property<int>("Age")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                                .HasMaxLength(255);

                            b1.HasKey("SimpleRowId");

                            b1.ToTable("SimpleRows");

                            b1.WithOwner()
                                .HasForeignKey("SimpleRowId");
                        });
                });

            modelBuilder.Entity("Northwnd.CustomerCustomerDemo", b =>
                {
                    b.HasOne("Northwnd.Customer", "CustomerLink")
                        .WithMany("CustomerCustomerDemos")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Northwnd.CustomerDemographic", "CustomerDemographicLink")
                        .WithMany("CustomerCustomerDemos")
                        .HasForeignKey("CustomerTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Northwnd.Employee", b =>
                {
                    b.HasOne("Northwnd.Employee", "Superordinate")
                        .WithMany("Subordinates")
                        .HasForeignKey("ReportsTo");
                });

            modelBuilder.Entity("Northwnd.EmployeeTerritory", b =>
                {
                    b.HasOne("Northwnd.Employee", "EmployeeLink")
                        .WithMany("EmployeeTerritories")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Northwnd.Territory", "TerritoryLink")
                        .WithMany("EmployeeTerritories")
                        .HasForeignKey("TerritoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Northwnd.Order", b =>
                {
                    b.HasOne("Northwnd.Customer", "CustomerLink")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID");

                    b.HasOne("Northwnd.Employee", "EmployeeLink")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeID");

                    b.HasOne("Northwnd.Shipper", "Shipper")
                        .WithMany("Orders")
                        .HasForeignKey("ShipVia");
                });

            modelBuilder.Entity("Northwnd.OrderDetail", b =>
                {
                    b.HasOne("Northwnd.Order", "OrderLink")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Northwnd.Product", "ProductLink")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Northwnd.Product", b =>
                {
                    b.HasOne("Northwnd.Category", "CategoryLink")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID");

                    b.HasOne("Northwnd.Supplier", "SupplierLink")
                        .WithMany("Products")
                        .HasForeignKey("SupplierID");
                });

            modelBuilder.Entity("Northwnd.Territory", b =>
                {
                    b.HasOne("Northwnd.Region", "Region")
                        .WithMany("Territories")
                        .HasForeignKey("RegionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
