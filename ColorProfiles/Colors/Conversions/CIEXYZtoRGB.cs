using LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ColorProfiles.Colors
{
    public class CIEXYZtoRGB
    {
        private float _1overGamma;
        private Matrix3x3 _M;
        public CIEXYZtoRGB(ColorProfile colorProfile) 
        {
            _1overGamma = 1 / colorProfile.Gamma;

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
            Matrix3x3.Invert(_M, out Matrix3x3 _MInv);
            _M = _MInv;
        }

        public Vector3 RGB(Vector3 XYZ)
        {
            Vec3 res = _M * XYZ; // _M * RGBLinear

            Vector3 RGB = new Vector3
            {
                X = (float)Math.Pow(res.X, _1overGamma),
                Y = (float)Math.Pow(res.Y, _1overGamma),
                Z = (float)Math.Pow(res.Z, _1overGamma)
            }; 
            return RGB * 255f;
        }
    }
}
