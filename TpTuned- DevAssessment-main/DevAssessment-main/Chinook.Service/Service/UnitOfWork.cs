using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinook.Models;
using Chinook.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Service.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Artist> Artists { get; }
        public IRepository<Album> Albums { get; }
        public IRepository<Track> Tracks { get; }
    public IRepository<Playlist> PlayList { get; }
        private readonly ChinookContext _context;

        public UnitOfWork(IDbContextFactory<ChinookContext> DbFactory, IRepository<Artist> artists, IRepository<Album> albums, IRepository<Playlist> playList, IRepository<Track> tracks)
        {
            _context = DbFactory.CreateDbContext();
            Artists = artists;
            Albums = albums;
            PlayList = playList;
            Tracks = tracks;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual async Task DisposeAsync(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                await _context.DisposeAsync();
            }
            this.disposed = true;
        }

        public async Task DisposeAsync()
        {
            await DisposeAsync(true);
        }
    }
}
