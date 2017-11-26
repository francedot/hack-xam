using Newtonsoft.Json;

namespace EyeCare.Backend.Models
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Eye
    {
        public int EyeId { get; set; }
        public byte[] Data { get; set; }
        public string DiagnosisId { get; set; }
        public Diagnosis Diagnosis { get; set; }
    }
}
