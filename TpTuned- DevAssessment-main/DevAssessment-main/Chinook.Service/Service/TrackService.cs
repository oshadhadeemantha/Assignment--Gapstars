using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinook.Service.Interface;

namespace Chinook.Service.Service
{
    public class TrackService : ITrackService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrackService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddToFavorite(long trackId)
        {
            var track = await _unitOfWork.Tracks.GetByIDAsync(trackId);
            var selectedPlayList = await _unitOfWork.PlayList.GetAsync(p => p.Name.Equals("Favorites"));
            var playList = selectedPlayList.First();

            playList.AddTracks(track); 
            _unitOfWork.PlayList.Update(playList);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
