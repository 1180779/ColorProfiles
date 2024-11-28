using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ColorProfiles.Colors
{
    public class ColorProfile : ICloneable
    {
        public static readonly string Custom = "Custom";
        public string ProfileName { get; private set; } = Custom;
        public ColorProfile() { }
        public ColorProfile(string profileName) { ProfileName = profileName; }
        public override string ToString() { return ProfileName; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public float Gamma { get; set; }
        public float RedX { get; set; }
        public float RedY { get; set; }
        public float GreenX { get; set; }
        public float GreenY { get; set; }
        public float BlueX { get; set; }
        public float BlueY { get; set; }
        public WhitePoint WhitePoint;
        public static class Predefined
        {
            public static ColorProfile sRGB => new ColorProfile("sRGB") {
                Gamma = 2.2f,
                RedX = 0.64f,
                RedY = 0.33f,
                GreenX = 0.3f,
                GreenY = 0.6f,
                BlueX = 0.15f,
                BlueY = 0.32902f,
                WhitePoint = WhitePoint.Illuminats.D65,
            };
            public static ColorProfile AdobeRGB => new ColorProfile("AdobeRGB") { 
                Gamma = 2.2f,
                RedX = 0.64f,
                RedY = 0.33f,
                GreenX = 0.21f,
                GreenY = 0.71f,
                BlueX = 0.15f,
                BlueY = 0.32902f,
                WhitePoint = WhitePoint.Illuminats.D65
            };
            public static ColorProfile WideGamut => new ColorProfile("WideGamut") {
                Gamma = 1.2f,
                RedX = 0.7347f,
                RedY = 0.2653f,
                GreenX = 0.1152f,
                GreenY = 0.8264f,
                BlueX = 0.1566f,
                BlueY = 0.3585f,
                WhitePoint = WhitePoint.Illuminats.D50
            };
        }
    }
}
