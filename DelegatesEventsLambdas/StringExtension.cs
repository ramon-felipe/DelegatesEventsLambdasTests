using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesEventsLambdas
{
    public static class String
    {
        public static string Fmt(this string a, params object?[] args)
        {
            return string.Format(a, args);
        }
    }
}
