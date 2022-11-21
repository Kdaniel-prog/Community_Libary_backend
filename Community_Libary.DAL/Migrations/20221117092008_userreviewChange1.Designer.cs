﻿// <auto-generated />
using System;
using Community_Libary.DAL.DATA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Community_Libary.DAL.Migrations
{
    [DbContext(typeof(Community_LibaryDbContext))]
    [Migration("20221117092008_userreviewChange1")]
    partial class userreviewChange1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Community_Libary.DAL.Models.BookReviews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("BookReview")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReviewerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("BookReviews");
                });

            modelBuilder.Entity("Community_Libary.DAL.Models.Books", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Community_Libary.DAL.Models.Borrowed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<int?>("BorrowerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("BorrowerId");

                    b.ToTable("Borrowed");
                });

            modelBuilder.Entity("Community_Libary.DAL.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsRecommend")
                        .HasColumnType("bit");

                    b.Property<int?>("ReviewedId")
                        .HasColumnType("int");

                    b.Property<int?>("ReviewerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReviewedId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Community_Libary.DAL.Models.UserReviews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.Property<int>("ReviewedId")
                        .HasColumnType("int");

                    b.Property<int>("dislike")
                        .HasColumnType("int");

                    b.Property<int>("like")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.HasIndex("ReviewedId");

                    b.ToTable("UserReviews");
                });

            modelBuilder.Entity("Community_Libary.DAL.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Community_Libary.DAL.Models.BookReviews", b =>
                {
                    b.HasOne("Community_Libary.DAL.Models.Books", "Book")
                        .WithMany("ReviewBooks")
                        .HasForeignKey("BookId");

                    b.HasOne("Community_Libary.DAL.Models.Users", "Reviewer")
                        .WithMany("BookReviews")
                        .HasForeignKey("ReviewerId");

                    b.Navigation("Book");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("Community_Libary.DAL.Models.Books", b =>
                {
                    b.HasOne("Community_Libary.DAL.Models.Users", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Community_Libary.DAL.Models.Borrowed", b =>
                {
                    b.HasOne("Community_Libary.DAL.Models.Books", "Book")
                        .WithMany("BorrowedBooks")
                        .HasForeignKey("BookId");

                    b.HasOne("Community_Libary.DAL.Models.Users", "borrower")
                        .WithMany("Borrowers")
                        .HasForeignKey("BorrowerId");

                    b.Navigation("Book");

                    b.Navigation("borrower");
                });

            modelBuilder.Entity("Community_Libary.DAL.Models.Review", b =>
                {
                    b.HasOne("Community_Libary.DAL.Models.Users", "Reviewed")
                        .WithMany("Revieweds")
                        .HasForeignKey("ReviewedId");

                    b.HasOne("Community_Libary.DAL.Models.Users", "Reviewer")
                        .WithMany("Reviewers")
                        .HasForeignKey("ReviewerId");

                    b.Navigation("Reviewed");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("Community_Libary.DAL.Models.UserReviews", b =>
                {
                    b.HasOne("Community_Libary.DAL.Models.Review", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Community_Libary.DAL.Models.Users", "Reviewed")
                        .WithMany()
                        .HasForeignKey("ReviewedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Review");

                    b.Navigation("Reviewed");
                });

            modelBuilder.Entity("Community_Libary.DAL.Models.Books", b =>
                {
                    b.Navigation("BorrowedBooks");

                    b.Navigation("ReviewBooks");
                });

            modelBuilder.Entity("Community_Libary.DAL.Models.Users", b =>
                {
                    b.Navigation("BookReviews");

                    b.Navigation("Borrowers");

                    b.Navigation("Revieweds");

                    b.Navigation("Reviewers");
                });
#pragma warning restore 612, 618
        }
    }
}
