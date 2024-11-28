using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using LinearAlgebra;

namespace ColorProfiles.Colors
{
    public class ChromaticAdapter
    {
        private static readonly Matrix3x3 _Mbfd = new() { 
            M11 = 0.8951f, M12 = 0.2664f, M13 = -0.1614f,
            M21 = -0.7502f, M22 = 1.7135f, M23 = 0.0367f,
            M31 = 0.0389f, M32 = -0.0685f, M33 = 1.0296f,
        };

        private static readonly Matrix3x3 _MbdfInv = new() {
            M11 = 0.9870f, M12 = -0.1471f, M13 = 0.1600f, 
            M21 = 0.4323f, M22 = 0.5184f, M23 = 0.0493f, 
            M31 = -0.0085f, M32 = 0.0400f, M33 = 0.9685f, 
        };

        private Matrix3x3 _M;
        public ChromaticAdapter(WhitePoint from, WhitePoint to) 
        {
            Vec3 Xdw = new()
            {
                X = to.WhiteX / to.WhiteY,
                Y = 1,
                Z = (1 - to.WhiteX - to.WhiteY) / to.WhiteY
            };
            Vec3 Xsw = new()
            {
                X = from.WhiteX / from.WhiteY,
                Y = 1,
                Z = (1 - from.WhiteX - from.WhiteY) / from.WhiteY
            };

            Vec3 RGBdw = _Mbfd * Xdw;
            Vec3 RGBsw = _Mbfd * Xsw;

            Matrix3x3 M = new() {
                M11 = RGBdw.X / RGBsw.X,
                M22 = RGBdw.Y / RGBsw.Y,
                M33 = RGBdw.Z / RGBsw.Z,
            };
            _M = _MbdfInv * M * _Mbfd;
        }

        public Vector3 Adapt(Vector3 XYZ) => _M * XYZ;
    }
}
