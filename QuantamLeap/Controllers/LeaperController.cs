using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuantamLeap.Data;
using QuantamLeap.Models;

namespace QuantamLeap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaperController : ControllerBase
    {
        readonly LeaperRepository _leaperRepository;
        
        public LeaperController()
        {
            _leaperRepository = new LeaperRepository();
        }

        [HttpPost("register")]

        public ActionResult<int> AddLeaper(CreateLeaperRequest createRequest)
        {
            //if (!_validator.Validate(createRequest))
            //{
            //    return BadRequest(new { error = "leapers must have a first name, last name, and target leap" });
            //}

            var newLeaper = _leaperRepository.AddLeaper(createRequest.FirstName, createRequest.LastName, createRequest.TargetLeap);

            return Created($"api/leaper/{newLeaper.Id}", newLeaper);
        }

    }
}