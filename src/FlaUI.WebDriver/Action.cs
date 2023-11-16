using FlaUI.WebDriver.Models;
using System;

namespace FlaUI.WebDriver
{
    public class Action
    {
        public Action(ActionSequence actionSequence, ActionItem actionItem)
        {
            Type = actionSequence.Type;
            SubType = actionItem.Type;
            Button = actionItem.Button;
            Duration = actionItem.Duration;
            Origin = actionItem.Origin;
            X = actionItem.X;
            Y = actionItem.Y;
            Width = actionItem.Width;
            Height = actionItem.Height;
            Pressure = actionItem.Pressure;
            TangentialPressure = actionItem.TangentialPressure;
            TiltX = actionItem.TiltX;
            TiltY = actionItem.TiltY;
            Twist = actionItem.Twist;
            AltitudeAngle = actionItem.AltitudeAngle;
            AzimuthAngle = actionItem.AzimuthAngle;
            Value = actionItem.Value;
        }

        public Action(Action action)
        {
            Type = action.Type;
            SubType = action.SubType;
            Button = action.Button;
            Duration = action.Duration;
            Origin = action.Origin;
            X = action.X;
            Y = action.Y;
            Width = action.Width;
            Height = action.Height;
            Pressure = action.Pressure;
            TangentialPressure = action.TangentialPressure;
            TiltX = action.TiltX;
            TiltY = action.TiltY;
            Twist = action.Twist;
            AltitudeAngle = action.AltitudeAngle;
            AzimuthAngle = action.AzimuthAngle;
            Value = action.Value;
        }

        public string Type { get; set; }
        public string SubType { get; set; }
        public int? Button { get; set; }
        public int? Duration { get; set; }
        public string? Origin { get; set; }
        public int? X { get; set; }
        public int? Y { get; set; }
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

        public Action Clone()
        {
            return new Action(this);
        }
    }
}