using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pajutrao_Project.Models;

public partial class FourtifyContext : DbContext
{
    public FourtifyContext()
    {
    }

    public FourtifyContext(DbContextOptions<FourtifyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<QuizScore> QuizScores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-SV4QTVS;Initial Catalog=Fourtify;Persist Security Info=True;TrustServerCertificate=True; User ID=sa;Password=Shuku@ki04042001");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccNo).HasName("PK__Accounts__91CBCB53876F5C43");

            entity.Property(e => e.AccNo).ValueGeneratedNever();
            entity.Property(e => e.AccName).HasMaxLength(100);
            entity.Property(e => e.AccPass).HasMaxLength(255);
            entity.Property(e => e.Ucanv).HasColumnName("UCanv");
            entity.Property(e => e.Udbf).HasColumnName("UDBF");
            entity.Property(e => e.Ufda).HasColumnName("UFda");
            entity.Property(e => e.Ulog).HasColumnName("ULog");
        });

        modelBuilder.Entity<QuizScore>(entity =>
        {
            entity.HasKey(e => e.QuizNo).HasName("PK__QuizScor__8B4285F5376CF5E7");

            entity.ToTable("QuizScore");

            entity.Property(e => e.QuizNo).ValueGeneratedNever();
            entity.Property(e => e.DateTimeTaken).HasColumnType("datetime");
            entity.Property(e => e.Score).HasMaxLength(50);

            entity.HasOne(d => d.AccountNoNavigation).WithMany(p => p.QuizScores)
                .HasForeignKey(d => d.AccountNo)
                .HasConstraintName("FK__QuizScore__Accou__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
