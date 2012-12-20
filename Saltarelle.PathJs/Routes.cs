using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PathApi
{
    [IgnoreNamespace]
    [Imported]
    public class Routes
    {
        [IntrinsicProperty]
        public string Root { get; set; }

        [IntrinsicProperty]
        public string Current { get; set; }

        [IntrinsicProperty]
        public string Previous { get; set; }

        [IntrinsicProperty]
        public Action Rescue { get; set; }

        [IntrinsicProperty]
        public JsDictionary<string, Route> Defined { get; private set; }
    }
}