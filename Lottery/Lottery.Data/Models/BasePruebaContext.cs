using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Lottery.Core.Models;

namespace Lottery.Data.Models;

public partial class BasePruebaContext : DbContext
{
    public BasePruebaContext()
    {
    }

    public BasePruebaContext(DbContextOptions<BasePruebaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Avatar> Avatars { get; set; }

    public virtual DbSet<Banned> Banneds { get; set; }

    public virtual DbSet<Friendship> Friendships { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<SocialMedium> SocialMedia { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserGame> UserGames { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=base_prueba;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Avatar>(entity =>
        {
            entity.HasKey(e => e.IdAvatar);

            entity.ToTable("Avatar");

            entity.Property(e => e.IdAvatar).HasColumnName("id_avatar");
            entity.Property(e => e.AvatarName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("avatar_name");
            entity.Property(e => e.Path)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("path");
        });

        modelBuilder.Entity<Banned>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Banned");

            entity.Property(e => e.BanType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ban_type");
            entity.Property(e => e.BannedAt)
                .HasColumnType("datetime")
                .HasColumnName("banned_at");
            entity.Property(e => e.IdBanned)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_banned");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Reason)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("reason");
            entity.Property(e => e.UnbannedAt)
                .HasColumnType("datetime")
                .HasColumnName("unbanned_at");

            entity.HasOne(d => d.IdUserNavigation).WithMany()
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Banned_User");
        });

        modelBuilder.Entity<Friendship>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Friendship");

            entity.Property(e => e.IdUser1).HasColumnName("id_user1");
            entity.Property(e => e.IdUser2)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_user2");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.IdUser1Navigation).WithMany()
                .HasForeignKey(d => d.IdUser1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Friendship_User");

            entity.HasOne(d => d.IdUser2Navigation).WithMany()
                .HasForeignKey(d => d.IdUser2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Friendship_User1");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.IdGame);

            entity.ToTable("Game");

            entity.Property(e => e.IdGame).HasColumnName("id_game");
            entity.Property(e => e.IdWinner)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("id_winner");
        });

        modelBuilder.Entity<SocialMedium>(entity =>
        {
            entity.HasKey(e => e.IdSocialMedia);

            entity.Property(e => e.IdSocialMedia).HasColumnName("id_social_media");
            entity.Property(e => e.FacebookUser)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("facebook_user");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.InstagramUser)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("instagram_user");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.SocialMedia)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SocialMedia_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.IdAvatar).HasColumnName("id_avatar");
            entity.Property(e => e.MaternalLastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("maternal_last_name");
            entity.Property(e => e.Nickname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nickname");
            entity.Property(e => e.Password)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PaternalLastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("paternal_last_name");
            entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");
            entity.Property(e => e.Score).HasColumnName("score");

            entity.HasOne(d => d.IdAvatarNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdAvatar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Avatar");
        });

        modelBuilder.Entity<UserGame>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("User_Game");

            entity.Property(e => e.IdGame).HasColumnName("id_game");
            entity.Property(e => e.IdUser)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_user");

            entity.HasOne(d => d.IdGameNavigation).WithMany()
                .HasForeignKey(d => d.IdGame)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Game_Game");

            entity.HasOne(d => d.IdUserNavigation).WithMany()
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Game_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
