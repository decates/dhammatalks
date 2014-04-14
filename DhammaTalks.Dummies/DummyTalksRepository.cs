using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DhammaTalks.Core.Models;
using DhammaTalks.Core.Services;

namespace DhammaTalks.Dummies
{
    public class DummyTalksRepository : ITalksRepository
    {
        public IEnumerable<Talk> GetRecentTalks(int? limit, int? skip)
        {
            return DummyData.Talks.OrderByDescending(t => t.DateRecorded).Skip(skip ?? 0).Take(limit ?? int.MaxValue);
        }

        public Talk GetTalkById(string id)
        {
            return DummyData.Talks.FirstOrDefault(t => t.Id == id);
        }
    }
}
