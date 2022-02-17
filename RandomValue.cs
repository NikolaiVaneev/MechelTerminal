using System;

namespace MechelTerminal
{
    /// <summary>
    /// Генератор случайных чисел, не зависящий от текущего времени
    /// </summary>
    internal static class RandomValue
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int Generate(int maxValue)
        {
            lock (syncLock)
            { 
                return random.Next(0, maxValue);
            }
        }
    }
}
