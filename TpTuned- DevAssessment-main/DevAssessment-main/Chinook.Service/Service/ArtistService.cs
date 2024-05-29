using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinook.Models;
using Chinook.Service.Interface;

namespace Chinook.Service.Service
{
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArtistService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Artist> GetArtists()
        {
            var Artists =  (IEnumerable<Artist>)_unitOfWork.Artists.GetAll();
            return Artists.ToList();
        }

        public async Task<List<Artist>> GetArtistsByName(string artistName)
        {

            try
            {
                var Artists = await _unitOfWork.Artists.GetAsync(
                    a => a.Name != null && a.Name.Contains(artistName));
                return Artists.ToList();
            }
            catch (Exception e)
            {
                throw;
            }   
        }
    }
}
