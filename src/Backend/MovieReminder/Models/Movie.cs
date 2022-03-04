using System;
using System.Collections.Generic;

namespace MovieReminder.Models
{
    public partial class Movie
    {
        public Guid Id { get; set; }
        public string MovieName { get; set; } = null!;
        public DateTime? ReleaseDate { get; set; }
        public string? CreatedUsername { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
