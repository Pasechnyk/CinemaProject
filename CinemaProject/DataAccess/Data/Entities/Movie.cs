namespace DataAccess.Data.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal TicketPrice { get; set; }
        public string? ImageUrl { get; set; }
        public int GenreId { get; set; }
        public bool IsAvailable { get; set; }
        public string? Description { get; set; }

        // navigation properties
        public Genre? Genre { get; set; }
        public ICollection<Movie>? Movies { get; set;}
    }
}
