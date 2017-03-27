using System;
using System.Linq;
using System.Collections.Generic;

namespace WordCounterService.Utils
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }

        public static IEnumerable<T2> ForEach<T1,T2>(this IEnumerable<T1> enumeration, Func<T1, T2> function)
        {
            foreach (T1 item in enumeration)
            {
                yield return function(item);
            }
        }
    }
}
