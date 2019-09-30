using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class MessageDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Filename=StartYourEdayMessage.db");

        public DbSet<MessageOfTheDay> Messages { get; set; }


        public void CheckInitialDataSetup() {

            if (this.Messages.Any()) return;


            Messages.Add(new MessageOfTheDay
            {
                Created = DateTime.Now,
                EnGb = "She sells sea shells <br /> on the sea shore",
                Fr = "Elle vend des coquillages<br /> au bord de la mer",
                De = "Sie verkauft Muscheln <br />an der Küste",
                ImageUrl = "https://images.unsplash.com/photo-1524807516213-f2f94304ab11?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=750&q=80",
                ShowOn = DateTime.Today.AddDays(0)

            });

            Messages.Add(new MessageOfTheDay
            {
                Created = DateTime.Now,
                EnGb = "Peter piper picked a pickled pepper",
                Fr = "Peter Piper a choisi un poivron mariné",
                De = "Peter Piper pflückte einen eingelegten Pfeffer",
                ImageUrl = "https://images.unsplash.com/photo-1526346698789-22fd84314424?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=750&q=80",
                ShowOn = DateTime.Today.AddDays(1)

            });

            Messages.Add(new MessageOfTheDay
            {
                Created = DateTime.Now,
                EnGb = "How much wood does a woodchuck chuck when a woodchuck chucking wood",
                Fr = "Quelle quantité de bois fait un mandrin de marmotte quand un mandrin en bois",
                De = "Wie viel Holz spannt ein Waldmurmeltier, <br /> wenn ein Waldmurmeltier Holz spannt?",
                ImageUrl = "https://images.unsplash.com/photo-1500519082938-cdd6b2f39de6?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=750&q=80",
                ShowOn = DateTime.Today.AddDays(2)

            });
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessageOfTheDay>()
                .HasIndex(p => new { p.ShowOn })
                .IsUnique(true);

        }


    }
}
