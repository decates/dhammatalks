using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DhammaTalks.Core.Models;
using DhammaTalks.Core.Services;

namespace DhammaTalks.DataAccess.Sql
{
    public class TalksRepository : ITalksRepository
    {
        public IEnumerable<Talk> GetRecentTalks(int? limit, int? skip)
        {
            throw new NotImplementedException();
        }

        public Talk GetTalkById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
