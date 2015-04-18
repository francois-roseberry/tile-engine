using System;

namespace TileEngine.Core
{
    public class Preconditions
    {
        public static void CheckArgument(bool condition, string message)
        {
            if (!condition)
            {
                throw new ArgumentException(message);
            }
        }

        public static T CheckNotNull<T>(T obj, string message)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(message);
            }
            return obj;
        }
    }
}
