using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ColorProfiles.Colors
{
    public class ChromaticAdapterPrecalculated
    {
        private Matrix4x4 _M;
        private bool _isTheSame = false;
        public ChromaticAdapterPrecalculated(WhitePoint from, WhitePoint to)
        {
            if(from.Name == to.Name && from.Name != WhitePoint.Custom)
            {
                _isTheSame = true;
                return;
            }
            _M = _precalculatedMatrices[(from.Name, to.Name)];
        }
        public Vector3 Adapt(Vector3 XYZ)
        {
            if (_isTheSame)
                return XYZ;
            Vector4 temp = new Vector4(XYZ.X, XYZ.Y, XYZ.Z, 0);
            Vector4 res = Vector4.Transform(temp, _M);
            return new Vector3(res.X, res.Y, res.Z);
        }

        public static readonly Dictionary<(string, string), Matrix4x4> _precalculatedMatrices = new()
        {
            { ("A", "B"), new Matrix4x4(0.8905163f, -0.0829136f, 0.2680945f, 0,
                                        -0.0971524f, 1.0754262f, 0.0879463f, 0,
                                        0.0538970f, -0.0908558f, 2.4838553f, 0,
                                        0, 0, 0, 1) },
            { ("A", "C"), new Matrix4x4(0.8530161f, -0.1130268f, 0.4404346f, 0,
                                        -0.1238786f, 1.0853435f, 0.1425803f, 0,
                                        0.0911907f, -0.1553658f, 3.4776250f, 0,
                                        0, 0, 0, 1) },
            { ("A", "D50"), new Matrix4x4(0.8779529f, -0.0915288f, 0.2566181f, 0,
                                        -0.1117372f, 1.0924325f, 0.0851788f, 0,
                                        0.0502012f, -0.0837636f, 2.3994031f, 0,
                                        0, 0, 0, 1) },
            { ("A", "D55"), new Matrix4x4(0.8644459f, -0.1021330f, 0.3073182f, 0,
                                        -0.1222890f, 1.0982532f, 0.1013945f, 0,
                                        0.0609732f, -0.1022820f, 2.6887535f, 0,
                                        0, 0, 0, 1) },
            { ("A", "D65"), new Matrix4x4(0.8446965f, -0.1179225f, 0.3948108f, 0,
                                        -0.1366303f, 1.1041226f, 0.1291718f, 0,
                                        0.0798489f, -0.1348999f, 3.1924009f, 0,
                                        0, 0, 0, 1) },
            { ("A", "E"), new Matrix4x4(0.8815963f, -0.0908179f, 0.3439213f, 0,
                                        -0.1006757f, 1.0708986f, 0.1115462f, 0,
                                        0.0709158f, -0.1206464f, 2.9302950f, 0,
                                        0, 0, 0, 1) },
            { ("A", "F2"), new Matrix4x4(0.9083396f, -0.0683719f, 0.1754134f, 0,
                                        -0.0853260f, 1.0728419f, 0.0587007f, 0,
                                        0.0336526f, -0.0557284f, 1.9465816f, 0,
                                        0, 0, 0, 1) },
            { ("A", "F7"), new Matrix4x4(0.8447932f, -0.1178395f, 0.3941104f, 0,
                                        -0.1365823f, 1.1041477f, 0.1289531f, 0,
                                        0.0796929f, -0.1346275f, 3.1882950f, 0,
                                        0, 0, 0, 1) },
            { ("A", "F11"), new Matrix4x4(0.9214338f, -0.0587653f, 0.1579041f, 0,
                                        -0.0725224f, 1.0609434f, 0.0526133f, 0,
                                        0.0306110f, -0.0508982f, 1.8568836f, 0,
                                        0, 0, 0, 1) },
            { ("D50", "D65"), new Matrix4x4(0.9555766f, -0.0230393f, 0.0631636f, 0,
                                        -0.0282895f, 1.0099416f, 0.0210077f, 0,
                                        0.0122982f, -0.0204830f, 1.3299098f, 0,
                                        0, 0, 0, 1) },
            { ("D65", "D50"), new Matrix4x4(1.0478112f, 0.0228866f, -0.0501270f, 0,
                                        0.0295424f, 0.9904844f, -0.0170491f, 0,
                                        -0.0092345f, 0.0150436f, 0.7521316f, 0,
                                        0, 0, 0, 1) },
            { ("from", "to"), new Matrix4x4() },
        };
    }
}
