using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ColorProfiles.Colors
{
    public class CIEXYZtoRGBPrecalculated
    {
        public CIEXYZtoRGBPrecalculated(ColorProfile colorProfile) { }
        public Vector3 RGB(Vector3 XYZ)
        {
            return new Vector3();
        }

        public static readonly Dictionary<(string, string), Matrix4x4> _precalculatedMatrices = new()
        {

        };
    }
}
