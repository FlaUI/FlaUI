using System.Collections.Generic;

namespace FlaUI.WebDriver.Models
{
    public class ActionItem
    {
        public string Type { get; set; } = null!;
        public int? Button { get; set; }
        public int? Duration { get; set; }
        public string? Origin { get; set; }
        public int? X { get; set; }
        public int? Y { get; set; }
        public int? DeltaX { get; set; }
        public int? DeltaY { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Pressure { get; set; }
        public int? TangentialPressure { get; set; }
        public int? TiltX { get; set; }
        public int? TiltY { get; set; }
        public int? Twist { get; set; }
        public int? AltitudeAngle { get; set; }
        public int? AzimuthAngle { get; set; }
        public string? Value { get; set; }
    }
}