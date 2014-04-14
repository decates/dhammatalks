using System.Collections.Generic;
using DhammaTalks.Core.Models;

namespace DhammaTalks.Core.Services
{
    public interface ITalksRepository
    {
        IEnumerable<Talk> GetRecentTalks(int? limit, int? skip);

        Talk GetTalkById(string id);
    }
}