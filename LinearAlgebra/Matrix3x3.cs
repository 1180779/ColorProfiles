using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra
{
    public struct Matrix3x3
    {
        public Matrix3x3(
            float m11, float m12, float m13, 
            float m21, float m22, float m23, 
            float m31, float m32, float m33) 
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M31 = m31;
            M32 = m32;
            M33 = m33;
        }
        public Matrix3x3() { }

        public float M11 { get; set; }
        public float M12 { get; set; }
        public float M13 { get; set; }

        public float M21 { get; set; }
        public float M22 { get; set; }
        public float M23 { get; set; }

        public float M31 { get; set; }
        public float M32 { get; set; }
        public float M33 { get; set; }

        public static Vec3 operator*(Vec3 v, Matrix3x3 m)
        {
            return new Vec3(
                v.X * m.M11 + v.Y * m.M21 + v.Z * m.M31,
                v.X * m.M12 + v.Y * m.M22 + v.Z * m.M32,
                v.X * m.M13 + v.Y * m.M23 + v.Z * m.M33
            );
        }

        public static Vec3 operator *(Matrix3x3 m, Vec3 v)
        {
            return new Vec3(
                m.M11 * v.X + m.M12 * v.Y + m.M13 * v.Z,
                m.M21 * v.X + m.M22 * v.Y + m.M23 * v.Z,
                m.M31 * v.X + m.M32 * v.Y + m.M33 * v.Z
            );
        }

        public static Matrix3x3 operator *(Matrix3x3 m1, Matrix3x3 m2)
        {
            return new Matrix3x3(
                m1.M11 * m2.M11 + m1.M12 * m2.M21 + m1.M13 * m2.M31,
                m1.M11 * m2.M12 + m1.M12 * m2.M22 + m1.M13 * m2.M32,
                m1.M11 * m2.M13 + m1.M12 * m2.M23 + m1.M13 * m2.M33,

                m1.M21 * m2.M11 + m1.M22 * m2.M21 + m1.M23 * m2.M31,
                m1.M21 * m2.M12 + m1.M22 * m2.M22 + m1.M23 * m2.M32,
                m1.M21 * m2.M13 + m1.M22 * m2.M23 + m1.M23 * m2.M33,

                m1.M31 * m2.M11 + m1.M32 * m2.M21 + m1.M33 * m2.M31,
                m1.M31 * m2.M12 + m1.M32 * m2.M22 + m1.M33 * m2.M32,
                m1.M31 * m2.M13 + m1.M32 * m2.M23 + m1.M33 * m2.M33
            );
        }

        public static bool Invert(Matrix3x3 m, out Matrix3x3 res)
        {
            Matrix4x4 temp = new Matrix4x4(
                m.M11, m.M12, m.M13, 0,
                m.M21, m.M22, m.M23, 0,
                m.M31, m.M32, m.M33, 0,
                0, 0, 0, 1
                );
            var boolres = Matrix4x4.Invert(temp, out Matrix4x4 res4x4);
            res = new Matrix3x3(
                res4x4.M11, res4x4.M12, res4x4.M13,
                res4x4.M21, res4x4.M22, res4x4.M23,
                res4x4.M31, res4x4.M32, res4x4.M33
                );
            return boolres;
        }
    }
}
