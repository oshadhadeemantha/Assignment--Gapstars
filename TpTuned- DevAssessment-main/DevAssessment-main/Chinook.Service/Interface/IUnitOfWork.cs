using Chinook.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Service.Interface
{
    public interface IUnitOfWork
    {
        IRepository<Artist> Artists { get; }
        IRepository<Album> Albums { get; }
        IRepository<Playlist> PlayList { get; }
        IRepository<Track> Tracks { get; }
        Task<int> SaveChangesAsync();
        Task DisposeAsync();
    }
}
