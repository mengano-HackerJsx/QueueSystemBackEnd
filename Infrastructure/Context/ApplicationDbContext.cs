using Domain.Entities;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public interface IApplicationDbContext
    {
        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<QueueLine> QueueLines { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<PersonCondition> PersonCondition { get; set; }
        public DbSet<QueuePerson> QueuePerson { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonCondition>()
                .HasKey(personCondition 
                => new { personCondition.PersonId, personCondition.ConditionId});

            modelBuilder.Entity<QueuePerson>()
                .HasKey(queuePerson
                => new { queuePerson.PersonId, queuePerson.QueueLineId});
        }

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : BaseEntity
        {
            return Set<TEntity>();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync
            (CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
