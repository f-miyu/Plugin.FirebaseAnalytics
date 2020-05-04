using System;
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
    }
}
