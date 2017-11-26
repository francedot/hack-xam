using System;
using EyeCare.Backend.Models;
using EyeCare.Backend.Training.Models;
using EyeCare.Backend.Training.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EyeCare.Backend.Controllers
{
    [Route("api/[controller]")]
    public class PredictionsController : Controller
    {
        public PredictionsController(EyesTrainer eyesTrainer)
        {
            EyesTrainer = eyesTrainer;
        }

        public EyesTrainer EyesTrainer { get; }

        // POST api/predictions
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return BadRequest();
            }

            Prediction prediction;
            try
            {
                prediction = JsonConvert.DeserializeObject<Prediction>(value);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Created(new Uri(Request.GetDisplayUrl()), value);
        }

        // PUT api/diagnoses/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return BadRequest();
            }

            Diagnosis diagnosis;
            try
            {
                diagnosis = JsonConvert.DeserializeObject<Diagnosis>(value);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            DiagnosisData.Add(diagnosis);

            return Ok();
        }

        // DELETE api/diagnoses/2
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                DiagnosisData.Delete(id);
            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }
    }
}
