using System.Collections.Generic;
using Newtonsoft.Json;

namespace EyeCare.Backend.Models
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Diagnosis> Diagnoses { get; set; }
    }
}