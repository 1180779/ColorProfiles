using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

namespace ColorProfiles.Colors
{
    public class RGBtoCIEXYZ
    {
        private float _gamma;
        private Matrix4x4 _M;
        public RGBtoCIEXYZ(ColorProfile colorProfile) 
        {
            _gamma = colorProfile.Gamma;

            float x = colorProfile.WhitePoint.WhiteX;
            float y = colorProfile.WhitePoint.WhiteY;
            Vector4 Xw = new Vector4
            {
                X = x / y,
                Y = 1f,
                Z = (1 - x - y) / y,
                W = 0
            };
            Matrix4x4 M = new Matrix4x4 { 
                M11 = colorProfile.RedX, M12 = colorProfile.GreenX, M13 = colorProfile.BlueX, M14 = 0,
                M21 = colorProfile.RedY, M22 = colorProfile.GreenY, M23 = colorProfile.BlueY, M24 = 0,

                M31 = 1 - colorProfile.RedX - colorProfile.RedY, 
                M32 = 1 - colorProfile.GreenX - colorProfile.GreenY, 
                M33 = 1 - colorProfile.BlueX - colorProfile.BlueY,
                M34 = 0,

                M41 = 0, M42 = 0, M43 = 0, M44 = 1
            };

            if (!Matrix4x4.Invert(M, out Matrix4x4 MInv))
                throw new InvalidOperationException();
            Vector4 S = Vector4.Transform(Xw, MInv);

            _M = new Matrix4x4 {
                M11 = colorProfile.RedX * S.X, M12 = colorProfile.GreenX * S.Y, M13 = colorProfile.BlueX * S.Z, M14 = 0,
                M21 = colorProfile.RedY * S.X, M22 = colorProfile.GreenY * S.Y, M23 = colorProfile.BlueY * S.Z, M24 = 0,

                M31 = (1 - colorProfile.RedX - colorProfile.RedY) * S.X,
                M32 = (1 - colorProfile.GreenX - colorProfile.GreenY) * S.Y,
                M33 = (1 - colorProfile.BlueX - colorProfile.BlueY) * S.Z,
                M34 = 0,

                M41 = 0, M42 = 0, M43 = 0, M44 = 1
            };
        }
        public Vector3 XYZ(Color c)
        {
            Vector4 RGB = new Vector4 {
                X = (float)Math.Pow(c.R / 255f, _gamma),
                Y = (float)Math.Pow(c.G / 255f, _gamma),
                Z = (float)Math.Pow(c.B / 255f, _gamma),
                W = 0
            };
            Vector4 res = Vector4.Transform(RGB, _M);
            return new Vector3 { X = res.X, Y = res.Y, Z = res.Z };
        }
    }
}
