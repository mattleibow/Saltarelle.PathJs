using System;
using System.Runtime.CompilerServices;

namespace PathApi
{
    [ScriptNamespace("Path.core")]
    [Imported]
    public class Route
    {
        [IntrinsicProperty]
        public static string Path { get; set; }

        [IntrinsicProperty]
        public static Action Action { get; set; }

        [IntrinsicProperty]
        public static Action[] DoEnter { get; set; }

        [IntrinsicProperty]
        public static Action DoExit { get; set; }

        public Route To(Action action)
        {
            return this;
        }

        public Route Enter(Action action)
        {
            return this;
        }

        public Route Enter(Action[] action)
        {
            return this;
        }

        public Route Enter(Func<bool> action)
        {
            return this;
        }

        public Route Enter(Func<bool>[] action)
        {
            return this;
        }

        public Route Exit(Action action)
        {
            return this;
        }

        public void Run()
        {
            
        }
    }
}