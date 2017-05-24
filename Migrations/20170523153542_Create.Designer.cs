using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using apiserver;

namespace apiserver.Migrations
{
    [DbContext(typeof(TasksDb))]
    [Migration("20170523153542_Create")]
    partial class Create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("apiserver.Task", b =>
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
