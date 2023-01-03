using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db
{
    public class DoctorWhoCoreDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Companion> Companions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<EpisodeCompanion> EpisodeCompanions { get; set; }
        public DbSet<EpisodeEnemy> EpisodeEnemies { get; set; }
        public DbSet<ViewEpisodes> ViewEpisodes { get; set; }

        public string CallFnCompanions(int Id) => throw new NotSupportedException();
        public string CallFnEnemies(int Id) => throw new NotSupportedException();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=USER-PC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Initial Catalog=DoctorWhoCore");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(a => a.AuthorId);
            modelBuilder.Entity<Author>().Property(a => a.AuthorName).IsRequired();
            modelBuilder.Entity<Author>().Property(a => a.AuthorName).HasColumnType("varchar(400)");
            var authorsList = new List<Author>{
                new Author {AuthorId=1, AuthorName="Gosho Aoyama" },
                new Author {AuthorId=2,AuthorName="Rudyard Kipling" },
                new Author {AuthorId=3,AuthorName="Kozu Kozuha" },
                new Author {AuthorId=4,AuthorName="Guy Ritchie"  },
                new Author {AuthorId=5,AuthorName="Akira Kurosawa" }
            };
            modelBuilder.Entity<Author>().HasData(authorsList);


            modelBuilder.Entity<Companion>().HasKey(c => c.CompanionId);
            modelBuilder.Entity<Companion>().Property(c => c.CompanionName).IsRequired();
            modelBuilder.Entity<Companion>().Property(c => c.CompanionName).HasColumnType("varchar(400)");
            var companionsList = new List<Companion>{
                new Companion {CompanionId=1, CompanionName="Polly", WhoPlayed="Anneke Wills" },
                new Companion {CompanionId=2,CompanionName="Zoe Heriot", WhoPlayed="Wendy Padbury"  },
                new Companion {CompanionId=3,CompanionName="Nyssa", WhoPlayed="Sarah Sutton"  },
                new Companion {CompanionId=4,CompanionName="Mickey Smith",WhoPlayed="Noel Clarke"   },
                new Companion {CompanionId=5,CompanionName="Nardole",WhoPlayed="Matt Lucas"  }
            };
            modelBuilder.Entity<Companion>().HasData(companionsList);


            modelBuilder.Entity<Doctor>().HasKey(d => d.DoctorId);
            modelBuilder.Entity<Doctor>().Property(d => d.DoctorName).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.DoctorName).HasColumnType("varchar(400)");
            modelBuilder.Entity<Doctor>().Property(d => d.BirthDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Doctor>().Property(d => d.FirstEpisodeDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Doctor>().Property(d => d.LastEpisodeDate).HasDefaultValueSql("NULL");
            var doctorsList = new List<Doctor>
            {
                new Doctor{DoctorId=1, DoctorNumber=1, DoctorName="William" },
                new Doctor{DoctorId=2, DoctorNumber=2, DoctorName="Patrick" },
                new Doctor{DoctorId=3, DoctorNumber=3, DoctorName="Jon" },
                new Doctor{DoctorId=4, DoctorNumber=4, DoctorName="Tom" },
                new Doctor{DoctorId=5, DoctorNumber=5, DoctorName="Peter" }
            };
            modelBuilder.Entity<Doctor>().HasData(doctorsList);


            modelBuilder.Entity<Enemy>().HasKey(e => e.EnemyId);
            modelBuilder.Entity<Enemy>().Property(e => e.EnemyName).IsRequired();
            modelBuilder.Entity<Enemy>().Property(e => e.EnemyName).HasColumnType("varchar(400)");
            modelBuilder.Entity<Enemy>().Property(e => e.Description).HasDefaultValueSql("NULL");
            var enemiesList = new List<Enemy>
            {
                new Enemy{EnemyId=1, EnemyName="Hisoka", Description="Hunter"},
                new Enemy{EnemyId=2, EnemyName="Queen Grimhilde", Description="Snow White and the Seven Dwarfs"},
                new Enemy{EnemyId=3, EnemyName="Lady Tremaine", Description="Cinderella"},
                new Enemy{EnemyId=4, EnemyName="Scar", Description="The lion is the king of the jungle"},
                new Enemy{EnemyId=5, EnemyName="Ursula", Description="the little Mermaid"}
            };
            modelBuilder.Entity<Enemy>().HasData(enemiesList);


            modelBuilder.Entity<Episode>().HasKey(e => e.EpisodeId);
            modelBuilder.Entity<Episode>().Property(e => e.SeriesNumber).HasDefaultValueSql("0");
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeNumber).HasDefaultValueSql("0");
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeType).IsRequired();
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeType).HasColumnType("varchar(400)");
            modelBuilder.Entity<Episode>().Property(e => e.Title).HasColumnType("varchar(400)");
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Episode>().Property(e => e.Notes).HasColumnType("varchar(400)");
            modelBuilder.Entity<Episode>().Property(e => e.Notes).IsRequired(false);
            modelBuilder.Entity<Episode>().Property(e => e.Notes).HasDefaultValueSql("NULL");
            var episodesList = new List<Episode>
            {
                new Episode{EpisodeId=1,SeriesNumber=1, EpisodeNumber=1, EpisodeType="Classic", Title="The Heirs of the Dragon", EpisodeDate=new DateTime(2002,10,29), AuthorId=4,DoctorId=2 },
                new Episode{EpisodeId=2,SeriesNumber=1, EpisodeNumber=2, EpisodeType="Classic", Title="The Rogue Prince", EpisodeDate=new DateTime(2002,10,30), AuthorId=4,DoctorId=2 },
                new Episode{EpisodeId=3,SeriesNumber=1, EpisodeNumber=3, EpisodeType="Classic", Title="Second of His Name", EpisodeDate=new DateTime(2002,11,1), AuthorId=5,DoctorId=1 },
                new Episode{EpisodeId=4,SeriesNumber=2, EpisodeNumber=1, EpisodeType="Classic", Title="King of the Narrow Sea", EpisodeDate=new DateTime(2002,11,2), AuthorId=3,DoctorId=3 },
                new Episode{EpisodeId=5,SeriesNumber=2, EpisodeNumber=2, EpisodeType="Classic", Title="We Light the Way", EpisodeDate=new DateTime(2002,11,3), AuthorId=1,DoctorId=4 }
            };
            modelBuilder.Entity<Episode>().HasData(episodesList);

            var episodeCompanionsList = new List<EpisodeCompanion>
            {
            new EpisodeCompanion{ EpisodeCompanionId=1, EpisodeId =1, CompanionId=5 },
            new EpisodeCompanion{ EpisodeCompanionId=2,EpisodeId=2, CompanionId=4 },
            new EpisodeCompanion{ EpisodeCompanionId=3,EpisodeId=3, CompanionId=1 },
            new EpisodeCompanion{ EpisodeCompanionId=4,EpisodeId=3, CompanionId=2 },
            new EpisodeCompanion{ EpisodeCompanionId=5,EpisodeId=4, CompanionId=3 },
            new EpisodeCompanion{ EpisodeCompanionId=6,EpisodeId=5, CompanionId=1 },
            new EpisodeCompanion{ EpisodeCompanionId=7,EpisodeId=5, CompanionId=3 }
            };
            modelBuilder.Entity<EpisodeCompanion>().HasData(episodeCompanionsList);


            var episodeEnemiesList = new List<EpisodeEnemy>
            {
            new EpisodeEnemy{ EpisodeEnemyId=1, EpisodeId =1, EnemyId=2 },
            new EpisodeEnemy{ EpisodeEnemyId=2, EpisodeId=1, EnemyId=3 },
            new EpisodeEnemy{ EpisodeEnemyId=3, EpisodeId=2, EnemyId=2 },
            new EpisodeEnemy{ EpisodeEnemyId=4, EpisodeId=2, EnemyId=4 },
            new EpisodeEnemy{ EpisodeEnemyId=5, EpisodeId=3, EnemyId=1 },
            new EpisodeEnemy{ EpisodeEnemyId=6, EpisodeId=4, EnemyId=3 },
            new EpisodeEnemy{ EpisodeEnemyId=7, EpisodeId=5, EnemyId=3 }
            };
            modelBuilder.Entity<EpisodeEnemy>().HasData(episodeEnemiesList);


            modelBuilder.Entity<ViewEpisodes>().HasNoKey().ToView("ViewEpisodes");

            modelBuilder.HasDbFunction(typeof(DoctorWhoCoreDbContext).GetMethod(nameof(CallFnCompanions), new[] { typeof(int) }))
              .HasName("fnCompanions");

            modelBuilder.HasDbFunction(typeof(DoctorWhoCoreDbContext).GetMethod(nameof(CallFnEnemies), new[] { typeof(int) }))
             .HasName("fnEnemies");
        }
    }
}
