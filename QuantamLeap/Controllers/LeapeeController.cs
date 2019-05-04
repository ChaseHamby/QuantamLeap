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
    public class LeapeeController : ControllerBase
    {
        readonly LeapeeRepository _leapeeRepository;

        public LeapeeController()
        {
            _leapeeRepository = new LeapeeRepository();
        }

        [HttpPost("register")]

        public ActionResult<int> AddLeaper(CreateLeapeeRequest createRequest)
        {
            //if (!_validator.Validate(createRequest))
            //{
            //    return BadRequest(new { error = "leapers must have a first name, last name, and target leap" });
            //}

            var newLeaper = _leapeeRepository.AddLeapee(createRequest.FirstName, createRequest.LastName, createRequest.Event);

            return Created($"api/leapee/{newLeaper.Id}", newLeaper);
        }
    }
}