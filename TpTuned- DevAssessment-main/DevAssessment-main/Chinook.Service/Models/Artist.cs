using System;
using System.Collections.Generic;

namespace Chinook.Models
{
    public partial class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
        }

        public long ArtistId { get; set; }
        public string? Name { get; set; }

        public virtual IEnumerable<Album> Albums { get; set; }
    }
}
