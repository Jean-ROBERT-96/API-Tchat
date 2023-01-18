using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.Models;
using System.Threading.Channels;
using System.Reflection.Emit;

namespace DataAccess
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<CommonLibrary.Models.Channel> Channels { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message", "dbo");

                entity.HasOne(d => d.IdChannelNavigation)
                .WithMany(p => p.Messages)
                .HasForeignKey(d => d.IdChannel)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Message_Channel0_FK");

                entity.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.Messages)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Message_User_FK");
            });

            modelBuilder.Entity<CommonLibrary.Models.Channel>(entity =>
            {
                entity.ToTable("Channel", "dbo");

                entity.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.Channels)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Channel_User_FK");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "dbo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
