﻿using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace MathSharp.Utils
{
    internal static class Helpers
    {
        /// <summary>
        /// _MM_SHUFFLE equivalent
        /// </summary>
        public static byte Shuffle(byte a, byte b, byte c, byte d)
        {
            return (byte)(
                  (a << 6)
                | (b << 4)
                | (c << 2)
                | d);
        }

        public static float X(Vector128<float> vector) => vector.GetElement(0);
        public static float Y(Vector128<float> vector) => vector.GetElement(1);
        public static float Z(Vector128<float> vector) => vector.GetElement(2);
        public static float W(Vector128<float> vector) => vector.GetElement(3);

        public static double X(Vector128<double> vector) => vector.GetElement(0);
        public static double Y(Vector128<double> vector) => vector.GetElement(1);

        public static double X(Vector256<double> vector) => vector.GetElement(0);
        public static double Y(Vector256<double> vector) => vector.GetElement(1);
        public static double Z(Vector256<double> vector) => vector.GetElement(2);
        public static double W(Vector256<double> vector) => vector.GetElement(3);

        public static bool AreEqual(Vector4 left, Vector128<float> right)
            => left.X .Equals(X(right)) && left.Y.Equals(Y(right)) && left.Z.Equals(Z(right)) && left.W.Equals(W(right));

        public static bool AreEqual(Vector3 left, Vector128<float> right)
            => left.X.Equals(X(right)) && left.Y.Equals(Y(right)) && left.Z.Equals(Z(right));

        public static bool AreEqual(Vector2 left, Vector128<float> right)
            => left.X.Equals(X(right)) && left.Y.Equals(Y(right));

        public static bool AreEqual(float left, Vector128<float> right)
            => left.Equals(X(right));

        public static readonly float NoBitsSetSingle = 0f; 
        public static readonly float AllBitsSetSingle = Unsafe.As<int, float>(ref Unsafe.AsRef(-1));

        public static readonly double NoBitsSetDouble = 0d;
        public static readonly double AllBitsSetDouble = Unsafe.As<int, double>(ref Unsafe.AsRef(-1));

        public static float BoolToSimdBoolSingle(bool val) => val ? NoBitsSetSingle : AllBitsSetSingle;
        public static double BoolToSimdBoolDouble(bool val) => val ? NoBitsSetDouble : AllBitsSetDouble;
        public static int BoolToSimdBoolInt32(bool val) => val ? -1 : 0;
    }
}
