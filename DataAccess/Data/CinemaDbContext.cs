using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace DataAccess.Data
{
    public class CinemaDbContext : IdentityDbContext<User>
    {
        public CinemaDbContext() { }
        public CinemaDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DataAccess;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(new[]
            {
                new Genre() { Id = 1, Name = "Action" },
                new Genre() { Id = 2, Name = "Adventure" },
                new Genre() { Id = 3, Name = "Comedy" },
                new Genre() { Id = 4, Name = "Detective" },
                new Genre() { Id = 5, Name = "Drama" },
                new Genre() { Id = 6, Name = "Documentary" },
                new Genre() { Id = 7, Name = "Horror" },
                new Genre() { Id = 8, Name = "Thriller" }
            });

            modelBuilder.Entity<Movie>().HasData(new[]
            {
                new Movie() { Id = 1, Name = "Oppenheimer", GenreId = 6, TicketPrice = 120, ImageUrl = "https://m.media-amazon.com/images/I/71lqDylcvGL._AC_SL1500_.jpg", Description = "The story of American scientist, J. Robert Oppenheimer, and his role in the development of the atomic bomb. In 1926, 22-year-old doctoral student J. Robert Oppenheimer grapples with anxiety and homesickness while studying under experimental physicist Patrick Blackett at the Cavendish Laboratory in Cambridge. Upset with the demanding Blackett, Oppenheimer leaves him a poisoned apple but later retrieves it. Visiting scientist Niels Bohr recommends that Oppenheimer instead study theoretical physics at Göttingen." },
                new Movie() { Id = 2, Name = "Barbie", GenreId = 2, TicketPrice = 120, ImageUrl = "https://deadline.com/wp-content/uploads/2023/04/barbie-BARBIE_VERT_TSR_W_TALENT_2764x4096_DOM_rgb.jpg?w=1280", Description = "Barbie suffers a crisis that leads her to question her world and her existence. Stereotypical Barbie (Barbie) and fellow dolls reside in Barbieland, a matriarchal society populated by different versions of Barbies, Kens, and a group of discontinued models, who are treated like outcasts due to their unconventional traits. While the Kens spend their days playing at the beach, considering it their profession, the Barbies hold prestigious jobs such as doctor, lawyer, and politician. Beach Ken (Ken) is only happy when he is with Barbie, and seeks a closer relationship, but she rebuffs him in favour of other activities and female friendships." },
                new Movie() { Id = 3, Name = "The Nun II", GenreId= 7, TicketPrice = 120, ImageUrl = "https://www.joblo.com/wp-content/uploads/2023/04/the-nun-2-review.jpg", Description = "The sequel to the worldwide smash hit follows Sister Irene as she once again comes face-to-face with Valak, the demon nun. In 1956, Father Noiret and young Jacques perform their daily chores in their church in Tarascon, France. While investigating a disturbance, Noiret is raised into the air, set on fire, and burned to death before a terrified Jacques who then flees."},
                new Movie() { Id = 4, Name = "Inside Out II", GenreId= 3, TicketPrice = 120, ImageUrl = "https://lumiere-a.akamaihd.net/v1/images/p_insideout2_798_0e9b544c.jpeg", Description = "Inside Out 2 returns to the mind of newly minted teenager Riley just as headquarters is undergoing a sudden demolition to make room for something entirely unexpected: new Emotions! Joy, Sadness, Anger, Fear and Disgust, who've long been running a successful operation by all accounts, aren't sure how to feel when Anxiety shows up. And it looks like she's not alone."},
                new Movie() { Id = 5, Name = "Five Nights at Freddy's", GenreId= 8, TicketPrice = 150, ImageUrl = "https://pbs.twimg.com/media/F9F2WXhWEAEnQSb?format=jpg&name=4096x4096", Description = "At Freddy Fazbear's Pizza, an abandoned pizzeria and family entertainment center that was once successful, a night security guard attempts to flee from the place but is captured and strapped to a torture device, which kills him.Sometime later, mall security guard Mike Schmidt is fired for assaulting a negligent father whom he mistook for a kidnapper. Mike's career counselor, Steve Raglan, offers him a job as a night guard at Freddy's. Though initially reluctant, Mike accepts after social services threaten to take custody of his younger sister Abby and pass her to their estranged aunt Jane, who desires the custody's monthly payments."},
                new Movie() { Id = 6, Name = "Napoleon", GenreId = 6, TicketPrice = 150, ImageUrl = "https://i.ebayimg.com/images/g/trMAAOSw~ERlKAIH/s-l1200.jpg", Description = "In 1793, amid the French Revolution, young army officer Napoleon Bonaparte watches Queen Marie Antoinette being beheaded by the guillotine. Later that year, Revolutionary leader Paul Barras has Napoleon manage the Siege of Toulon; he successfully storms the city and repels the British ships with artillery. After Maximilien Robespierre is deposed and executed at the end of the Reign of Terror, French leaders, including Napoleon, attempt to restore stability. Again employing artillery, Napoleon suppresses the royalist insurrection on 13 Vendémiaire in 1795." },
                new Movie() { Id = 7, Name = "The Ballad of Songbirds & Snakes", GenreId = 5, TicketPrice = 150, ImageUrl = "https://images.justwatch.com/poster/307659151/s718/the-hunger-games-the-ballad-of-songbirds-and-snakes.jpg", Description = "The Capitol of Panem has crushed a prolonged uprising by its thirteen Districts, defeating twelve of the districts and destroying District 13. The once wealthy and powerful Snow family is now struggling, with eighteen-year-old Coriolanus Snow, his cousin Tigris, and their grandmother (“The Grandma’am”) being the only family members to survive the war. Coriolanus’ father, a Capitol general, left no inheritance for the family due to their wealth having come from the munitions industry in the now-wiped out District 13. The Snow family prizes image and power above all, barely making ends meet while pretending to be as wealthy as their peers, and it is clear that the family’s future success and survival depend on Coriolanus rising to prominence in adulthood." },
                new Movie() { Id = 8, Name = "Killers of the Flower Moon", GenreId = 6, TicketPrice = 120, ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bbcad0f2727be3646b9fee1/8b845be0-f31e-4ffc-a43b-ab96c189efde/F96BFCDE-37B8-442B-84B1-A0919CA0D9F7.jpeg", Description = "Osage Nation elders bury a ceremonial pipe, mourning their descendants' assimilation into white American society. Wandering through their Oklahoma reservation, which features the annual \"flower moon\" phenomenon of fields of blooms, several Osage find oil gushing from the ground. The tribe becomes wealthy, as it retains mineral rights and members share in oil-lease revenues, though law requires white court-appointed legal guardians to manage the money of full and half-blood members, assuming them incompetent." },
                new Movie() { Id = 9, Name = "Blue Beetle", GenreId = 8, TicketPrice = 120, ImageUrl = "https://www.kinofilms.ua/images/photos/h1000/1003281.jpg", Description = "In the remote tundra of Antarctica, members of Kord Industries, led by the company's co-founder and CEO Victoria Kord, locate an ancient alien artifact known as the Scarab.Meanwhile, Jaime Reyes returns to his hometown of Palmera City after graduating from Gotham Law University, only to learn that his family is facing eviction from their home due to financial difficulties. Jaime's sister Milagro manages to get him a job at Victoria's mansion. However, both are fired after Jaime stops a confrontation between Victoria and her niece Jenny. Jenny later tells Jaime to meet her at Kord Tower the next day to discuss a job opportunity." }
            });

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
