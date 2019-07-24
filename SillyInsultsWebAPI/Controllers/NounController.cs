using Microsoft.AspNet.Identity;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNoun.WebAPI.Controllers
{
    [Authorize]
    public class NounController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            NounService nounService = CreateNounService();
            var nouns = nounService.GetNouns();
            return Ok(nouns);
        }

        public IHttpActionResult Get(int id)
        {
            NounService nounService = CreateNounService();
            var noun = nounService.GetNounByID(id);
            return Ok(noun);
        }

        public IHttpActionResult Post(NounCreate noun)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNounService();

            if (!service.CreateNoun(noun))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(NounEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNounService();

            if (!service.UpdateNoun(note))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateNounService();

            if (!service.DeleteNoun(id))
                return InternalServerError();

            return Ok();
        }

        private NounService CreateNounService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new NounService();
            return noteService;
        }
    }
}