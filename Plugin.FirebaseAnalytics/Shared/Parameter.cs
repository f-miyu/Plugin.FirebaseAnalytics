using System;
using System.Collections.Generic;

namespace Plugin.FirebaseAnalytics
{
    public class Parameter
    {
        internal string Name { get; }
        internal object Value { get; }

        public Parameter(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public Parameter(string name, long value)
        {
            Name = name;
            Value = value;
        }

        public Parameter(string name, double value)
        {
            Name = name;
            Value = value;
        }

        public Parameter(string name, IEnumerable<IDictionary<string, object>> value)
        {
            Name = name;
            Value = value;
        }
    }
}
