﻿using System;
using System.Collections.Generic;
using OpenTK;
using System.Runtime.Intrinsics;
using Xunit;
using static MathSharp.UnitTests.TestHelpers;


namespace MathSharp.UnitTests.VectorTests.VectorSingle.VectorOperations
{
    public class DotProduct
    {
        public static IEnumerable<object[]> Data(VectorDimensions dimension)
        {
            var objs = new[]
            {
                new object[] {Vector128.Create(0f), Vector128.Create(0f), default(Vector4)},
                new object[] {Vector128.Create(1f), Vector128.Create(1f), default(Vector4)},
                new object[] {Vector128.Create(-1f), Vector128.Create(-1f), default(Vector4)},
                new object[] {Vector128.Create(-1f), Vector128.Create(1f, 4f, 9f, 16f), default(Vector4)},
                new object[] {Vector128.Create(1f, 2f, 3f, 4f), Vector128.Create(4f, -5f, 6f, 9f), default(Vector4)},
                new object[] {Vector128.Create(float.PositiveInfinity), Vector128.Create(float.PositiveInfinity), default(Vector4)},
                new object[] {Vector128.Create(float.PositiveInfinity), Vector128.Create(float.NegativeInfinity), default(Vector4)},
                new object[] {Vector128.Create(float.NaN), Vector128.Create(float.NegativeInfinity), default(Vector4)},
                new object[] {Vector128.Create(float.MaxValue, float.MinValue, float.NaN, 0), Vector128.Create(float.MaxValue, float.MinValue, float.NaN, 0), default(Vector4)},
            };

            foreach (object[] set in objs)
            {
                switch (dimension)
                {
                    case VectorDimensions.V2D:
                        {
                            Vector2 v1 = ByValToSlowVector2(((Vector128<float>)set[0]));
                            Vector2 v2 = ByValToSlowVector2(((Vector128<float>)set[1]));
                            float dot = Vector2.Dot(v1, v2);
                            set[2] = new Vector2(dot);
                            break;
                        }

                    case VectorDimensions.V3D:
                        {
                            Vector3 v1 = ByValToSlowVector3(((Vector128<float>)set[0]));
                            Vector3 v2 = ByValToSlowVector3(((Vector128<float>)set[1]));
                            float dot = Vector3.Dot(v1, v2);
                            set[2] = new Vector3(dot);
                            break;
                        }

                    case VectorDimensions.V4D:
                        {
                            Vector4 v1 = ByValToSlowVector4(((Vector128<float>)set[0]));
                            Vector4 v2 = ByValToSlowVector4(((Vector128<float>)set[1]));
                            float dot = Vector4.Dot(v1, v2);
                            set[2] = new Vector4(dot);
                            break;
                        }

                    default:
                        throw new ArgumentException(nameof(dimension));
                }
            }

            return objs;
        }

        [Theory]
        [MemberData(nameof(Data), VectorDimensions.V2D)]
        public static void Dot2D_Theory(Vector128<float> left, Vector128<float> right, Vector2 expected)
        {
            Vector128<float> result = Vector.Dot2D(left, right);

            Assert.True(AreEqual(expected, result), $"Expected {expected}, got {result}");
        }

        [Theory]
        [MemberData(nameof(Data), VectorDimensions.V3D)]
        public static void Dot3D_Theory(Vector128<float> left, Vector128<float> right, Vector3 expected)
        {
            Vector128<float> result = Vector.Dot3D(left, right);

            Assert.True(AreEqual(expected, result), $"Expected {expected}, got {result}");
        }

        [Theory]
        [MemberData(nameof(Data), VectorDimensions.V4D)]
        public static void Dot4D_Theory(Vector128<float> left, Vector128<float> right, Vector4 expected)
        {
            Vector128<float> result = Vector.Dot4D(left, right);

            Assert.True(AreEqual(expected, result), $"Expected {expected}, got {result}");
        }
    }
}