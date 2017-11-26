using System;
using Newtonsoft.Json;

namespace EyeCare.Backend.Models
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Diagnosis
    {
        public int DiagnosisId { get; set; }
        public Eye Eye { get; set; }
        public DateTime Date { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Diagnosis diagnosis)
            {
                return this.Equals(diagnosis);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return DiagnosisId;
        }

        protected bool Equals(Diagnosis diagnosis)
        {
            return DiagnosisId == diagnosis.DiagnosisId;
        }

        public static bool operator ==(Diagnosis diagnosis, Diagnosis diagnosis2)
        {
            return diagnosis != null && diagnosis.Equals(diagnosis2);
        }

        public static bool operator !=(Diagnosis diagnosis, Diagnosis diagnosis2)
        {
            return !(diagnosis == diagnosis2);
        }
    }
}