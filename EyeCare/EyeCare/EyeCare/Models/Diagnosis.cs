using System;

namespace EyeCare.Models
{
    public class Diagnosis
    {
        public Eye Eye { get; set; }
        public DateTime Date { get; set; }
        public Patient Patient { get; set; }
    }
}