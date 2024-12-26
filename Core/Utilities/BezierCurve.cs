using System;
using Microsoft.Xna.Framework;

namespace dungeondelvers.Core.Utilities
{
    public static class BezierCurve
    {
        /// <summary>
        /// Lerps throgh the quadratic bezier curve
        /// </summary>
        /// <param name="p1">Starting point</param>
        /// <param name="p2">Anchor point</param>
        /// <param name="p3">End Point</param>
        /// <param name="t">A value between 0 and 1 indicating how far along the curve. Acts like a progress bar</param>
        /// <returns>The position of the point on the curve at the given progress(t)</returns>
        public static Vector2 QuadrantBezierCurve(Vector2 p1, Vector2 p2, Vector2 p3, float t)
        {
            Vector2 pa1 = Vector2.Lerp(p1, p2, t);
            Vector2 pa2 = Vector2.Lerp(p2, p3, t);

            return Vector2.Lerp(pa1, pa2, t);
        }
    }
}