using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ColorProfiles.Colors
{
    public class ChromaticAdapter
    {
        private static readonly Matrix4x4 _Mbfd = new Matrix4x4() { 
            M11 = 0.8951f, M12 = 0.2664f, M13 = -0.1614f, M14 = 0,
            M21 = -0.7502f, M22 = 1.7135f, M23 = 0.0367f, M24 = 0,
            M31 = 0.0389f, M32 = -0.0685f, M33 = 1.0296f, M34 = 0,
            M41 = 0, M42 = 0, M43 = 0, M44 = 1
        };

        private static readonly Matrix4x4 _MbdfInv = new Matrix4x4() {
            M11 = 0.9870f, M12 = -0.1471f, M13 = 0.1600f, M14 = 0,
            M21 = 0.4323f, M22 = 0.5184f, M23 = 0.0493f, M24 = 0,
            M31 = -0.0085f, M32 = 0.0400f, M33 = 0.9685f, M34 = 0,
            M41 = 0, M42 = 0, M43 = 0, M44 = 1
        };

        private Matrix4x4 _M;
        public ChromaticAdapter(WhitePoint from, WhitePoint to) 
        {
            Vector4 Xdw = new Vector4
            {
                X = to.WhiteX / to.WhiteY,
                Y = 1,
                Z = (1 - to.WhiteX - to.WhiteY) / to.WhiteY
            };
            Vector4 Xsw = new Vector4
            {
                X = from.WhiteX / from.WhiteY,
                Y = 1,
                Z = (1 - from.WhiteX - from.WhiteY) / from.WhiteY
            };

            Vector4 RGBdw = Vector4.Transform(Xdw, _Mbfd);
            Vector4 RGBsw = Vector4.Transform(Xsw, _Mbfd);

            Matrix4x4 M = new Matrix4x4 {
                M11 = RGBdw.X / RGBsw.X,
                M22 = RGBdw.Y / RGBsw.Y,
                M33 = RGBdw.Z / RGBsw.Z,
                M44 = 1,
            };
            _M = Matrix4x4.Multiply(Matrix4x4.Multiply(_MbdfInv, M), _Mbfd);
        }

        public Vector3 Adapt(Vector3 XYZ)
        {
            Vector4 temp = new Vector4(XYZ.X, XYZ.Y, XYZ.Z, 0);
            Vector4 res = Vector4.Transform(temp, _M);
            return new Vector3(res.X, res.Y, res.Z);
        }

    }
}
