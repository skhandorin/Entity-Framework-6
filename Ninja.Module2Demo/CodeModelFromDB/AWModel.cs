namespace CodeModelFromDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AWModel : DbContext
    {
        public AWModel()
            : base("name=AWModel")
        {
        }

        public virtual DbSet<discipline> disciplines { get; set; }
        public virtual DbSet<group> groups { get; set; }
        public virtual DbSet<student> students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<discipline>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<discipline>()
                .HasMany(e => e.groups)
                .WithMany(e => e.disciplines)
                .Map(m => m.ToTable("groups_disciplines").MapLeftKey("discipline_id").MapRightKey("group_id"));

            modelBuilder.Entity<group>()
                .Property(e => e.group_code)
                .IsFixedLength();

            modelBuilder.Entity<group>()
                .Property(e => e.speciality)
                .IsFixedLength();

            modelBuilder.Entity<group>()
                .HasMany(e => e.students)
                .WithRequired(e => e.group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<student>()
                .Property(e => e.name)
                .IsFixedLength();
        }
    }
}
