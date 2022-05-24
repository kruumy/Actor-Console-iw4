using System;
using System.Collections.Generic;
using System.Linq;

namespace ActorConsole.Classes
{
    internal static class StringFuncs
    {
        public static T[] RemoveLastElement<T>(this T[] array)
        {
            var stack = new Stack<T>(array);
            stack.Pop();
            return stack.ToArray().Reverse().ToArray();
        }
        public static T[] RemoveFirstElement<T>(this T[] array)
        {
            var queue = new Queue<T>(array);
            queue.Dequeue();
            return queue.ToArray();
        }
    }
}
