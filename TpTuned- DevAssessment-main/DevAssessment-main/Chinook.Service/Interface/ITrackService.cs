using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Service.Interface
{
    public interface ITrackService
    {
        Task AddToFavorite(long trackId);
    }
}
