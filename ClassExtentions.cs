using Microsoft.Xna.Framework;
using System;

namespace SpellbladeRevised
{
    public static class ClassExtentions
    {
        public static float SquareMagnitude(this Vector2 vector)
        {
            return vector.X * vector.X + vector.Y * vector.Y;
        }
        public static Vector2 ClampMagnitude(this Vector2 vector, int maxMagnitude)
        {
            if (SquareMagnitude(vector) > maxMagnitude * maxMagnitude)
                return Vector2.Normalize(vector) * maxMagnitude;

            return vector;
        }
        public static int RoundToInt(this float f) => (int)Math.Round(f);
        public static int RoundToIntClamped(this float f) => (int)MathHelper.Clamp((float)Math.Round(f), 0, float.MaxValue);
    }
}
