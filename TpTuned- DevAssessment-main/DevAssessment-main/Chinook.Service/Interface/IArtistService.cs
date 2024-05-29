using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinook.Models;

namespace Chinook.Service.Interface
{
    public interface IArtistService
    {
        List<Artist> GetArtists();

        Task<List<Artist>> GetArtistsByName(string artistName);
    }
}
