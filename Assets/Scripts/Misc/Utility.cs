using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public struct Util
    {
        public static Vector3 Vec2_Vec3(Vector2 v2)
        {
            return new Vector3(v2.x, v2.y, 0f);
        }

        public static Vector2 Vec3_Vec2(Vector3 v3)
        {
            return new Vector2(v3.x, v3.y);
        }

        public static float Gaussian(float mean, float stdDev)
        {
            float val1 = Random.Range(0f, 1f);
            float val2 = Random.Range(0f, 1f);
            float gaussValue =
                     Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *
                     Mathf.Sin(2.0f * Mathf.PI * val2);
            return mean + stdDev * gaussValue;
        }

    }
}
