using System;
using Microsoft.Xna.Framework;

namespace dungeondelvers.Core.Utilities
{
    public static class BezierCurve
    {
        public static Vector2 QuadrantBezierCurve(Vector2 p1, Vector2 p2, Vector2 p3, float t)
        {
            Vector2 pa1 = Vector2.Lerp(p1, p2, t);
            Vector2 pa2 = Vector2.Lerp(p2, p3, t);

            return Vector2.Lerp(pa1, pa2, t);
        }
    }
}