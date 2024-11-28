using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorProfiles.Calculations
{
    public struct Vec3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vec3() { }
        public Vec3(float x, float y, float z) { X = x; Y = y; Z = z; }

        public static Vec3 operator +(Vec3 lhs, Vec3 rhs) { return new Vec3(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z); }
        public static Vec3 operator -(Vec3 lhs, Vec3 rhs) { return new Vec3(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z); }

        public static Vec3 operator *(float f, Vec3 v) { return new Vec3(f * v.X, f * v.Y, f * v.Z); }
        public static Vec3 operator *(Vec3 v, float f) { return f * v; }

        public static bool operator ==(Vec3 lhs, Vec3 rhs) { return lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z; }
        public static bool operator !=(Vec3 lhs, Vec3 rhs) { return !(lhs == rhs); }

        public override readonly bool Equals(object? obj)
        {
            if (obj == null || obj is not Vec3)
                return false;
            return ((Vec3)obj) == this;
        }

        public override readonly int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode();
        }
    }
}
