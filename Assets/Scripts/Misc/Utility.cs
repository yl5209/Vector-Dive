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
    }
}
