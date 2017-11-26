using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EyeCare.Backend.Models;
using EyeCare.Backend.Services.Abstractions;
using EyeCare.Backend.Training.Services;
using EyeCare.Shared.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EyeCare.Backend.Controllers
{
    [Route("api/[controller]")]
    public class DiagnosesController : Controller
    {
        public DiagnosesController(IDiagnosisData diagnosisData, EyesTrainer eyesTrainer)
        {
            DiagnosisData = diagnosisData;
            EyesTrainer = eyesTrainer;
        }

        public IDiagnosisData DiagnosisData { get; set; }
        public EyesTrainer EyesTrainer { get; }

        // GET api/diagnoses
        [HttpGet]
        public IActionResult Get()
        {
            string content;

            try
            {
                content = JsonConvert.SerializeObject(DiagnosisData.GetAll().ToList());
            }
            catch (Exception e)
            {
                //return NotFound();

                return new ContentResult{Content = e.StackTrace };
            }

            return Content(content, "application/json");
        }

        // GET api/diagnoses/2
        [HttpGet("{id}/eye")]
        public FileStreamResult GetEye(int id)
        {
            try
            {
                var data = DiagnosisData.Get(id).Eye.Data;
                return new FileStreamResult(data.ToStream(), "image/jpeg");
            }
            catch (Exception)
            {
                return new FileStreamResult(Stream.Null, "image/jpeg");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            string content;

            try
            {
                content = JsonConvert.SerializeObject(DiagnosisData.Get(id));
            }
            catch (Exception)
            {
                return NotFound(id);
            }

            return Content(content, "application/json");
        }

        // POST api/diagnoses
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]string value)
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
            var predictions = EyesTrainer.PredictImage(diagnosis.Eye.Data.ToStream());

            string contentResult;
            try
            {
                contentResult = JsonConvert.SerializeObject(predictions);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Content(contentResult, "application/json");
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

            DiagnosisData.Update(diagnosis);

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
