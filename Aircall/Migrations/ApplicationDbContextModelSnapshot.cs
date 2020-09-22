using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Aircall.Data;

namespace Aircall.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.3");

            modelBuilder.Entity("Aircall.Model.Password", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("pass");

                    b.HasKey("id");

                    b.ToTable("passes");
                });

            modelBuilder.Entity("Aircall.Model.Peoples", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress");

                    b.Property<string>("Data");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Telephone");

                    b.Property<string>("firstName");

                    b.Property<string>("lastName");

                    b.HasKey("id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Aircall.Model.SaveProperties", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("prop");

                    b.HasKey("id");

                    b.ToTable("saveProp");
                });
        }
    }
}
