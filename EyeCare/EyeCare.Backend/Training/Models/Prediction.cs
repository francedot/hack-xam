namespace EyeCare.Backend.Training.Models
{
    public class Prediction
    {
        public Training.Tag Tag { get; set; }
        public double Probability { get; set; }
    }
}
