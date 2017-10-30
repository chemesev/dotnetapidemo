using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using apiserver.Models;

namespace apiserver.Migrations
{
    [DbContext(typeof(TasksDbContext))]
    [Migration("20171026125937_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("apiserver.Models.TodoTask", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<bool>("done");

                    b.Property<string>("title");

                    b.HasKey("id");

                    b.ToTable("TasksTable");
                });
        }
    }
}
