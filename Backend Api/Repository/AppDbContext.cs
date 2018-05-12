using Backend_Api.Repo_Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Repository {
    /**
     * Initializes database with EntityFramework.
     **/
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Module>().ToTable("Module");
            modelBuilder.Entity<ModuleTextContent>().ToTable("ModuleTextContent");
            modelBuilder.Entity<ModuleVideoContent>().ToTable("ModuleVideoContent");
            modelBuilder.Entity<ModuleImageContent>().ToTable("ModuleImageContent");
            modelBuilder.Entity<ModuleQuizContent>().ToTable("ModuleQuizContent");

            // set many-to-many relationship between courses and modules
            modelBuilder.Entity<CourseModule>().HasKey(
                x => new { x.CourseId, x.ModuleId });

            modelBuilder.Entity<CourseModule>()
                        .HasOne(x => x.Course)
                        .WithMany(x => x.CourseModules)
                        .HasForeignKey(x => x.CourseId);

            modelBuilder.Entity<CourseModule>()
                        .HasOne(x => x.Module)
                        .WithMany(x => x.CourseModules)
                        .HasForeignKey(x => x.ModuleId);
        }
    }
}
