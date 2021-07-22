using System;
namespace MovieTableDLL.Models
{
    public class MovieModels
    {
        public int ID { get; set; }
        public string MovieName { get; set; }

        public DateTime? MovieReleaseDate { get; set; }
        public DateTime? MovieAddedDdate { get; set; }
    }
}