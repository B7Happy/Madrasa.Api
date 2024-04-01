using Madrasa.Api.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Madrasa.Api
{
    public class MadrasaDb : DbContext
    {
        public MadrasaDb(DbContextOptions<MadrasaDb> options)
            : base(options) { }

        public DbSet<Bulletin> Bulletin { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Eleves> Eleves { get; set; }
        public DbSet<Examen> Examen { get; set; }
        public DbSet<Groupe> Groupe { get; set; }
        public DbSet<Horaire> Horaire { get; set; }
        public DbSet<Maison> Maison { get; set; }
        public DbSet<Matieres> Matieres { get; set; }
        public DbSet<Parent> Parent { get; set; }
        public DbSet<Professeurs> Professeurs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Bulletin>()
            //    .HasOne(b => b.Eleves)
            //    .WithMany(e => e.Bulletin)
            //    .HasForeignKey(b => b.ElevesId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Bulletin>()
            //    .HasOne(b => b.Examen)
            //    .WithMany(e => e.Bulletin)
            //    .HasForeignKey(b => b.ExamenId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Classes>()
            //    .HasOne(c => c.Groupe)
            //    .WithMany(g => g.Classes)
            //    .HasForeignKey(c => c.GroupeId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Classes>()
            //    .HasOne(c => c.Professeurs)
            //    .WithMany(p => p.Classes)
            //    .HasForeignKey(c => c.ProfesseursId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Eleves>()
            //    .HasOne(e => e.Classes)
            //    .WithMany(c => c.Eleves)
            //    .HasForeignKey(e => e.ClassesId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Eleves>()
            //    .HasOne(e => e.Parent)
            //    .WithMany(p => p.Eleves)
            //    .HasForeignKey(e => e.ParentId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Examen>()
            //    .HasOne(e => e.Classes)
            //    .WithOne(c => c.Examen)
            //    .HasForeignKey<Examen>(e => e.ClassesId)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Examen>()
                .HasOne(e => e.Professeurs)
                .WithOne(p => p.Examen)
                .HasForeignKey<Examen>(e => e.ProfesseursId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Matieres>()
            //    .HasOne(m => m.Classes)
            //    .WithMany(c => c.Matieres)
            //    .HasForeignKey(m => m.ClassesId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Parent>()
            //    .HasOne(p => p.Maison)
            //    .WithMany(m => m.Parent)
            //    .HasForeignKey(p => p.MaisonId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}