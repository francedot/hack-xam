using System;
using EyeCare.Backend.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EyeCare.Backend.Controllers
{
    [Route("api/[controller]")]
    public class PatientsController : Controller
    {
        public PatientsController(IPatientsData patientsData)
        {
            PatientsData = patientsData;
        }

        public IPatientsData PatientsData { get; set; }

        // GET api/patients
        [HttpGet]
        public IActionResult Get()
        {
            string content;

            try
            {
                content = JsonConvert.SerializeObject(PatientsData.GetAll());
            }
            catch (Exception)
            {
                return NotFound();
            }

            return Content(content, "application/json");
        }

        // GET api/patients/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            string content;

            try
            {
                content = JsonConvert.SerializeObject(PatientsData.Get(id));
            }
            catch (Exception)
            {
                return NotFound(id);
            }

            return Content(content, "application/json");
        }
        
    }
}