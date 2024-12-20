using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EldenRingBuildBackend.Models;

public partial class EldenBuildsContext : DbContext
{
    public EldenBuildsContext()
    {
    }

    public EldenBuildsContext(DbContextOptions<EldenBuildsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Build> Builds { get; set; }

    public virtual DbSet<Created> Createds { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(Secret.information);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Build>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Builds__3214EC0783DEFD61");

            entity.Property(e => e.ArmorBody)
                .HasMaxLength(255)
                .HasColumnName("armorBody");
            entity.Property(e => e.ArmorHands)
                .HasMaxLength(255)
                .HasColumnName("armorHands");
            entity.Property(e => e.ArmorHead)
                .HasMaxLength(255)
                .HasColumnName("armorHead");
            entity.Property(e => e.ArmorLegs)
                .HasMaxLength(255)
                .HasColumnName("armorLegs");
            entity.Property(e => e.AshOfWar)
                .HasMaxLength(255)
                .HasColumnName("ashOfWar");
            entity.Property(e => e.BuildName)
                .HasMaxLength(255)
                .HasColumnName("buildName");
            entity.Property(e => e.Classes).HasMaxLength(255);
            entity.Property(e => e.Shield)
                .HasMaxLength(255)
                .HasColumnName("shield");
            entity.Property(e => e.Spell1)
                .HasMaxLength(255)
                .HasColumnName("spell1");
            entity.Property(e => e.Spell10)
                .HasMaxLength(255)
                .HasColumnName("spell10");
            entity.Property(e => e.Spell11)
                .HasMaxLength(255)
                .HasColumnName("spell11");
            entity.Property(e => e.Spell12)
                .HasMaxLength(255)
                .HasColumnName("spell12");
            entity.Property(e => e.Spell2)
                .HasMaxLength(255)
                .HasColumnName("spell2");
            entity.Property(e => e.Spell3)
                .HasMaxLength(255)
                .HasColumnName("spell3");
            entity.Property(e => e.Spell4)
                .HasMaxLength(255)
                .HasColumnName("spell4");
            entity.Property(e => e.Spell5)
                .HasMaxLength(255)
                .HasColumnName("spell5");
            entity.Property(e => e.Spell6)
                .HasMaxLength(255)
                .HasColumnName("spell6");
            entity.Property(e => e.Spell7)
                .HasMaxLength(255)
                .HasColumnName("spell7");
            entity.Property(e => e.Spell8)
                .HasMaxLength(255)
                .HasColumnName("spell8");
            entity.Property(e => e.Spell9)
                .HasMaxLength(255)
                .HasColumnName("spell9");
            entity.Property(e => e.Talisman1)
                .HasMaxLength(255)
                .HasColumnName("talisman1");
            entity.Property(e => e.Talisman2)
                .HasMaxLength(255)
                .HasColumnName("talisman2");
            entity.Property(e => e.Talisman3)
                .HasMaxLength(255)
                .HasColumnName("talisman3");
            entity.Property(e => e.Talisman4)
                .HasMaxLength(255)
                .HasColumnName("talisman4");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("userId");
            entity.Property(e => e.Weapon1)
                .HasMaxLength(255)
                .HasColumnName("weapon1");
            entity.Property(e => e.Weapon2)
                .HasMaxLength(255)
                .HasColumnName("weapon2");
        });

        modelBuilder.Entity<Created>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Created__3214EC078E759576");

            entity.ToTable("Created");

            entity.Property(e => e.BuildId).HasColumnName("buildId");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("userId");

            entity.HasOne(d => d.Build).WithMany(p => p.Createds)
                .HasForeignKey(d => d.BuildId)
                .HasConstraintName("FK__Created__buildId__4BAC3F29");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Favorite__3214EC07707BE6D9");

            entity.ToTable("Favorite");

            entity.Property(e => e.BuildId).HasColumnName("buildId");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("userId");

            entity.HasOne(d => d.Build).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.BuildId)
                .HasConstraintName("FK__Favorite__buildI__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
