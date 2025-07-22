
using Bufferflow.database.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bufferflow.database
{
    public class BufferflowContext : DbContext
    {

       public BufferflowContext() : base("BOF")
        {

        }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
         public DbSet<Question> Questions { get; set; }
         public DbSet<Answer> Answers { get; set; }
         public DbSet<Vote> Votes { get; set; }
        public DbSet<Login> Logins { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           //  modelBuilder.Entity<Question>().HasOptional(p => p.User).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<Answer>().HasOptional(p => p.Question).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<Vote>().HasOptional(p => p.Answer).WithMany().WillCascadeOnDelete(true);
            //modelBuilder.Entity<Vote>().HasOptional(p => p.VotedBy).WithMany().WillCascadeOnDelete(true);
            //modelBuilder.Entity<Answer>().HasOptional(p => p.Author).WithMany().WillCascadeOnDelete(true);



            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
