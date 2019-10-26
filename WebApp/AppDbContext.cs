namespace WebApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using Entities;
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<RoomMessage> RoomMessages { get; set; }
    }

    

  





}
