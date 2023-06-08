﻿// <auto-generated />
using GraphEditor.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GraphEditor.Migrations
{
    [DbContext(typeof(GraphDBContext))]
    partial class GraphDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EfCoreTest.Model.GraphModel.GraphData", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("GraphData");
                });

            modelBuilder.Entity("GraphEditor.Model.GraphModel.Edge", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("FromId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GraphDataId")
                        .HasColumnType("text");

                    b.Property<string>("ToId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.HasIndex("GraphDataId");

                    b.HasIndex("ToId");

                    b.ToTable("Edge");
                });

            modelBuilder.Entity("GraphEditor.Model.GraphModel.Graph", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ClassGraphId")
                        .HasColumnType("text");

                    b.Property<string>("CreatorId")
                        .HasColumnType("text");

                    b.Property<string>("DataId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("GraphType")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClassGraphId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("DataId");

                    b.ToTable("Graphs");
                });

            modelBuilder.Entity("GraphEditor.Model.GraphModel.Node", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("GraphDataId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GraphDataId");

                    b.ToTable("Node");
                });

            modelBuilder.Entity("GraphEditor.Model.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GraphUser_Edit", b =>
                {
                    b.Property<string>("CanBeEditedById")
                        .HasColumnType("text");

                    b.Property<string>("CanEditId")
                        .HasColumnType("text");

                    b.HasKey("CanBeEditedById", "CanEditId");

                    b.HasIndex("CanEditId");

                    b.ToTable("GraphUser_Edit");
                });

            modelBuilder.Entity("GraphUser_View", b =>
                {
                    b.Property<string>("CanBeViewedById")
                        .HasColumnType("text");

                    b.Property<string>("CanViewId")
                        .HasColumnType("text");

                    b.HasKey("CanBeViewedById", "CanViewId");

                    b.HasIndex("CanViewId");

                    b.ToTable("GraphUser_View");
                });

            modelBuilder.Entity("GraphEditor.Model.GraphModel.Edge", b =>
                {
                    b.HasOne("GraphEditor.Model.GraphModel.Node", "From")
                        .WithMany()
                        .HasForeignKey("FromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCoreTest.Model.GraphModel.GraphData", null)
                        .WithMany("Edges")
                        .HasForeignKey("GraphDataId");

                    b.HasOne("GraphEditor.Model.GraphModel.Node", "To")
                        .WithMany()
                        .HasForeignKey("ToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("GraphEditor.Model.GraphModel.EdgeMeta", "Meta", b1 =>
                        {
                            b1.Property<string>("EdgeId")
                                .HasColumnType("text");

                            b1.Property<float>("Value")
                                .HasColumnType("real");

                            b1.HasKey("EdgeId");

                            b1.ToTable("Edge");

                            b1.WithOwner()
                                .HasForeignKey("EdgeId");
                        });

                    b.Navigation("From");

                    b.Navigation("Meta")
                        .IsRequired();

                    b.Navigation("To");
                });

            modelBuilder.Entity("GraphEditor.Model.GraphModel.Graph", b =>
                {
                    b.HasOne("GraphEditor.Model.GraphModel.Graph", "ClassGraph")
                        .WithMany()
                        .HasForeignKey("ClassGraphId");

                    b.HasOne("GraphEditor.Model.User", "Creator")
                        .WithMany("Creations")
                        .HasForeignKey("CreatorId");

                    b.HasOne("EfCoreTest.Model.GraphModel.GraphData", "Data")
                        .WithMany()
                        .HasForeignKey("DataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassGraph");

                    b.Navigation("Creator");

                    b.Navigation("Data");
                });

            modelBuilder.Entity("GraphEditor.Model.GraphModel.Node", b =>
                {
                    b.HasOne("EfCoreTest.Model.GraphModel.GraphData", null)
                        .WithMany("Nodes")
                        .HasForeignKey("GraphDataId");

                    b.OwnsOne("GraphEditor.Model.GraphModel.NodeMeta", "Meta", b1 =>
                        {
                            b1.Property<string>("NodeId")
                                .HasColumnType("text");

                            b1.Property<string>("Color")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("NodeClass")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<float>("X")
                                .HasColumnType("real");

                            b1.Property<float>("Y")
                                .HasColumnType("real");

                            b1.HasKey("NodeId");

                            b1.ToTable("Node");

                            b1.WithOwner()
                                .HasForeignKey("NodeId");
                        });

                    b.Navigation("Meta")
                        .IsRequired();
                });

            modelBuilder.Entity("GraphUser_Edit", b =>
                {
                    b.HasOne("GraphEditor.Model.User", null)
                        .WithMany()
                        .HasForeignKey("CanBeEditedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GraphEditor.Model.GraphModel.Graph", null)
                        .WithMany()
                        .HasForeignKey("CanEditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GraphUser_View", b =>
                {
                    b.HasOne("GraphEditor.Model.User", null)
                        .WithMany()
                        .HasForeignKey("CanBeViewedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GraphEditor.Model.GraphModel.Graph", null)
                        .WithMany()
                        .HasForeignKey("CanViewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfCoreTest.Model.GraphModel.GraphData", b =>
                {
                    b.Navigation("Edges");

                    b.Navigation("Nodes");
                });

            modelBuilder.Entity("GraphEditor.Model.User", b =>
                {
                    b.Navigation("Creations");
                });
#pragma warning restore 612, 618
        }
    }
}
