﻿// <auto-generated />
using System;
using EfCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfCore.Migrations
{
    [DbContext(typeof(AumsContext))]
    partial class AumsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfCore.Models.IpInfo", b =>
                {
                    b.Property<int>("IpInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("IpAddress")
                        .HasMaxLength(16)
                        .HasColumnType("varbinary(16)");

                    b.Property<short>("PermissionSendingType")
                        .HasColumnType("smallint");

                    b.Property<bool?>("PermissionYn")
                        .HasColumnType("bit");

                    b.Property<bool?>("UseYn")
                        .HasColumnType("bit");

                    b.Property<int?>("UserInfoId")
                        .HasColumnType("int");

                    b.HasKey("IpInfoId");

                    b.HasIndex("IpAddress");

                    b.HasIndex("UserInfoId");

                    b.ToTable("IpInfos");
                });

            modelBuilder.Entity("EfCore.Models.UserInfo", b =>
                {
                    b.Property<int>("UserInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CmpCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmpNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserInfoId");

                    b.ToTable("UserInfos");
                });

            modelBuilder.Entity("EfCore.Models.IpInfo", b =>
                {
                    b.HasOne("EfCore.Models.UserInfo", "UserInfo")
                        .WithMany("IpInfos")
                        .HasForeignKey("UserInfoId");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("EfCore.Models.UserInfo", b =>
                {
                    b.Navigation("IpInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
