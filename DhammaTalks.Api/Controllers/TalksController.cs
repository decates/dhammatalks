using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DhammaTalks.Core.Models;
using DhammaTalks.Core.Services;
using DhammaTalks.Dummies;
using WebApi.OutputCache.V2;

namespace DhammaTalks.Api.Controllers
{
    public class TalksController : ApiController 
    {
        private readonly ITalksRepository _talksRepository;

        public TalksController()
        {
            _talksRepository = new DummyTalksRepository();
        }

        //public TalksController(ITalksRepository talksRepository)
        //{
        //    _talksRepository = talksRepository;
        //}

        [HttpGet()]
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        [Route("talks/recent/{limit:int?}/{skip:int?}")]
        public List<Talk> Recent(int? limit = null, int? skip = null)
        {
            return _talksRepository.GetRecentTalks(limit, skip).ToList();
        }

        [HttpGet()]
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        [Route("talks/{id}")]
        public Talk ById(string id)
        {
            return _talksRepository.GetTalkById(id);
        }
    }
}