using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;
using LinearAlgebra;


namespace ColorProfiles.Colors
{
    public class RGBtoCIEXYZ
    {
        private float _gamma;
        private Matrix3x3 _M;
        public RGBtoCIEXYZ(ColorProfile colorProfile) 
        {
            _gamma = colorProfile.Gamma;

            float x = colorProfile.WhitePoint.WhiteX;
            float y = colorProfile.WhitePoint.WhiteY;
            Vec3 Xw = new()
            {
                X = x / y,
                Y = 1f,
                Z = (1 - x - y) / y,
            };
            Matrix3x3 M = new() { 
                M11 = colorProfile.RedX, M12 = colorProfile.GreenX, M13 = colorProfile.BlueX,
                M21 = colorProfile.RedY, M22 = colorProfile.GreenY, M23 = colorProfile.BlueY,

                M31 = 1 - colorProfile.RedX - colorProfile.RedY, 
                M32 = 1 - colorProfile.GreenX - colorProfile.GreenY, 
                M33 = 1 - colorProfile.BlueX - colorProfile.BlueY,
            };

            if (!Matrix3x3.Invert(M, out Matrix3x3 MInv))
                throw new InvalidOperationException();
            Vec3 S = MInv * Xw;

            _M = new Matrix3x3 {
                M11 = colorProfile.RedX * S.X, M12 = colorProfile.GreenX * S.Y, M13 = colorProfile.BlueX * S.Z,
                M21 = colorProfile.RedY * S.X, M22 = colorProfile.GreenY * S.Y, M23 = colorProfile.BlueY * S.Z,

                M31 = (1 - colorProfile.RedX - colorProfile.RedY) * S.X,
                M32 = (1 - colorProfile.GreenX - colorProfile.GreenY) * S.Y,
                M33 = (1 - colorProfile.BlueX - colorProfile.BlueY) * S.Z,
            };
        }
        public Vector3 XYZ(Color c)
        {
            Vec3 RGB = new() {
                X = (float)Math.Pow(c.R / 255f, _gamma),
                Y = (float)Math.Pow(c.G / 255f, _gamma),
                Z = (float)Math.Pow(c.B / 255f, _gamma),
            };
            return _M * RGB;
        }
    }
}
