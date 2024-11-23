using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorProfiles.Colors
{
    public struct WhitePoint : ICloneable
    {
        public static readonly string Custom = "Custom";
        public readonly string Name = Custom;
        public float WhiteX { get; set; }
        public float WhiteY { get; set; }
        public int TemperatureK { get; set; } = 0;
        public WhitePoint(string name) { Name = name; }
        public WhitePoint() { }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public override string ToString()
        {
            return Name;
        }

        // https://en.wikipedia.org/wiki/Standard_illuminant#White_points_of_standard_illuminants
        public static class Illuminats
        {
            public static WhitePoint A => new WhitePoint("A")
            {
                WhiteX = 0.44758f,
                WhiteY = 0.40745f,
                TemperatureK = 2856,
            };
            public static WhitePoint B => new WhitePoint("B")
            {
                WhiteX = 0.34842f,
                WhiteY = 0.35161f,
                TemperatureK = 4874,
            };
            public static WhitePoint C => new WhitePoint("C")
            {
                WhiteX = 0.31006f,
                WhiteY = 0.31616f,
                TemperatureK = 6774,
            };
            public static WhitePoint D50 => new WhitePoint("D50")
            {
                WhiteX = 0.34567f,
                WhiteY = 0.35850f,
                TemperatureK = 5003,
            };
            public static WhitePoint D55 => new WhitePoint("D55")
            {
                WhiteX = 0.33242f,
                WhiteY = 0.34743f,
                TemperatureK = 5503,
            };
            public static WhitePoint D65 => new WhitePoint("D65")
            {
                WhiteX = 0.31272f,
                WhiteY = 0.32903f,
                TemperatureK = 6504,
            };
            public static WhitePoint D75 => new WhitePoint("D75")
            {
                WhiteX = 0.29902f,
                WhiteY = 0.31485f,
                TemperatureK = 7504,
            };
            public static WhitePoint D93 => new WhitePoint("D93")
            {
                WhiteX = 0.28315f,
                WhiteY = 0.29711f,
                TemperatureK = 9305,
            };
            public static WhitePoint E => new WhitePoint("E")
            {
                WhiteX = 0.33333f,
                WhiteY = 0.33333f,
                TemperatureK = 5454,
            };
            public static WhitePoint F2 => new WhitePoint("F2")
            {
                WhiteX = 0.37208f,
                WhiteY = 0.37529f,
                TemperatureK = 4230,
            };
            public static WhitePoint F7 => new WhitePoint("F7")
            {
                WhiteX = 0.31292f,
                WhiteY = 0.32933f,
                TemperatureK = 6500,
            };
            public static WhitePoint F11 => new WhitePoint("F11")
            {
                WhiteX = 0.38052f,
                WhiteY = 0.37713f,
                TemperatureK = 4000,
            };
        }
    }
}
