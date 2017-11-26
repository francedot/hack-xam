using System;
using System.Collections.Generic;
using System.Linq;
using EyeCare.Backend.Training.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EyeCare.Backend.Controllers
{
    [Route("api/[controller]")]
    public class TrainingsController : Controller
    {
        public TrainingsController(ITrainingsData trainingsData)
        {
            TrainingsData = trainingsData;
        }

        public ITrainingsData TrainingsData { get; set; }

        // GET api/trainings
        [HttpGet]
        public IActionResult Get()
        {
            string content;

            try
            {
                content = JsonConvert.SerializeObject(TrainingsData.GetAll().ToList());
            }
            catch (Exception e)
            {
                //return NotFound();

                return new ContentResult{Content = e.StackTrace };
            }

            return Content(content, "application/json");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            string content;

            try
            {
                content = JsonConvert.SerializeObject(TrainingsData.Get(id));
            }
            catch (Exception)
            {
                return NotFound(id);
            }

            return Content(content, "application/json");
        }

        // POST api/trainings
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return BadRequest();
            }

            Training.Models.Training training;
            try
            {
                training = JsonConvert.DeserializeObject<Training.Models.Training>(value);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            TrainingsData.Add(training);

            return Created(new Uri(Request.GetDisplayUrl()), value);
        }

        // PUT api/trainings/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return BadRequest();
            }

            Training.Models.Training training;
            try
            {
                training = JsonConvert.DeserializeObject<Training.Models.Training>(value);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            TrainingsData.Update(training);

            return Ok();
        }

        // DELETE api/trainings/2
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                TrainingsData.Delete(id);
            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }
    }
}
