﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using QuizApp.Infrastructure.DAL;

#nullable disable

namespace QuizApp.Infrastructure.DAL.Migrations
{
    [DbContext(typeof(QuizAppDbContext))]
    partial class QuizAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("QuizApp.Core.Entities.QuestionTypes.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("QuizId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");

                    b.HasDiscriminator<string>("Type").HasValue("Question");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("QuizApp.Core.Entities.QuestionTypes.SelectAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("SingleChoiceQuestionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SingleChoiceQuestionId");

                    b.ToTable("SelectAnswers");
                });

            modelBuilder.Entity("QuizApp.Core.Entities.Quiz", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("QuizApp.Core.Entities.UserQuestionTypes.UserQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid");

                    b.Property<int>("ScoredPoints")
                        .HasColumnType("integer");

                    b.Property<Guid?>("UserQuizResultId")
                        .HasColumnType("uuid");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasMaxLength(34)
                        .HasColumnType("character varying(34)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserQuizResultId");

                    b.ToTable("UserQuestions");

                    b.HasDiscriminator<string>("type").HasValue("UserQuestion");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("QuizApp.Core.Entities.UserQuizResult", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("QuizId")
                        .HasColumnType("uuid");

                    b.Property<int>("TotalPoints")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("UserQuizResults");
                });

            modelBuilder.Entity("QuizApp.Core.Entities.QuestionTypes.ShortAnswerQuestion", b =>
                {
                    b.HasBaseType("QuizApp.Core.Entities.QuestionTypes.Question");

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("ShortAnswerQuestion");
                });

            modelBuilder.Entity("QuizApp.Core.Entities.QuestionTypes.SingleChoiceQuestion", b =>
                {
                    b.HasBaseType("QuizApp.Core.Entities.QuestionTypes.Question");

                    b.HasDiscriminator().HasValue("SingleChoiceQuestion");
                });

            modelBuilder.Entity("QuizApp.Core.Entities.UserQuestionTypes.UserShortAnswerQuestion", b =>
                {
                    b.HasBaseType("QuizApp.Core.Entities.UserQuestionTypes.UserQuestion");

                    b.Property<string>("ShortAnswer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("UserShortAnswerQuestion");
                });

            modelBuilder.Entity("QuizApp.Core.Entities.UserQuestionTypes.UserSingleChoiceQuestion", b =>
                {
                    b.HasBaseType("QuizApp.Core.Entities.UserQuestionTypes.UserQuestion");

                    b.Property<Guid>("SeletcedAnswerId")
                        .HasColumnType("uuid");

                    b.HasIndex("SeletcedAnswerId");

                    b.HasDiscriminator().HasValue("UserSingleChoiceQuestion");
                });

            modelBuilder.Entity("QuizApp.Core.Entities.QuestionTypes.Question", b =>
                {
                    b.HasOne("QuizApp.Core.Entities.Quiz", null)
                        .WithMany("Questions")
                        .HasForeignKey("QuizId");
                });

            modelBuilder.Entity("QuizApp.Core.Entities.QuestionTypes.SelectAnswer", b =>
                {
                    b.HasOne("QuizApp.Core.Entities.QuestionTypes.SingleChoiceQuestion", null)
                        .WithMany("SelectAnswers")
                        .HasForeignKey("SingleChoiceQuestionId");
                });

            modelBuilder.Entity("QuizApp.Core.Entities.UserQuestionTypes.UserQuestion", b =>
                {
                    b.HasOne("QuizApp.Core.Entities.QuestionTypes.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizApp.Core.Entities.UserQuizResult", null)
                        .WithMany("UserQuestions")
                        .HasForeignKey("UserQuizResultId");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuizApp.Core.Entities.UserQuizResult", b =>
                {
                    b.HasOne("QuizApp.Core.Entities.Quiz", null)
                        .WithMany()
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuizApp.Core.Entities.UserQuestionTypes.UserSingleChoiceQuestion", b =>
                {
                    b.HasOne("QuizApp.Core.Entities.QuestionTypes.SelectAnswer", null)
                        .WithMany()
                        .HasForeignKey("SeletcedAnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuizApp.Core.Entities.Quiz", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("QuizApp.Core.Entities.UserQuizResult", b =>
                {
                    b.Navigation("UserQuestions");
                });

            modelBuilder.Entity("QuizApp.Core.Entities.QuestionTypes.SingleChoiceQuestion", b =>
                {
                    b.Navigation("SelectAnswers");
                });
#pragma warning restore 612, 618
        }
    }
}