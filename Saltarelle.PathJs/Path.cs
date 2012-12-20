using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PathApi
{
    [ScriptName("Path")]
    [Imported]
    [IgnoreNamespace]
    public static class Path
    {
        public static string Version;

        [IntrinsicProperty]
        public static Routes Routes
        {
            get { return null; }
        }

        [IntrinsicProperty]
        public static History History
        {
            get { return null; }
        }

        public static JsDictionary<string, string> Parameters
        {
            [InlineCode("this.params")] get { return null; }
        }

        public static Route Map(string path)
        {
            return null;
        }

        public static void Root(string newRoot)
        {
        }

        public static void Rescue(Action action)
        {
        }

        public static Route Match(string path, bool parametrize)
        {
            return null;
        }

        public static bool Dispatch(string passedRoute)
        {
            return false;
        }

        public static void Listen()
        {
        }
    }
}